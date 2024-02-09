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
using LectureRoomMgt.Models.Courses;

namespace LectureRoomMgt.Controllers.Courses
{
    public class CourseController : Controller
    {
        public UserManager<ApplicationUser> UserManager { get; }
        public SignInManager<ApplicationUser> SignInManager { get; }
        public WisdomAppDBContext Context { get; }
        private static bool UpdateDatabase = false;
        private ISession session;
        public ISession Session { get { return session; } }
        public CourseController(UserManager<ApplicationUser> userManager,
                                 SignInManager<ApplicationUser> signInManager,
                                 WisdomAppDBContext wisdomAppDBContext, IHttpContextAccessor httpContextAccessor
                                 )
        {
            UserManager = userManager;
            SignInManager = signInManager;
            Context = wisdomAppDBContext;
            session = httpContextAccessor.HttpContext.Session;

        }
        public IActionResult CourseIndex()
        {
            return View();
        }


        public IActionResult LoadCourses([DataSourceRequest]DataSourceRequest request)
        {
            try
            {
                List<CourseVM> courses = (from c in Context.Course
                                        select new CourseVM()
                                        {
                                            Id = c.Id,
                                            Code = c.Code,
                                            CourseName = c.CourseName,
                                            Comment = c.Comment,
                                        }).ToList();

                return Json(courses.ToDataSourceResult(request));
            }
            catch (Exception)
            {
                ModelState.AddModelError("Course", "An error has occured, Please contact administrator !");

                return Json(ModelState);
            }
        }


        [HttpPost]
        //[Authorize(Policy = "CreateBlock")]
        public ActionResult CreateCourse([DataSourceRequest]DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<CourseVM> courses)
        {
            try
            {
                var courseList = new List<Course>();
                var courseVmList = new List<CourseVM>();


                if (ModelState.IsValid && courses != null)
                {
                    foreach (var item in courses.Reverse())
                    {
                        var course = new Course()
                        {
                            Code = item.Code,
                            CourseName = item.CourseName,
                            Comment = item.Comment,
                            Status = "A"
                        };

                        courseList.Add(course);
                        int id = course.Id;
                    }
                    Context.Course.AddRange(courseList);
                    Context.SaveChanges();
                    courseVmList = (from c in courseList
                                    select new CourseVM()
                                   {
                                       Id = c.Id,
                                       Code = c.Code,
                                       CourseName = c.CourseName,
                                       Comment = c.Comment,
                                       Status = c.Status
                                   }).ToList();

                }
                return Json(courseVmList.ToDataSourceResult(request, ModelState));
            }
            catch (Exception)
            {
                ModelState.AddModelError("Course", "An error has occured, Please contact administrator !");

                return Json(courses.ToDataSourceResult(request, ModelState));
            }
        }


        [HttpPost]
        //[Authorize(Policy = "ModifyBlock")]
        public IActionResult EditCourse([DataSourceRequest]DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<CourseVM> courses)
        {
            try
            {
                if (ModelState.IsValid && courses != null)
                {
                    foreach (var item in courses)
                    {
                        var courseObj = Context.Course.Where(x => x.Id == item.Id).FirstOrDefault();

                        if (courseObj != null)
                        {
                            courseObj.CourseName = item.CourseName;
                            courseObj.Code = item.Code;
                            courseObj.Comment = item.Comment;

                            Context.SaveChanges();
                        }
                    }
                }
                return Json(courses.ToDataSourceResult(request, ModelState));
            }
            catch (Exception ex)
            {
                if (ex.InnerException.Message.Contains("Cannot insert duplicate key row in object"))
                {
                    ModelState.AddModelError("Course", "Duplicate record exists !");
                    return Json(courses.ToDataSourceResult(request, ModelState));
                }
                ModelState.AddModelError("Course", "An error has occured, Please contact administrator !");
                return Json(courses.ToDataSourceResult(request, ModelState));
            }
        }


        [HttpPost]
        //[Authorize(Policy = "RemoveBlock")]
        public IActionResult DeleteCourse([DataSourceRequest]DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<CourseVM> courses)
        {
            try
            {
                var coursesList = new List<Course>();

                foreach (var item in courses)
                {
                    var courseObj = Context.Course.Where(x => x.Id == item.Id).FirstOrDefault();
                    coursesList.Add(courseObj);
                }

                if (coursesList.Count > 0)
                {
                    Context.RemoveRange(coursesList);
                    Context.SaveChanges();
                }
                return Json(new[] { courses }.ToDataSourceResult(request, ModelState));
            }
            catch (Exception ex)
            {
                if (ex.InnerException.Message.Contains("The DELETE statement conflicted with the REFERENCE constraint"))
                {
                    ModelState.AddModelError("Course", "Access denied as this row is used by other tables !");
                    return Json(new[] { courses }.ToDataSourceResult(request, ModelState));
                }
                ModelState.AddModelError("Block", "An error has occured, Please contact administrator !");
                return Json(new[] { courses }.ToDataSourceResult(request, ModelState));
            }
        }

    }
}
