using LectureRoomMgt.DAL;
using LectureRoomMgt.Models;
using LectureRoomMgt.Models.Courses;
using LectureRoomMgt.Security;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LectureRoomMgt.Controllers.Lecturers
{
    public class LecturerCourseController : Controller
    {
        public WisdomAppDBContext Context { get; }
        public IDataProtector protector { get; }
        public UserManager<ApplicationUser> UserManager { get; }
        public LecturerCourseController(WisdomAppDBContext wisdomAppDBContext, 
            IDataProtectionProvider dataProtectionProvider,UserManager<ApplicationUser> userManager,
            DataProtectionPurposeStrings dataProtectionPurposeStrings)
        {
            Context = wisdomAppDBContext;            
            UserManager = userManager;
            protector = dataProtectionProvider.CreateProtector(dataProtectionPurposeStrings.LecturerId);
        }
        public IActionResult Index()
        {
            ViewBag.LecId = wisdomId().Result;
            ViewBag.Course = GetCourse();
            return View();
        }
        //public JsonResult GetLecturers()
        //{
        //    using (Context)
        //    {
        //        return Json(Context.Lecturers
        //            .Select(c => new { Id = c.LecturerId, FName = c.FName }).ToList());
        //    }
        //}
        public JsonResult GetCourse()
        {
            using (Context)
            {
                return Json(Context.Course
                    .Select(c => new { Id = c.Id, CourseName = c.CourseName +" ("+ c.Code+")" }).ToList());
            }
        }

        public IActionResult SaveCourse(LecturerCourse lc, int[] Fac)
        {
            using (Context)
            {
                List<int> Ids = Context.LecturerCourses.Where(c => c.LecturerId == lc.LecturerId).Select(c=>c.CourseId).ToList();
                foreach (var cid in lc.CourseIds)
                {
                    if ( Ids.Contains(cid))
                    {
                        break;
                    }
                    var entity = new LecturerCourse();
                    entity.LecturerId = lc.LecturerId;
                    entity.CourseId = cid;
                    entity.RegisteredOn = DateTime.Now;
                    entity.DiscontinuedOn = DateTime.Now;
                    Context.LecturerCourses.Add(entity);
                }                    
                    Context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public IActionResult IndexLecturerCourse()
        {
            return View();
        }
        public async Task<string> wisdomId()
        {
            ApplicationUser applicationUser = await UserManager.GetUserAsync(User);
            return applicationUser.eWisdomId;
        }
    }
}
