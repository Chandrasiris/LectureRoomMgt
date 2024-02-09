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
    public class FacilityCategoryController : Controller
    {
        public UserManager<ApplicationUser> UserManager { get; }
        public SignInManager<ApplicationUser> SignInManager { get; }
        public WisdomAppDBContext Context { get; }
        private static bool UpdateDatabase = false;
        private ISession session;
        public ISession Session { get { return session; } }
        public FacilityCategoryController(UserManager<ApplicationUser> userManager,
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
            return View();
        }

        public IActionResult LoadFacCats([DataSourceRequest] DataSourceRequest request)
        {
            try
            {
                List<FacilityCategory> facilityCategories = (from f in Context.FacilityCategories
                                                             select new FacilityCategory()
                                                             {
                                                                 Id = f.Id,
                                                                 Category = f.Category,
                                                                 Comment = f.Comment,
                                                             }).ToList();

                return Json(facilityCategories.ToDataSourceResult(request));
            }
            catch (Exception)
            {
                ModelState.AddModelError("FacilityCats", "An error has occured, Please contact administrator !");

                return Json(ModelState);
            }
        }


        [HttpPost]
        //[Authorize(Policy = "CreateItemBasic")]
        public ActionResult CreateFacCats([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")] IEnumerable<FacilityCategory> facilityCategories)
        {
            try
            {
                var FacCatsVMList = new List<FacilityCategoryVM>();
                var FacCatsList = new List<FacilityCategory>();


                if (ModelState.IsValid && facilityCategories != null)
                {
                    foreach (var item in facilityCategories.Reverse())
                    {

                        var facCatNew = new FacilityCategory()
                        {
                            Category = item.Category,
                            Comment = item.Comment,
                        };

                        FacCatsList.Add(facCatNew);
                    }
                    Context.FacilityCategories.AddRange(FacCatsList);
                    Context.SaveChanges();

                    FacCatsVMList = (from c in FacCatsList
                                     select new FacilityCategoryVM()
                                     {
                                         Id = c.Id,
                                         Category = c.Category,
                                         Comment = c.Comment,
                                     }).ToList();
                }
                return Json(FacCatsVMList.ToDataSourceResult(request, ModelState));
            }
            catch (Exception)
            {
                ModelState.AddModelError("FacilityCats", "An error has occured, Please contact administrator !");

                return Json(facilityCategories.ToDataSourceResult(request, ModelState));
            }
        }


        [HttpPost]
        //[Authorize(Policy = "ModifyItemBasic")]
        public IActionResult EditFacCats([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")] IEnumerable<FacilityCategory> facilityCategories)
        {
            try
            {
                if (ModelState.IsValid && facilityCategories != null)
                {
                    foreach (var item in facilityCategories)
                    {
                        var facCatsObj = Context.FacilityCategories.Where(x => x.Id == item.Id).FirstOrDefault();

                        if (facCatsObj != null)
                        {
                            facCatsObj.Category = item.Category;
                            facCatsObj.Comment = item.Comment;

                            Context.SaveChanges();
                        }
                    }
                }
                return Json(facilityCategories.ToDataSourceResult(request, ModelState));
            }
            catch (Exception ex)
            {
                if (ex.InnerException.Message.Contains("Cannot insert duplicate key row in object"))
                {
                    ModelState.AddModelError("FacilityCats", "Duplicate record exists !");
                    return Json(facilityCategories.ToDataSourceResult(request, ModelState));
                }
                ModelState.AddModelError("FacilityCats", "An error has occured, Please contact administrator !");
                return Json(facilityCategories.ToDataSourceResult(request, ModelState));
            }
        }


        [HttpPost]
        //[Authorize(Policy = "RemoveItemBasic")]
        public IActionResult DeleteFacCats([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")] IEnumerable<FacilityCategory> facilityCategories)
        {
            try
            {
                var facCatsList = new List<FacilityCategory>();

                foreach (var item in facilityCategories)
                {
                    var facCatsObj = Context.FacilityCategories.Where(x => x.Id == item.Id).FirstOrDefault();
                    facCatsList.Add(facCatsObj);
                }

                if (facCatsList.Count > 0)
                {
                    Context.RemoveRange(facCatsList);
                    Context.SaveChanges();
                }
                return Json(new[] { facilityCategories }.ToDataSourceResult(request, ModelState));
            }
            catch (Exception ex)
            {
                if (ex.InnerException.Message.Contains("The DELETE statement conflicted with the REFERENCE constraint"))
                {
                    ModelState.AddModelError("FacilityCats", "Access denied as this row is used by other tables !");
                    return Json(new[] { facilityCategories }.ToDataSourceResult(request, ModelState));
                }
                ModelState.AddModelError("FacilityCats", "An error has occured, Please contact administrator !");
                return Json(new[] { facilityCategories }.ToDataSourceResult(request, ModelState));
            }
        }

    }
}
