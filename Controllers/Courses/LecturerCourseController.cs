using LectureRoomMgt.DAL;
using LectureRoomMgt.Models.Courses;
using LectureRoomMgt.Models.Events;
using LectureRoomMgt.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace LectureRoomMgt.Controllers.Courses
{
    [Authorize]
    public class LecturerCourseController : Controller
    {
        public WisdomAppDBContext Context { get; }
        public IDataProtector Protector { get; }

        public LecturerCourseController(WisdomAppDBContext wisdomAppDBContext,
                               IDataProtectionProvider dataProtectionProvider,
                               DataProtectionPurposeStrings dataProtectionPurposeStrings)
        {
            Context = wisdomAppDBContext;
            Protector = dataProtectionProvider.CreateProtector(dataProtectionPurposeStrings.EventDataId);
        }


        //[HttpGet]
        //public IActionResult LecturerCourseLoad()
        //{
        //    try
        //    {
        //        IEnumerable<LecturerCourse> lecturerCourse = (from e in Context.LecturerCourses
        //                                                    .Include(p => p.Lecturer).Include(o => o.Course)
        //                                                    select new LecturerCourse
        //                                                    {
        //                                                     Id = protector.Protect(e.Id),
        //                                                     CourseId = e.CourseId,
        //                                                     LecturerId = e.LecturerId,
        //                                                     Course = e.Course,
        //                                                     Lecturer = e.Lecturer
        //                                                    }).ToList();

        //        return Json(new { data = lecturerCourse });
        //    }
        //    catch (Exception)
        //    {
        //        return Json(new { status = "4" });
        //    }
        //}


        //[Authorize(Policy = "ViewEvent")]
        //public IActionResult IndexLecturerCourse()
        //{
        //    try
        //    {
        //        ViewBag.Lecturers = new SelectList(Context.Lecturers.ToList(), "LecturerId", "FName");
        //        ViewBag.Courses = new SelectList(Context.Course.ToList(), "Code", "CourseName");

        //        return View();
        //    }
        //    catch (Exception)
        //    {
        //        return View("Error");
        //    }
        //}

        //[Authorize(Policy = "CreateEvent")]
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult CreateLecturerCourse([FromBody] LecturerCourse lecturerCourseObj)
        //{
        //    try
        //    {
        //        var lecturerCourse = new LecturerCourse()
        //        {
        //            CourseId = lecturerCourseObj.CourseId,
        //            LecturerId = lecturerCourseObj.LecturerId
        //        };
        //        Context.LecturerCourses.Add(lecturerCourse);
        //        Context.SaveChanges();

        //        return Json(new { status = "1", lecturerCourseObj });
        //    }
        //    catch (Exception ex)
        //    {
        //        if (ex.InnerException.Message.Contains("Violation of PRIMARY KEY constraint"))
        //        {
        //            return Json(new { status = "3" });
        //        }
        //        return Json(new { status = "4" });
        //    }
        //}

        //[Authorize(Policy = "ModifyEvent")]
        //[HttpGet]
        //public IActionResult EditLecturerCourse(string id)
        //{
        //    try
        //    {
        //        string descryptEventId = protector.Unprotect(id);
        //        var eventObj = Context.MasterEvents.Where(x => x.EventId == descryptEventId).FirstOrDefault();

        //        var masterEvent = new MasterEvent()
        //        {
        //            EncryptEventId = id,
        //            MEventName = eventObj.EventName,
        //        };
        //        return PartialView("_PartialMasterEventEdit", masterEvent);
        //    }
        //    catch (Exception)
        //    {
        //        return Json(new { status = "4" });
        //    }
        //}

        //[Authorize(Policy = "ModifyEvent")]
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult EditLecturerCourse([FromBody] MasterEvent masterEvent)
        //{
        //    try
        //    {
        //        string descryptEventId = protector.Unprotect(masterEvent.EncryptEventId);
        //        var eventObj = Context.MasterEvents.Where(x => x.EventId == descryptEventId).FirstOrDefault();

        //        if (eventObj != null)
        //        {
        //            eventObj.EventName = masterEvent.EventName;
        //            Context.SaveChanges();


        //            masterEvent.EventId = descryptEventId;
        //            return Json(new { status = "1", masterEvent });
        //        }
        //        return Json(new { status = "2" });
        //    }
        //    catch (Exception)
        //    {
        //        return Json(new { status = "4" });
        //    }
        //}

        //[Authorize(Policy = "RemoveEvent")]
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult DeleteLecturerCourse([FromBody] string id)
        //{
        //    try
        //    {
        //        string descryptEventId = protector.Unprotect(id);
        //        var eventObj = Context.MasterEvents.Where(x => x.EventId == descryptEventId).FirstOrDefault();

        //        Context.Remove(eventObj);
        //        Context.SaveChanges();

        //        return Json(new { status = "1" });
        //    }
        //    catch (Exception ex)
        //    {
        //        if (ex.InnerException.Message.Contains("The DELETE statement conflicted with the REFERENCE constraint"))
        //        {
        //            return Json(new { status = "3" });
        //        }
        //        return Json(new { status = "4" });
        //    }
        //}

    }
}