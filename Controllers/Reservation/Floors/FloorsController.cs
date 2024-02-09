using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using LectureRoomMgt.Models.Reservation;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using LectureRoomMgt.Models;
using LectureRoomMgt.DAL;
using Microsoft.AspNetCore.Http;
using LectureRoomMgt.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LectureRoomMgt.Controllers.Reservation.Floors
{
    public class FloorsController : Controller
    {
        public UserManager<ApplicationUser> UserManager { get; }
        public SignInManager<ApplicationUser> SignInManager { get; }
        public WisdomAppDBContext Context { get; }
        private static bool UpdateDatabase = false;
        private ISession session;
        public ISession Session { get { return session; } }
        public FloorsController(UserManager<ApplicationUser> userManager,
                                 SignInManager<ApplicationUser> signInManager,
                                 WisdomAppDBContext wisdomAppDBContext, IHttpContextAccessor httpContextAccessor
                                 )
        {
            UserManager = userManager;
            SignInManager = signInManager;
            Context = wisdomAppDBContext;
            session = httpContextAccessor.HttpContext.Session;
        }
        public IActionResult FloorIndex()
        {
            ViewBag.Faculties = new SelectList(Context.Faculties.ToList(), "Id", "FacultyName");
            return View();
        }
        [HttpPost]
        public IActionResult FloorIndex(FloorVM floorVM)
        {
            if (floorVM.CallType == "F")
            {
                return Json(new { status = "1", redirectUrl = Url.Action("Floor", "Floors", new { BlockId = floorVM.BlockId }) });
            }
            else
            {
                return Json(new { status = "1", redirectUrl = Url.Action("FloorIndex", "Floors", new { BlockId = floorVM.BlockId }) });
            }
        }
        public IActionResult Floor(int BlockId)
        {
            var facBlock = (from x in Context.Blocks select x).Where(x => x.Id == BlockId)
            .Include(p => p.Faculty).FirstOrDefault();
            ViewBag.FacultyName = facBlock.Faculty.FacultyName;
            ViewBag.BlockName = facBlock.BlockName;
            ViewBag.BlockId = BlockId;
            return View();
        }
        //public JsonResult GetFaculties()
        //{
        //    return Json(Context.Faculties
        //        .Select(c => new { Id = c.Id, Name = c.FacultyName }).OrderBy(c => c.Name).ToList());
        //}
        public JsonResult GetBlocksByFac(int facId)
        {
            return Json(Context.Blocks.Where(c => c.FacultyId == facId)
                    .Select(c => new { Id = c.Id, Name = c.BlockName }).OrderBy(c => c.Name).ToList());
        }
        public ActionResult ReadFloorsOfSelectedFac(int FacultyId = 0)
        {
            return View("FloorIndex", FloorsOfFaculties(FacultyId));
        }
        private IList<FloorVM>FloorsOfFaculties(int facId = 0)
        {
            var info = from sc in Context.Blocks
                       join f in Context.Floors
                       on sc.Id equals f.BlockId
                       where sc.FacultyId == facId
                       select new
                       {
                           f.FloorName,f.Id,
                           sc.BlockName, sc.BlockId,
                           sc.Faculty.FacultyName,
                           sc.FacultyId
                       };
            var result = info.AsEnumerable().Select(st =>
            {
                return new FloorVM
                {
                    FloorName=st.FloorName,
                    FloorId=st.Id,
                    BlockName = st.BlockName,
                    BlockId=st.BlockId,
                    FacultyName = st.FacultyName,
                    FacultyId = st.FacultyId
                };
            }).ToList();
            return result;
        }
        //public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        //{
        //    return Json(ReadData().ToDataSourceResult(request));
        //}
        //public IEnumerable<Floor> ReadData()
        //{
        //    return GetAll();
        //}

        //public IList<Floor> GetAll()
        //{
        //    using (Context)
        //    {
        //        var floor = Session.GetObjectFromJson<IList<Floor>>("Floors");

        //        if (floor == null || UpdateDatabase)
        //        {
        //            var Blocks = Context.Blocks.ToList();
        //            floor = Context.Floors.ToList().Select(f =>                    
        //            {
        //                var block = Blocks.First(c =>  f.BlockId == c.Id);
        //                return new Floor
        //                {
        //                    Id = f.Id,
        //                   FloorName=f.FloorName,
        //                  // Code=f.Code,
        //                   BlockId=f.BlockId,
        //                   Block=new Block()
        //                   { Id=block.Id, BlockName=block.BlockName}
        //                };
        //            }).ToList();

        //            Session.SetObjectAsJson("Blocks", floor);
        //        }

        //        return floor;
        //    }
        //}

        //[HttpPost]
        //public ActionResult Create([DataSourceRequest] DataSourceRequest request, FloorVM vm)
        //{
        //    if (vm != null && ModelState.IsValid)
        //    {
        //        Create(vm);
        //    }
        //    return Json(new[] { vm }.ToDataSourceResult(request, ModelState));
        //}
        //public ActionResult Create(FloorVM vm)
        //{
        //    using (Context)
        //    {
        //        List<string> floors = vm.FloorName.Split(',').ToList<string>();
        //        bool t = Context.Floors.Where(c => floors.Contains(c.FloorName) && c.BlockId== vm.BlockId).ToList().Count > 0;
        //        if (!t && vm.FacultyId != null)
        //        {
        //            foreach (var item in floors)
        //            {
        //                var obj = new Floor();
        //                obj.FloorName = item;
        //                obj.BlockId = vm.BlockId;
        //                Context.Floors.Add(obj);
        //            }
        //            Context.SaveChanges();
        //        }
        //        return View("FloorIndex");
        //    }
        //}
        //[AcceptVerbs("Post")]
        //public ActionResult Update([DataSourceRequest] DataSourceRequest request, Floor floorObj)
        //{
        //    if (floorObj != null && ModelState.IsValid)
        //    {
        //        UpdateData(floorObj);
        //    }

        //    return Json(new[] { floorObj }.ToDataSourceResult(request, ModelState));
        //}
        //public void UpdateData(Models.Reservation.Floor floorObj)
        //{
        //    if (!UpdateDatabase)
        //    {               
        //        var floor = Context.Floors.FirstOrDefault(e => e.Id == floorObj.Id);

        //        if (floor != null)
        //        {
        //            floor.FloorName = floorObj.FloorName;
        //            //floor.Code = floorObj.Code;                   
        //        }
        //        Context.Floors.Attach(floor);
        //       // db.Entry(entity).State = EntityState.Modified;
        //        Context.SaveChanges();
        //        Session.SetObjectAsJson("Floors", floorObj);
        //    }

        //}
        //[AcceptVerbs("Post")]
        //public ActionResult Delete([DataSourceRequest] DataSourceRequest request, Floor floorObj)
        //{
        //    if (floorObj != null)
        //    {
        //        Destroy(floorObj);
        //    }

        //    return Json(new[] { floorObj }.ToDataSourceResult(request, ModelState));
        //}
        //public void Destroy(Models.Reservation.Floor floorObj)
        //{
        //    if (!UpdateDatabase)
        //    {
        //        var row = Context.Floors.FirstOrDefault(e => e.Id == floorObj.Id);

        //        if (row != null)
        //        {
        //            Context.Floors.Remove(row);
        //        }               
        //        Context.SaveChanges();
        //        Session.SetObjectAsJson("Floors", floorObj);               
        //    }

        //}


        #region Floor
        public IActionResult LoadFloors([DataSourceRequest]DataSourceRequest request, int BlockId)
        {
            try
            {
                List<FloorVM> floors = (from c in Context.Floors
                                        where c.BlockId == BlockId
                                        select new FloorVM()
                                        {
                                            Id = c.Id,
                                            FloorName = c.FloorName,
                                            Comment = c.Comment,
                                            Status = c.Status
                                        }).ToList();

                return Json(floors.ToDataSourceResult(request));
            }
            catch (Exception)
            {
                ModelState.AddModelError("Floor", "An error has occured, Please contact administrator !");

                return Json(ModelState);
            }
        }


        [HttpPost]
        //[Authorize(Policy = "CreateBlock")]
        public ActionResult CreateFloor([DataSourceRequest]DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<FloorVM> floors, int BlockId)
        {
            try
            {
                var floorList = new List<Floor>();
                var floorVmList = new List<FloorVM>();


                if (floors != null)
                {
                    foreach (var item in floors.Reverse())
                    {
                        var Floor = new Floor()
                        {
                            FloorName = item.FloorName,
                            Comment = item.Comment,
                            Status = item.Status,
                            BlockId = BlockId
                        };

                        floorList.Add(Floor);
                    }
                    Context.Floors.AddRange(floorList);
                    Context.SaveChanges();

                    floorVmList = (from c in floorList
                                   select new FloorVM()
                                   {
                                       Id = c.Id,
                                       FloorName = c.FloorName,
                                       Comment = c.Comment,
                                       Status = c.Status
                                   }).ToList();

                }
                return Json(floorVmList.ToDataSourceResult(request));
            }
            catch (Exception)
            {
                ModelState.AddModelError("Floor", "An error has occured, Please contact administrator !");

                return Json(floors.ToDataSourceResult(request, ModelState));
            }
        }


        [HttpPost]
        //[Authorize(Policy = "ModifyBlock")]
        public IActionResult EditFloor([DataSourceRequest]DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<FloorVM> floors, int BlockId)
        {
            try
            {
                if (floors != null)
                {
                    foreach (var item in floors)
                    {
                        var floorObj = Context.Floors.Where(x => x.Id == item.Id && x.BlockId == BlockId).FirstOrDefault();

                        if (floorObj != null)
                        {
                            floorObj.FloorName = item.FloorName;
                            floorObj.Comment = item.Comment;
                            floorObj.Status = item.Status;

                            Context.SaveChanges();
                        }
                    }
                }
                return Json(floors.ToDataSourceResult(request));
            }
            catch (Exception ex)
            {
                if (ex.InnerException.Message.Contains("Cannot insert duplicate key row in object"))
                {
                    ModelState.AddModelError("Floor", "Duplicate record exists !");
                    return Json(floors.ToDataSourceResult(request, ModelState));
                }
                ModelState.AddModelError("Floor", "An error has occured, Please contact administrator !");
                return Json(floors.ToDataSourceResult(request, ModelState));
            }
        }


        [HttpPost]
        //[Authorize(Policy = "RemoveBlock")]
        public IActionResult DeleteFloor([DataSourceRequest]DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<FloorVM> floors, int BlockId)
        {
            try
            {
                var floorsList = new List<Floor>();

                foreach (var item in floors)
                {
                    var floorObj = Context.Floors.Where(x => x.Id == item.Id && x.BlockId == BlockId).FirstOrDefault();
                    floorsList.Add(floorObj);
                }

                if (floorsList.Count > 0)
                {
                    Context.RemoveRange(floorsList);
                    Context.SaveChanges();
                }
                return Json(new[] { floors }.ToDataSourceResult(request));
            }
            catch (Exception ex)
            {
                if (ex.InnerException.Message.Contains("The DELETE statement conflicted with the REFERENCE constraint"))
                {
                    ModelState.AddModelError("Floor", "Access denied as this row is used by other tables !");
                    return Json(new[] { floors }.ToDataSourceResult(request, ModelState));
                }
                ModelState.AddModelError("Floor", "An error has occured, Please contact administrator !");
                return Json(new[] { floors }.ToDataSourceResult(request, ModelState));
            }
        }

        #endregion

    }
}
