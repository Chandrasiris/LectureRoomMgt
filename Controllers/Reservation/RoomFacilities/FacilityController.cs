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
    public class FacilityController : Controller
    {
        public UserManager<ApplicationUser> UserManager { get; }
        public SignInManager<ApplicationUser> SignInManager { get; }
        public WisdomAppDBContext Context { get; }
        private static bool UpdateDatabase = false;
        private ISession session;
        public ISession Session { get { return session; } }
        public FacilityController(UserManager<ApplicationUser> userManager,
                                 SignInManager<ApplicationUser> signInManager,
                                 WisdomAppDBContext wisdomAppDBContext, IHttpContextAccessor httpContextAccessor
                                 )
        {
            UserManager = userManager;
            SignInManager = signInManager;
            Context = wisdomAppDBContext;
            session = httpContextAccessor.HttpContext.Session;

        }
        public IActionResult Index()
        {
            PopulateCats();
            return View();
        }
        private void PopulateCats()
        {
            using (Context)
            {
                var F = Context.FacilityCategories
                            .Select(c => new FacilityCategory
                            {
                                Id = c.Id,
                                Category = c.Category
                            })
                            .OrderBy(e => e.Category);

                ViewData["facilityCategories"] = F.ToList();
                ViewData["defaultFacilityCategory"] = F.First();
            }
        }
        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(ReadData().ToDataSourceResult(request));
        }
        public IEnumerable<FacilityCommon> ReadData()
        {
            return GetAll();
        }

        public IList<FacilityCommon> GetAll()
        {
            using (Context)
            {
                var F = Session.GetObjectFromJson<IList<FacilityCommon>>("Facilities");
                if (F == null || UpdateDatabase)
                {
                    var cats = Context.FacilityCategories.ToList();
                    F = Context.FacilitiesCommon.ToList().Select(f =>
                    {
                        var cat = cats.First(c => f.FacilityCategoryId == c.Id);
                        return new FacilityCommon
                        {
                            Id = f.Id,
                            FacilityDescription = f.FacilityDescription,
                            Comment = f.Comment,                           
                            FacilityCategory = new FacilityCategory()
                            { Id = cat.Id, Category = cat.Category }
                        };
                    }).ToList();
                    Session.SetObjectAsJson("Facilities", F);
                }
                return F;
            }
        }

        [HttpPost]
        public ActionResult Create([DataSourceRequest] DataSourceRequest request,
           [Bind(Prefix = "models")] IEnumerable<FacilityCommon> facilities)
        {
            var F = new List<FacilityCommon>();
            if (facilities != null && ModelState.IsValid)
            {
                foreach (var f in facilities)
                {
                    Insert(f);
                    F.Add(f);
                }
            }

            return Json(F.ToDataSourceResult(request, ModelState));
        }
        public void Insert(FacilityCommon F)
        {
            //using (Context)
            //{
                var f = new FacilityCommon();

                f.FacilityDescription = F.FacilityDescription;
                f.Comment = F.Comment;
            f.Status = F.Status;
                f.FacilityCategoryId = F.FacilityCategoryId;
                if (f.FacilityCategoryId == null) //This helps to add the FacCatId
                {
                //    f.FacilityCategoryId = 1;
                //}

                //if (F.FacilityCategoryId != null)
                //{
                    f.FacilityCategoryId = F.FacilityCategory.Id;
                }
                Context.FacilitiesCommon.Add(f);
                Context.SaveChanges();
            //}
        }
        [AcceptVerbs("Post")]
        public ActionResult Update([DataSourceRequest] DataSourceRequest request, FacilityCommon F)
        {
            if (F != null && ModelState.IsValid)
            {
                UpdateData(F);
            }

            return Json(new[] { F }.ToDataSourceResult(request, ModelState));
        }
        public void UpdateData(FacilityCommon F)
        {
            if (!UpdateDatabase)
            {
                var f = Context.FacilitiesCommon.FirstOrDefault(e => e.Id == F.Id);

                if (f != null)
                {
                    f.FacilityDescription = F.FacilityDescription;
                    f.Comment = F.Comment;
                }
                Context.FacilitiesCommon.Attach(f);
                // db.Entry(entity).State = EntityState.Modified;
                Context.SaveChanges();
                Session.SetObjectAsJson("Facilities", F);
            }

        }
        [AcceptVerbs("Post")]
        public ActionResult Delete([DataSourceRequest] DataSourceRequest request, FacilityCommon F)
        {
            if (F != null)
            {
                Destroy(F);
            }

            return Json(new[] { F }.ToDataSourceResult(request, ModelState));
        }
        public void Destroy(FacilityCommon F)
        {
            if (!UpdateDatabase)
            {
                var f = Context.FacilitiesCommon.FirstOrDefault(e => e.Id == F.Id);

                if (f != null)
                {
                    Context.FacilitiesCommon.Remove(f);
                }
                Context.SaveChanges();
                Session.SetObjectAsJson("Facilities", F);
            }

        }
    }
}
