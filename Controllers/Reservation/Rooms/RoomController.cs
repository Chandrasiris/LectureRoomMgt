using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using LectureRoomMgt.DAL;
using LectureRoomMgt.Extensions;
using LectureRoomMgt.Models;
using LectureRoomMgt.Models.Reservation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace LectureRoomMgt.Controllers.Reservation.Rooms
{
    public class RoomController : Controller
    {
        public UserManager<ApplicationUser> UserManager { get; }
        public SignInManager<ApplicationUser> SignInManager { get; }
        public WisdomAppDBContext Context { get; }
        private static bool UpdateDatabase = false;
        private ISession session;
        public ISession Session { get { return session; } }
        public RoomController(UserManager<ApplicationUser> userManager,
                                 SignInManager<ApplicationUser> signInManager,
                                 WisdomAppDBContext wisdomAppDBContext, IHttpContextAccessor httpContextAccessor
                                 )
        {
            UserManager = userManager;
            SignInManager = signInManager;
            Context = wisdomAppDBContext;
            session = httpContextAccessor.HttpContext.Session;
        }
        public IActionResult RoomIndex()
        {
            //var facCat = from f in Context.FacilityCategories.Distinct() select  new { f.Id, f.Category };
            //var Cat = facCat.AsEnumerable().Select(c => { return new RoomFacilityCatVM { CatId=c.Id,Category=c.Category}; }).ToList();
            //var facility = from c in Context.RoomFacilities.OrderBy(c => c.FacilityCategoryId) select new {  c.FacilityDescription, c.Comment, c.FacilityCategoryId, c.Id };
            //var fac = facility.AsEnumerable().Select(c => { return new RoomFacilityVM { FacilityDescription = c.FacilityDescription, Comment = c.Comment, FacilityCatId = c.FacilityCategoryId, FacilityId = c.Id }; }).ToList();
            //ViewBag.fac = fac;
            //ViewBag.cat = Cat;
            return View();

        }
        public JsonResult GetFaculties()
        {
            using (Context)
            {
                return Json(Context.Faculties
                    .Select(c => new { Id = c.Id, FacultyName = c.FacultyName }).ToList());
            }
        }
        public JsonResult GetBlocks(int? FacultyId)
        {
            using (Context)
            {
                if (FacultyId != null)
                {
                    return Json(Context.Blocks.Where(f => f.FacultyId == FacultyId).Select(c => new { Id = c.Id, BlockName = c.BlockName }).OrderBy(c => c.BlockName).ToList());
                }
                return null;
            }
        }
        public JsonResult GetFloors(int? BlockId)
        {
            using (Context)
            {
                if (BlockId != null)
                {                   
                    return Json(Context.Floors.Where(f => f.BlockId == BlockId).Select(c => new { Id = c.Id, FloorName = c.FloorName }).OrderBy(c => c.FloorName).ToList());
                }
                return null;
            }
        }
        public JsonResult GetRooms(int? FloorId)
        {
            using (Context)
            {
                if (FloorId != null)
                {
                    return Json(Context.Rooms.Where(f => f.FloorId == FloorId).Select(c => new { Id = c.Id, RoomName = c.RoomName }).OrderBy(c => c.RoomName).ToList());
                }
                return null;
            }
        }
        public JsonResult GetRoomTypes()
        {
            using (Context)
            {
                return Json(Context.RoomTypes
                    .Select(c => new { Id = c.Id, Type = c.Type }).ToList());
            }
        }
        public JsonResult GetRoomName(int floorId)
        {
            using (Context)
            {
                var c=Context.Rooms.Where(c=>c.FloorId== floorId )
                    .Max(c => c.RoomName);
                if (c == null)
                {
                    c = "01";
                }
                return Json(c);
            }
        }       
        public ActionResult ReadRoomsOfSelectedFloor(int? FacultyId,int? BlockId,int? FloorId)
        {
            return View("RoomIndex", RoomsOfFloor(FacultyId,BlockId,FloorId));
        }
        private IList<RoomVM> RoomsOfFloor(int? FacultyId, int? BlockId, int? FloorId)
        {
            var info = from f in Context.Faculties
                       join b in Context.Blocks
                       on f.Id equals b.FacultyId                       
                       join fl in Context.Floors
                       on b.Id equals fl.BlockId
                       join r in Context.Rooms
                       on fl.Id equals r.FloorId
                       where f.Id == FacultyId &&  b.Id==BlockId && fl.Id==FloorId
                       select new
                       {
                           r.Id,
                           r.RoomName,
                           r.Grade,
                           r.RoomType.Type,
                           r.Status,
                           r.Capacity,
                           r.Comment,
                           fl.FloorName,
                           b.BlockName,
                           f.FacultyName
                       };
            var rooms = info.AsEnumerable().Select(st =>
            {
                return new RoomVM
                {
                    RoomId=st.Id,
                   RoomName=st.RoomName, 
                   RoomGrade=st.Grade,
                    RoomType=st.Type, 
                    Capacity=st.Capacity,
                    Status=st.Status,
                    Comment=st.Comment, 
                    FacultyName=st.FacultyName, 
                    BlockName=st.BlockName,
                    FloorName=st.FloorName
                };
            }).ToList();
            return rooms;
        }
        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(ReadData().ToDataSourceResult(request));
        }
        public IEnumerable<Room> ReadData()
        {
            return GetAll();
        }
        public IList<Room> GetAll()
        {
            using (Context)
            {
                var room = Session.GetObjectFromJson<IList<Room>>("Rooms");

                if (room == null || UpdateDatabase)
                {
                    var floors = Context.Floors.ToList();
                    room = Context.Rooms.ToList().Select(f =>
                    {
                        var floor = floors.First(c => f.FloorId == c.Id);
                        return new Room
                        {                           
                             RoomName= f.RoomName,
                             Grade=f.Grade,
                            Capacity=f.Capacity,
                            FloorId = f.FloorId,
                            Floor = new Floor()
                            { Id = floor.Id, FloorName = floor.FloorName }
                        };
                    }).ToList();

                    Session.SetObjectAsJson("Rooms", room);
                }
                return room;
            }
        }
     
        public IActionResult InsertRoom(RoomVM roomObj, int[] Fac)
        {
            using (Context)
            {
                // bool cnt = Context.Rooms.Where(r => r.RoomName == roomObj.RoomName).Count()>0;
                bool cnt = Context.Rooms.Where(r => r.RoomName == roomObj.RoomName && r.FloorId == roomObj.FloorId).Count() == 0;


                if (cnt && roomObj.RoomName != null)
                {
                    var entity = new Room();
                    entity.RoomName = roomObj.RoomName;
                    entity.Grade = roomObj.RoomGrade;
                    entity.RoomTypeId = roomObj.RoomTypeId;
                    entity.Capacity = roomObj.Capacity;
                    entity.Status = "A";
                    entity.Comment = roomObj.Comment;
                    entity.FloorId = roomObj.FloorId;
                    Context.Rooms.Add(entity);
                    Context.SaveChanges();
                    int id = entity.Id;  
                }
            }
            return RedirectToAction("ReadRoomsOfSelectedFloor",new { FacultyId =roomObj.FacultyId, BlockId =roomObj.BlockId, FloorId=roomObj.FloorId });
        }
        [HttpPost]
        public ActionResult Create([DataSourceRequest] DataSourceRequest request,
           [Bind(Prefix = "models")] IEnumerable<Room> R)
        {
            var rooms = new List<Room>();
            if (R != null && ModelState.IsValid)
            {
                foreach (var room in R)
                {
                    Insert(room);
                    rooms.Add(room);
                }
            }
            return Json(rooms.ToDataSourceResult(request, ModelState));
        }
        public void Insert(Room roomObj)
        {
            using (Context)
            {
                var entity = new Room();
                entity.RoomName = roomObj.RoomName;
                entity.Grade = roomObj.Grade;
                entity.Capacity = roomObj.Capacity;
                entity.FloorId = roomObj.FloorId;
                if (entity.FloorId == null)
                {
                    entity.FloorId = 1;
                }
                if (roomObj.Floor != null)
                {
                    entity.FloorId = roomObj.Floor.Id;
                }
                Context.Rooms.Add(entity);
                Context.SaveChanges();
                int id = entity.Id;
            }
        }
        [AcceptVerbs("Post")]
        public ActionResult Update([DataSourceRequest] DataSourceRequest request, Room roomObj)
        {
            if (roomObj != null && ModelState.IsValid)
            {
                UpdateData(roomObj);
            }

            return Json(new[] { roomObj }.ToDataSourceResult(request, ModelState));
        }
        public void UpdateData(Room roomObj)
        {
            if (!UpdateDatabase)
            {
                var room = Context.Rooms.FirstOrDefault(e => e.RoomName == roomObj.RoomName);
                if (room != null)
                {
                    room.RoomName = roomObj.RoomName;
                    room.Capacity = roomObj.Capacity;
                    room.Grade = roomObj.Grade;
                }
                Context.Rooms.Attach(room);
                // db.Entry(entity).State = EntityState.Modified;
                Context.SaveChanges();
                Session.SetObjectAsJson("Rooms", roomObj);
            }
        }

        public ActionResult Delete([DataSourceRequest] DataSourceRequest request, Room roomObj)
        {
            if (roomObj != null)
            {
                Destroy(roomObj);
            }
            return Json(new[] { roomObj }.ToDataSourceResult(request, ModelState));
        }

        public void Destroy(Room roomObj)
        {
            if (!UpdateDatabase)
            {
                var room = Context.Rooms.FirstOrDefault(e => e.RoomName == roomObj.RoomName);
                if (room != null)
                {
                    Context.Rooms.Remove(room); 
                    Context.SaveChanges(); 
                }
                Session.SetObjectAsJson("Rooms", roomObj);
            }
        }
        public IActionResult RoomDelete(string roomName, int roomId)
        {
           
                var room = Context.Rooms.FirstOrDefault(e => e.RoomName == roomName);
                if (room != null)
                {
                    Context.Rooms.Remove(room);
                    Context.SaveChanges();
                }
            return View("RoomIndex");
        }
        public IActionResult RoomTypeIndex()
        {

            return View("RoomIndex");
        }
    }
}
