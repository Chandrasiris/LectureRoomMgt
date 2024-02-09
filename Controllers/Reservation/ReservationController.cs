using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using LectureRoomMgt.DAL;
using LectureRoomMgt.Models;
using LectureRoomMgt.Models.Reservation;
using LectureRoomMgt.Models.Scheduler;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LectureRoomMgt.Controllers.Reservation
{
    public class ReservationController : Controller
    {
        public UserManager<ApplicationUser> UserManager { get; }
        public SignInManager<ApplicationUser> SignInManager { get; }
        public WisdomAppDBContext Context { get; }



        public ReservationController(UserManager<ApplicationUser> userManager,
                                 SignInManager<ApplicationUser> signInManager,
                                 WisdomAppDBContext wisdomAppDBContext
                                 )
        {
            UserManager = userManager;
            SignInManager = signInManager;
            Context = wisdomAppDBContext;

        }
        public  IActionResult  ReservationIndex(int roomId=0)
        {
            //ViewBag.Lecturers = new SelectList(Context.Lecturers.ToList(), "LecturerId", "FName");
            ViewBag.RoomId = roomId;
            ViewBag.LecId = wisdomId();
            return View();
        }
        #region LecturerRoomBookingDashboard

        //public ActionResult IndexBookRooms(int floorId)
        //{
        //    ViewBag.rooms = Context.Rooms.Where(x => x.FloorId == floorId).Include(a => a.RoomType).Include(p => p.RoomImages).Include(f => f.RoomFacilities).ToList();
        //    return View();
        //}
        public ActionResult IndexRoomDetails(int roomId)
        {
            ViewBag.RoomGallery = Context.RoomImages.Where(p => p.RoomId == roomId);
            ViewBag.roomId = roomId.ToString();
            return View();
        }
        public ActionResult IndexRoomCurrentBookingDetails(int roomId)
        {            
            ViewBag.roomId = roomId.ToString();
            return View();
        }
        public virtual JsonResult Overview_Read([DataSourceRequest] DataSourceRequest request, int roomId)
        {
            
            return Json(GetTasks(roomId ).ToDataSourceResult(request));
        }
        private  IList<Meeting> GetTasks(int roomId)
        {
            if (roomId==0)
            {
                var reservations0 = Context.RoomReservations.Where(x => x.Start >= System.DateTime.Now).ToList();
                IList<Meeting> schedulerTasks0 = new List<Meeting>();
                foreach (var item in reservations0)
                {
                    schedulerTasks0.Add(
                    new Meeting { MeetingID = (int)item.Id, Title = item.Title, Image = "physics.png", Start = new DateTime(item.Start.Year, item.Start.Month, item.Start.Day, item.Start.Hour, item.Start.Minute, item.Start.Second), End = new DateTime(item.End.Year, item.End.Month, item.End.Day, item.End.Hour, item.End.Minute, item.End.Second), RecurrenceRule = item.RecurrenceRule, Attendee = 1 });
                }
                return schedulerTasks0;
            }
            var reservations = Context.RoomReservations.Where(x => x.RoomId == roomId && x.Start > System.DateTime.Now).ToList();
            IList<Meeting> schedulerTasks = new List<Meeting>();
            foreach (var item in reservations)
            {
                schedulerTasks.Add(
                new Meeting { MeetingID = (int)item.Id, Title = item.Title, Image = "physics.png", Start = new DateTime(item.Start.Year, item.Start.Month, item.Start.Day,item.Start.Hour, item.Start.Minute, item.Start.Second), End = new DateTime(item.End.Year, item.End.Month, item.End.Day, item.End.Hour, item.End.Minute, item.End.Second), RecurrenceRule = item.RecurrenceRule, Attendee = 1 });
            }
            return schedulerTasks;
        }
        #endregion
        public async Task<string> wisdomId()
        {
            ApplicationUser applicationUser = await UserManager.GetUserAsync(User);
            return applicationUser.eWisdomId;
        }
        [HttpPost]
        public ActionResult Reserve(RoomReservationVM r)
        {
            return View("ReservationIndex");

        }
        public ActionResult Schedules_Read([DataSourceRequest] DataSourceRequest request, int roomId=0, string lecId="")
        {
            return Json(GetAll(roomId, lecId).ToDataSourceResult(request));
        }
        public virtual IQueryable<RoomReservationVM> GetAll(int roomId, string lecId)
        {
            return GetAllRes(roomId, lecId).AsQueryable();
        }
        private IList<RoomReservationVM> GetAllRes(int roomId, string lecId)
        {
            if (roomId == 0)
            {
                var reservations0 = Context.RoomReservations.Include(c => c.Room).ToList().Select(x => new RoomReservationVM //status
                {
                    RoomName = x.Room.RoomName,
                    ReservationId = x.Id,
                    Title = x.Title,
                    Start = DateTime.SpecifyKind(x.Start, DateTimeKind.Utc),
                    End = DateTime.SpecifyKind(x.End, DateTimeKind.Utc),
                    StartTimezone = x.StartTimezone,
                    EndTimezone = x.EndTimezone,
                    Description = x.Description,
                    IsAllDay = x.IsAllDay,
                    RecurrenceRule = x.RecurrenceRule,
                    RecurrenceException = x.RecurrenceException,
                    RecurrenceID = x.RecurrenceID,
                    Image = "favicon.jpg"
                }).ToList();
                return reservations0;
            }
            var reservations = Context.RoomReservations.Where(x => x.RoomId == roomId && x.LecturerId == lecId).ToList().Select(x => new RoomReservationVM //status
            {
                ReservationId = x.Id,
                Title = x.Title,
                Start = DateTime.SpecifyKind(x.Start, DateTimeKind.Utc),
                End = DateTime.SpecifyKind(x.End, DateTimeKind.Utc),
                StartTimezone = x.StartTimezone,
                EndTimezone = x.EndTimezone,
                Description = x.Description,
                IsAllDay = x.IsAllDay,
                RecurrenceRule = x.RecurrenceRule,
                RecurrenceException = x.RecurrenceException,
                RecurrenceID = x.RecurrenceID,
                Image = "favicon.jpg"
            }).ToList();
            return reservations;
        }
        public virtual JsonResult Schedules_Create([DataSourceRequest] DataSourceRequest request, int roomId, string lecId, int CourseId, RoomReservationVM res)
        {
            if (ModelState.IsValid)
            {
                Insert(res, roomId, lecId, CourseId, ModelState);
            }

            return Json(new[] { res }.ToDataSourceResult(request, ModelState));
        }


        public virtual void Insert(RoomReservationVM res, int roomId, string lecId, int CourseId, ModelStateDictionary modelState)
        {
            if (ValidateModel(res, modelState))
            {
                using (var db = Context)
                {
                    if (string.IsNullOrEmpty(res.Title))
                    {
                        res.Title = "";
                    }
                    var R = new RoomReservation
                    {
                        RoomId = roomId,
                        Start = res.Start,
                        End = res.End,
                        Status = "Created",
                        LecturerId = lecId,
                        CourseId = CourseId,
                        Title = res.Title,
                        Description = res.Description,
                        IsAllDay = res.IsAllDay,
                        RecurrenceRule = res.RecurrenceRule,
                        RecurrenceException = res.RecurrenceException
                    };
                    db.RoomReservations.Add(R);
                    db.SaveChanges();
                }
            }
        }


        public virtual JsonResult Schedules_Update([DataSourceRequest] DataSourceRequest request, int roomId, string lecId, int CourseId, RoomReservationVM res)
        {
            //if (ModelState.IsValid)
            //{
            var roomRes = Context.RoomReservations.Where(x => x.Id == res.ReservationId).FirstOrDefault();

            if (roomRes != null)
            {
                roomRes.RoomId = roomId;
                roomRes.Start = res.Start;
                roomRes.End = res.End;
                roomRes.LecturerId = lecId;
                roomRes.CourseId = CourseId;
                roomRes.Title = res.Title;
                roomRes.Description = res.Description;
                roomRes.IsAllDay = res.IsAllDay;
                roomRes.RecurrenceRule = res.RecurrenceRule;
                roomRes.RecurrenceException = res.RecurrenceException;

                Context.SaveChanges();
            }
            //}
            return Json(new[] { res }.ToDataSourceResult(request));
        }


        public virtual JsonResult Schedules_Destroy([DataSourceRequest] DataSourceRequest request, int roomId, string lecId, int CourseId, RoomReservationVM res)
        {
            if (ModelState.IsValid)
            {
                var roomRes = Context.RoomReservations.Where(x => x.Id == res.ReservationId).FirstOrDefault();

                if (roomRes != null)
                {
                    Context.RoomReservations.Remove(roomRes);
                    Context.SaveChanges();
                }
            }
            return Json(new[] { res }.ToDataSourceResult(request, ModelState));
        }



        private bool ValidateModel(RoomReservationVM appointment, ModelStateDictionary modelState)
        {
            if (appointment.Start > appointment.End)
            {
                modelState.AddModelError("errors", "End date must be greater or equal to Start date.");
                return false;
            }
            return true;
        }
        public JsonResult GetFaculties()
        {
            using (Context)
            {
                return Json(Context.Faculties // .where status
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
        public JsonResult GetLecturers()
        {
            using (Context)
            {
                return Json(Context.Lecturers // .where status
                    .Select(c => new { Id = c.LecturerId, LecturerName = c.FName }).ToList());
            }

        }
        public JsonResult GetCourses(int? LecturerId)
        {
            using (Context)
            {
                return Json(Context.Course // .where status
                    .Select(c => new { Id = c.Id, CourseName = c.CourseName }).ToList());
            }

        }


        public JsonResult GetCoursesbyLec(string LecturerId)
        {
            using (Context)
            {
                var courses = (from lc in Context.LecturerCourses
                               join c in Context.Course
                               on lc.CourseId equals c.Id
                               where lc.LecturerId == LecturerId
                               select new { CourseName = c.CourseName, Id = c.Id }
                              ).ToList();
                return Json(courses);
            }
        }


        public ActionResult IndexBookRooms(int facId, int blockId, int floorId)
        {
            ViewBag.rooms = Context.Rooms.Where(x => x.FloorId == floorId).Include(a => a.RoomType).Include(p => p.RoomImages).Include(f => f.RoomFacilities).Include(a=>a.RoomImageDefaults).Include(c=>c.RoomReservations).ToList();

           
            ViewBag.FacultyId = facId;
            ViewBag.BlockId = blockId;
            ViewBag.FloorId = floorId;
            

            return View();
        }


        #region Lecturer

        public async Task<IActionResult> ReservationIndexLecturer(int facId, int blockId, int floorId, int roomId)
        {
            ApplicationUser user = await UserManager.FindByNameAsync(User.Identity.Name);

            ViewBag.LecturerId = user.eWisdomId;
            ViewBag.FacultyId = facId;
            ViewBag.BlockId = blockId;
            ViewBag.FloorId = floorId;
            ViewBag.RoomId = roomId;

            var courses = (from lc in Context.LecturerCourses
                           join c in Context.Course
                           on lc.CourseId equals c.Id
                           where lc.LecturerId == user.eWisdomId
                           select new { CourseName = c.CourseName, Id = c.Id }
                          ).ToList();

            ViewBag.Courses = new SelectList(courses, "Id", "CourseName");

            return View();
        }

        #endregion

    }
}
