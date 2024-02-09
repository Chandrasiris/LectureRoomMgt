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


namespace LectureRoomMgt.Controllers.Reservation.RoomFacilities
{
    public class RoomFacilityController : Controller
    {
        public UserManager<ApplicationUser> UserManager { get; }
        public SignInManager<ApplicationUser> SignInManager { get; }
        public WisdomAppDBContext Context { get; }
        private static bool UpdateDatabase = false;
        private ISession session;
        public ISession Session { get { return session; } }
        public RoomFacilityController(UserManager<ApplicationUser> userManager,
                                 SignInManager<ApplicationUser> signInManager,
                                 WisdomAppDBContext wisdomAppDBContext, IHttpContextAccessor httpContextAccessor
                                 )
        {
            UserManager = userManager;
            SignInManager = signInManager;
            Context = wisdomAppDBContext;
            session = httpContextAccessor.HttpContext.Session;

        }
        public IActionResult RoomFacilityIndex(string roomName, int roomId)
        {
            ViewData["roomName"] = roomName;
            ViewData["roomId"] = roomId;
            PopulateCats();
            return View();
        }
        private void PopulateCats()
        {
            using (Context)
            {
                var F = Context.FacilityCategories
                .Select(c => new FacilityCategoryDDL
                {
                    Id = c.Id,
                    Category = c.Category
                })
                .OrderBy(e => e.Category);

                ViewData["facilityCategories"] = F.ToList();
                ViewData["defaultFacilityCategory"] = F.First();    
            }
        }
        public ActionResult ReadSelectedRoomFacilities(int RoomId)
        {
            return View("RoomFacilityIndex", Facilities(RoomId));
        }
        private IList<RoomFacilityVM> Facilities(int RoomId)
        {
            var info = from f in Context.RoomFacilities
                       join b in Context.FacilityCategories                      
                      on f.FacilityCategoryId equals b.Id
                       where f.RoomId == RoomId
                       select new
                       {                           
                           f.FacilityCategory.Category,
                           f.Status,
                           f.Qty,
                           f.Comment
                       };
            var facilities = info.AsEnumerable().Select(rf =>
            {
                return new RoomFacilityVM
                {
                    FacilityCategoryDescription=rf.Category,
                    Status=rf.Status,
                    Qty=rf.Qty,
                    Comment=rf.Comment
                };
            }).ToList();
            return facilities;
        }
        public IActionResult ViewRoomFacilities()
        {
            return View();
        }
 
        public ActionResult Read([DataSourceRequest] DataSourceRequest request, int RoomId)
        {
            return Json(ReadData(RoomId).ToDataSourceResult(request));
        }
        public IEnumerable<RoomFacilityVM> ReadData(int RoomId=0)
        {
            if ( RoomId==0)
            {
                return GetAll();

            }
            return GetSelectedData(RoomId);
        }
        public IList<RoomFacilityVM> GetSelectedData(int RoomId)
        {
            using (Context){
                HttpContext.Session.Remove("Facilities1");              
                var F = Session.GetObjectFromJson<IList<RoomFacilityVM>>("Facilities1");
                if (F == null || UpdateDatabase)
                {
                    var cats = Context.FacilityCategories.ToList();
                    F = Context.RoomFacilities.ToList().Where(c => c.RoomId == RoomId).Select(f =>
                    {
                        var cat = cats.First(c => f.FacilityCategoryId == c.Id);
                        return new RoomFacilityVM
                        {
                            FacilityCategoryDDL = new FacilityCategoryDDL()
                            { Id = cat.Id, Category = cat.Category },
                            Status = f.Status,
                            Qty = f.Qty,
                            Comment = f.Comment
                        };
                    }).ToList();
                    Session.SetObjectAsJson("Facilities1", F);
                }
                return F;
            }
        }

        public IList<RoomFacilityVM> GetAll()
        {
            using (Context)
            {
                HttpContext.Session.Remove("Facilities");
                var F = Session.GetObjectFromJson<IList<RoomFacilityVM>>("Facilities");
                //if (F == null || UpdateDatabase)
                //{ 
                //    var facilities=(from p in Context.RoomFacilities
                //                  join e in Context.FacilityCategories
                //  on p.FacilityCategoryId equals e.Id
                // where p.RoomCode== RoomCode
                //                    select new
                //  {
                //      FacilityCode = p.FacilityCode,
                //       FacilityCategory = p.FacilityCategory.Category,
                //      FacilityDescription = p.FacilityDescription,
                //      Status = p.Status,
                //      Qty = p.Qty,
                //      Comment = p.Comment                    
                //  }).ToList();

                //    F = facilities.Select(p =>
                //    {                       
                //        return new RoomFacilityVM
                //        {
                //            FacilityCode = p.FacilityCode,                            
                //            FacilityDescription = p.FacilityDescription,
                //            Status = p.Status,
                //            Qty = p.Qty,
                //            Comment = p.Comment
                //        };
                //    }).ToList();
                //    Session.SetObjectAsJson("Facilities", F);
                //}
                //return F;
                if (F == null || UpdateDatabase)
                {
                    var cats = Context.FacilityCategories.ToList();
                    F = Context.RoomFacilities.ToList().Select(f =>
                    {
                        var cat = cats.First(c => f.FacilityCategoryId == c.Id);
                        return new RoomFacilityVM
                        {
                            FacilityCategoryDDL = new FacilityCategoryDDL()
                            { Id = cat.Id, Category = cat.Category },
                            Status=f.Status,
                            Qty=f.Qty,
                            Comment = f.Comment,
                            Id = f.Id
                        };
                    }).ToList();
                    Session.SetObjectAsJson("Facilities", F);
                }
                return F;
            }
        }

        [HttpPost]
        public ActionResult Create([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")] IEnumerable<RoomFacilityVM> facilities, int RoomId)
        {
            using (Context)
            {            
                var FacilitiyList = new List<RoomFacilityVM>();               
                if (facilities != null && RoomId != 0)
                {
                    var allRoomsFacs = Context.RoomFacilities.Where(x => x.RoomId == RoomId).ToList();

                    if (allRoomsFacs.Count > 0)
                    {
                        Context.RemoveRange(allRoomsFacs);
                        Context.SaveChanges();
                    }


                    foreach (var facility in facilities)
                    {
                        Insert(facility, RoomId);
                        FacilitiyList.Add(facility);
                    }
                }
                return Json(FacilitiyList.ToDataSourceResult(request, ModelState));
            }            
        }
        public void Insert(RoomFacilityVM F, int RoomId)
        {           
                var f = new RoomFacility();
            
                f.RoomId = RoomId;
                f.FacilityCategoryId = F.FacilityCategoryDDL.Id;
                f.Qty = F.Qty;
                f.Comment =  F.Comment;
                f.Status = F.FacilityCategoryDDL.Category;            
            //if (f.FacilityCategoryId == null) //This helps to add the FacCatId
            //{
            //    //    f.FacilityCategoryId = 1;
            //    //}

            //    //if (F.FacilityCategoryId != null)
            //    //{
            //    f.FacilityCategoryId = F.FacilityCategory.Id;
            //}
            Context.RoomFacilities.Add(f);
            Context.SaveChanges();
            F.Id = f.Id;
            
        }
    }
}
