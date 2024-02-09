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
using Microsoft.AspNetCore.Authorization;

namespace LectureRoomMgt.Controllers.Reservation.Faculty
{
    public class RoomTypeController : Controller
    {
        public UserManager<ApplicationUser> UserManager { get; }
        public SignInManager<ApplicationUser> SignInManager { get; }
        public WisdomAppDBContext Context { get; }
        private ISession session;
        public ISession Session { get { return session; } }
        public RoomTypeController(UserManager<ApplicationUser> userManager,
                                 SignInManager<ApplicationUser> signInManager,
                                 WisdomAppDBContext wisdomAppDBContext, IHttpContextAccessor httpContextAccessor
                                 )
        {
            UserManager = userManager;
            SignInManager = signInManager;
            Context = wisdomAppDBContext;
            session = httpContextAccessor.HttpContext.Session;

        }
        public IActionResult RoomTypeIndex()
        {
            return View();
        }


        public IActionResult LoadRoomTypes([DataSourceRequest]DataSourceRequest request)
        {
            try
            {
                List<RoomTypeVM> roomTypes = (from f in Context.RoomTypes
                                              select new RoomTypeVM()
                                              {
                                                  Id = f.Id,
                                                  Type = f.Type,
                                                  Comment = f.Comment,
                                                  Status = f.Status
                                              }).ToList();

                return Json(roomTypes.ToDataSourceResult(request));
            }
            catch (Exception)
            {
                ModelState.AddModelError("RoomTypes", "An error has occured, Please contact administrator !");

                return Json(ModelState);
            }
        }


        [HttpPost]
        //[Authorize(Policy = "CreateItemBasic")]
        public ActionResult CreateRoomTypes([DataSourceRequest]DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<RoomTypeVM> roomTypes)
        {
            try
            {
                var RoomTypeVMList = new List<RoomTypeVM>();
                var RoomTypeList = new List<RoomType>();


                if (ModelState.IsValid && roomTypes != null)
                {
                    foreach (var item in roomTypes.Reverse())
                    {

                        var roomtyNew = new RoomType()
                        {
                            Type = item.Type,
                            Comment = item.Comment,
                            Status = "A",
                        };

                        RoomTypeList.Add(roomtyNew);
                    }
                    Context.RoomTypes.AddRange(RoomTypeList);
                    Context.SaveChanges();

                    RoomTypeVMList = (from c in RoomTypeList
                                      select new RoomTypeVM()
                                      {
                                          Id = c.Id,
                                          Type = c.Type,
                                          Comment = c.Comment,
                                          Status = c.Status
                                      }).ToList();
                }
                return Json(RoomTypeVMList.ToDataSourceResult(request, ModelState));
            }
            catch (Exception)
            {
                ModelState.AddModelError("RoomTypes", "An error has occured, Please contact administrator !");

                return Json(roomTypes.ToDataSourceResult(request, ModelState));
            }
        }


        [HttpPost]
        //[Authorize(Policy = "ModifyItemBasic")]
        public IActionResult EditRoomTypes([DataSourceRequest]DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<RoomTypeVM> roomTypes)
        {
            try
            {
                if (ModelState.IsValid && roomTypes != null)
                {
                    foreach (var item in roomTypes)
                    {
                        var roomTypeObj = Context.RoomTypes.Where(x => x.Id == item.Id).FirstOrDefault();

                        if (roomTypeObj != null)
                        {
                            roomTypeObj.Type = item.Type;
                            roomTypeObj.Comment = item.Comment;

                            Context.SaveChanges();
                        }
                    }
                }
                return Json(roomTypes.ToDataSourceResult(request, ModelState));
            }
            catch (Exception ex)
            {
                if (ex.InnerException.Message.Contains("Cannot insert duplicate key row in object"))
                {
                    ModelState.AddModelError("RoomTypes", "Duplicate record exists !");
                    return Json(roomTypes.ToDataSourceResult(request, ModelState));
                }
                ModelState.AddModelError("RoomTypes", "An error has occured, Please contact administrator !");
                return Json(roomTypes.ToDataSourceResult(request, ModelState));
            }
        }


        [HttpPost]
        //[Authorize(Policy = "RemoveItemBasic")]
        public IActionResult DeleteRoomTypes([DataSourceRequest]DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<RoomTypeVM> roomTypes)
        {
            try
            {
                var roomTypesList = new List<RoomType>();

                foreach (var item in roomTypes)
                {
                    var roomTypeObj = Context.RoomTypes.Where(x => x.Id == item.Id).FirstOrDefault();
                    roomTypesList.Add(roomTypeObj);
                }

                if (roomTypesList.Count > 0)
                {
                    Context.RemoveRange(roomTypesList);
                    Context.SaveChanges();
                }
                return Json(new[] { roomTypes }.ToDataSourceResult(request, ModelState));
            }
            catch (Exception ex)
            {
                if (ex.InnerException.Message.Contains("The DELETE statement conflicted with the REFERENCE constraint"))
                {
                    ModelState.AddModelError("RoomTypes", "Access denied as this row is used by other tables !");
                    return Json(new[] { roomTypes }.ToDataSourceResult(request, ModelState));
                }
                ModelState.AddModelError("RoomTypes", "An error has occured, Please contact administrator !");
                return Json(new[] { roomTypes }.ToDataSourceResult(request, ModelState));
            }
        }
    }
}
