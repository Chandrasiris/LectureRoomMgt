using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LectureRoomMgt.DAL;
using LectureRoomMgt.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using LectureRoomMgt.Models.Reservation;
using Microsoft.EntityFrameworkCore;
using LectureRoomMgt.Models.Scheduler;
using LectureRoomMgt.Models.Lecturers;

namespace LectureRoomMgt.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public WisdomAppDBContext Context { get; }
        public UserManager<ApplicationUser> UserManager { get; }
        public HomeController(UserManager<ApplicationUser> userManager,
                              WisdomAppDBContext wisdomAppDBContext)
        {
            Context = wisdomAppDBContext;
            UserManager = userManager;
        }
        const string SessionSchoolShortName = "_UniversityShortName";
        const string SessionUserType = "_UserType";

        public async Task<IActionResult> Index()
        {
            HttpContext.Session.SetString(SessionSchoolShortName, "NAME");
            HttpContext.Session.SetString(SessionUserType, "USER_TYPE");

            ApplicationUser user = await UserManager.FindByNameAsync(User.Identity.Name);
            var userType = "N";

            if (user != null)
            {
                ViewBag.UserType = user.UserType;
                userType = user.UserType;

                HttpContext.Session.SetString(SessionUserType, user.UserType);
            }
            else
            {
                ViewBag.UserType = "L";
                userType = "L";

                HttpContext.Session.SetString(SessionUserType, "L");
            }

            var schoolInfo = Context.MasterCompanies.FirstOrDefault();

            if (schoolInfo != null)
            {
                HttpContext.Session.SetString(SessionSchoolShortName, schoolInfo.ShortName);
            }


            if (userType == "I")
            {
                ViewBag.LecturerCount = Context.Lecturers.Where(x => x.LecturerStatus == "A").ToList().Count;
                ViewBag.CourseCount = Context.Course.ToList().Count;
                ViewBag.StaffCount = Context.Employees.ToList().Count;
                ViewBag.FacultyCount = Context.Faculties.ToList().Count;
                ViewBag.BlockCount = Context.Blocks.ToList().Count;
                ViewBag.FloorsCount = Context.Floors.ToList().Count;

                ViewBag.EventCount = Context.UniversityEvents.Where(x => x.StartDate.Date >= DateTime.Now.Date).ToList().Count;
                ViewBag.UsersCount = Context.TempLogins.ToList().Count;

            }
            return View();
        }


        public async Task<IActionResult> IndexLecturer()
        {
            ApplicationUser user = await UserManager.FindByNameAsync(User.Identity.Name);

            ViewBag.UserType = user.UserType;

            var schoolInfo = Context.MasterCompanies.FirstOrDefault();

            HttpContext.Session.SetString(SessionSchoolShortName, "NAME");
            if (schoolInfo != null)
            {
                HttpContext.Session.SetString(SessionSchoolShortName, schoolInfo.ShortName);
            }

            ViewBag.Faculties = new SelectList(Context.Faculties.ToList(), "Id", "FacultyName");
            ViewBag.BookedRooms = Context.RoomReservations.Where(x => x.LecturerId == user.eWisdomId && x.Start.Date >= DateTime.Now.Date).Include(x => x.Room).OrderByDescending(c => c.Start).ToList();

            var lecturerObj = Context.Lecturers.Where(x => x.Username == User.Identity.Name).FirstOrDefault();

            if (lecturerObj == null)
            {
                lecturerObj = new Lecturer()
                {
                    LecturerId = user.eWisdomId,
                    JoinedDate = DateTime.Now,
                    Dob = DateTime.Now
                };

                return RedirectToAction("RegisterLecturer", "Lecturer", lecturerObj);
            }
            else
            {
                var viewModel = new GridLayoutData()
                {
                    SelectedDate = DateTime.Today,
                    Bookings = GetBookings(DateTime.Today),
                };
                var x = new BlockVM();
                x.GridLayoutData = viewModel;
                return View(x);
            }
        }


        public IActionResult LoadBlocksByFaculty(string facId)
        {
            ViewBag.BlockList = Context.Blocks.Where(x => x.FacultyId == int.Parse(facId)).Include(p => p.Floors).ToList();
            var blocksVM = new BlockVM();
            return PartialView("_PartialBlocksLoad", blocksVM);
        }

        public JsonResult GetData(DateTime selectedDate)
        {
            return new JsonResult(new { Bookings = GetBookings(selectedDate) });
        }
        private List<MyReservations> GetBookings(DateTime selectedDate)
        {
            selectedDate = DateTime.Parse("2023-05-17 09:00:00.0000000");
            var ret = wisdomId();
            string user = ret.Result;

            using (Context)
            {
                List<MyReservations> bookings = (
                    from c in Context.RoomReservations
                    where c.LecturerId == "L638198121" && c.Start.Year == selectedDate.Year && c.Start.Month == selectedDate.Month
                    select new MyReservations()
                    {
                        RoomName = c.Room.RoomName,
                        CourseCode = c.CourseId.ToString(),
                        CourseName = c.Course.CourseName,
                        Description = c.Description,
                        Start = c.Start,
                        End = c.End
                    }).OrderBy(a => a.Start).ToList();
                ViewBag.cnt = bookings.Count;
                var data = Context.RoomReservations.Where(c => c.LecturerId == "L638198121");
                var to = data.OrderByDescending(c => c.Start).First();
                var from = data.OrderByDescending(c => c.Start).Last();
                ViewBag.to = to.Start.ToShortDateString();
                ViewBag.from = from.Start.ToShortDateString();
                ViewBag.total = data.Count();
                ViewBag.active = data.Where(c => c.Status == "A").Count();
                ViewBag.success = data.Where(c => c.Status == "C").Count();
                ViewBag.cancel = data.Where(c => c.Status == "X").Count();

                var getStores = (from c in data
                                 group c by c.Start.DayOfWeek into days
                                 select new
                                 {
                                     day = days.Key,
                                     Count = days.Count()
                                 });
                return bookings;
            }
        }
        public async Task<string> wisdomId()
        {
            ApplicationUser applicationUser = await UserManager.GetUserAsync(User);
            string user = applicationUser.eWisdomId;
            return user;
        }

        public IActionResult IndexStudent()
        {
            return View();
        }

        public IActionResult IndexStaffAssist()
        {
            return View();
        }
    }
}
