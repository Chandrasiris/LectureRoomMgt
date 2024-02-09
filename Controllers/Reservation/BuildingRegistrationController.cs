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
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LectureRoomMgt.Controllers.Reservation
{
    public class BuildingRegistrationController : Controller
    {
        public UserManager<ApplicationUser> UserManager { get; }
        public SignInManager<ApplicationUser> SignInManager { get; }
        public WisdomAppDBContext db { get; }
        private static bool UpdateDatabase = false;
        private ISession session;
        public ISession Session { get { return session; } }
        public BuildingRegistrationController(UserManager<ApplicationUser> userManager,
                                 SignInManager<ApplicationUser> signInManager,
                                 WisdomAppDBContext wisdomAppDBContext, IHttpContextAccessor httpContextAccessor
                                 )
        {
            UserManager = userManager;
            SignInManager = signInManager;
            db = wisdomAppDBContext;
            session = httpContextAccessor.HttpContext.Session;
        }
        public IActionResult BuildingRegIndex()
        {
            ViewBag.ComMethods = new SelectList(db.CommunicationTypes.ToList(), "ComType", "ComType");
            return View();
        }
        [HttpPost]
        public IActionResult BuildingReg(BuildingRegVM buildObj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    List<Block> b = new List<Block> { };
                    for (int i = 1; i < buildObj.NoOfBlocks + 1; i++)
                    {
                        Block bb = new Block()
                        { BlockName = buildObj.BlockLetter.ToUpper() + i.ToString() };
                        b.Add(bb);
                    }
                    buildObj.Blocks = b;

                    Models.Reservation.Faculty newBuilding = new Models.Reservation.Faculty
                    {
                        Code = buildObj.Code,
                        FacultyName = buildObj.FacultyName,
                        Head = buildObj.Head,
                        FacultyContacts = buildObj.FacultyContacts,
                        Blocks = buildObj.Blocks
                    };
                    db.Add(newBuilding);
                    db.SaveChanges();

                    return Json(new { status = "1", redirectUrl = Url.Action("BuildingFloorRegIndex", "BuildingRegistration", new { FacId = buildObj.FacultyName }) });
                }
                return Json(new { status = "4" });
            }
            catch (Exception)
            {
                return Json(new { status = "4" });
            }
        }


        public IActionResult BuildingFloorRegIndex(string FacId = "")
        {
            ViewBag.FacId = FacId;
            return View();
        }


        public ActionResult FloorRegRead([DataSourceRequest] DataSourceRequest request, string FacId = "")
        {
            return Json(ReadData(FacId).ToDataSourceResult(request));
        }
        public IEnumerable<FloorVM> ReadData(string FacId)
        {
            return GetAll(FacId);
        }

        public IList<FloorVM> GetAll(string FacId)
        {
            using (db)
            {
                var floor = Session.GetObjectFromJson<IList<FloorVM>>("Floors");

                var faculties = db.Faculties.Where(c => c.FacultyName == FacId).ToList();
                if (faculties.Count > 0)
                {
                    floor = db.Blocks.Where(c=>c.Faculty.FacultyName==FacId).ToList().Select(f =>
                    {
                        var faculty = faculties.FirstOrDefault(c => f.FacultyId == c.Id);
                        return new FloorVM //1
                        {
                            FloorId = f.Id,
                            BlockName = f.BlockName,
                            FacultyName = FacId,
                            FacultyId=f.FacultyId,
                            BlockId=f.Id,
                            FloorName=""                            
                        };
                    }).ToList();

                    Session.SetObjectAsJson("Floors", floor);
                }

                return floor;
            }
        }
       
        [AcceptVerbs("Post")]
        public ActionResult Update([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")] IEnumerable<FloorVM> vm)
        {
            if (vm != null && ModelState.IsValid)
            {
                foreach (var floor in vm)
                {
                    InsertFloors(floor);
                }
            }

            return Json(vm.ToDataSourceResult(request, ModelState));
        }
        public void InsertFloors(FloorVM vm)
        {
            List<string> blocks = vm.FloorName.Split(',').ToList<string>();
            foreach (var item in blocks)
            {
                Floor newFloor = new Floor
                {
                    FloorName = item,
                    BlockId = vm.BlockId
                };
                db.Add(newFloor);
            }
           
            db.SaveChanges(); 
            Session.SetObjectAsJson("Faculties", vm);           

        }
    }
}
