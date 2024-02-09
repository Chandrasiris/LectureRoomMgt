using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using LectureRoomMgt.DAL;
using LectureRoomMgt.Models;
using LectureRoomMgt.Models.Reservation;
using LectureRoomMgt.Security;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LectureRoomMgt.Controllers.Reservation.Info
{
    public class ReservationInfoController : Controller
    {
        public UserManager<ApplicationUser> UserManager { get; }
        public SignInManager<ApplicationUser> SignInManager { get; }
        public WisdomAppDBContext Context { get; }
        public IDataProtector protector { get; }
        public IEnumerable<ReservationInfoVM> bookings;


        public ReservationInfoController(UserManager<ApplicationUser> userManager,
                                 SignInManager<ApplicationUser> signInManager,
                                 WisdomAppDBContext wisdomAppDBContext,
                                 IDataProtectionProvider dataProtectionProvider,
                                 DataProtectionPurposeStrings dataProtectionPurposeStrings
                                 )
        {
            UserManager = userManager;
            SignInManager = signInManager;
            Context = wisdomAppDBContext;
            protector = dataProtectionProvider.CreateProtector(dataProtectionPurposeStrings.ReserveInfoId);

        }
        public IActionResult ReservationInfoIndex()
        {

            //var reservations = from f in Context.RoomReservations select new {f.Title,f.Start,f.End };
            //var Res = reservations.AsEnumerable().Select(c => { return new RoomReservationScheduleVM { Title = c.Title, Date = c.Date, Start=c.Start,End=c.End }; }).ToList();
            //ViewBag.Reservations = Res;
            return View();
        }
        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(Reservations().ToDataSourceResult(request));
        }
        private IList<ReservationInfoVM> Reservations()
        {
            var info = Context.RoomReservations.Where(rr => rr.Start >= System.DateTime.Now.Date).Include(r => r.Room).ToList();
            //var info = from r in Context.Rooms
            //           join rr in Context.RoomReservations.Where(rr=> rr.Start >= System.DateTime.Now.Date) on r.Id equals rr.RoomId  into xy 
            //           from s in xy.DefaultIfEmpty()                       
            //           select new
            //           {
            //               r.RoomName,
            //               r.Status,
            //               Id = s == null ? 0 : (s.Id ?? 0),
            //               ResStatus = s == null ? "" : (s.Status ?? string.Empty),
            //               Title = s == null ? "" : (s.Title ?? string.Empty),
            //               Comment = s == null ? "" : (s.Comment ?? string.Empty),
            //               Start = (s.Start),
            //               End = (s.End),
            //               CourseId = s == null ? 0 : (s.CourseId ?? 0),
            //               CourseName = s == null ? "" : (s.Course.CourseName ?? string.Empty),
            //               LecturerId = s == null ? "" : (s.LecturerId ?? string.Empty),
            //               Lecturer = s == null ? "" : (s.Lecturer.FName ?? string.Empty),
            //               FloorName = s == null ? "" : (s.Room.Floor.FloorName ?? string.Empty),
            //               BlockName = s == null ? "" : (s.Room.Floor.Block.BlockName ?? string.Empty),
            //               FacultyName = s == null ? "" : (s.Room.Floor.Block.Faculty.FacultyName ?? string.Empty),
            //           };
            var result = info.AsEnumerable().Select(r =>
            {
                return new ReservationInfoVM
                {
                    ReservationId = r.Id,
                    Title = r.Title != "" ? r.Title : "No reservation",
                    RoomStatus = r.Status,
                    ResStatus = r.ResStatus != "" ? r.ResStatus : "z",
                    Date = r.Start.Date,
                    Start = r.Start,
                    End = r.End,
                    LecturerId = r.LecturerId,
                    LecName = r.Lecturer.FName,
                    CourseId = r.Course.Id,
                    CourseName = r.Course.CourseName,
                    FacultyName = r.Room.Floor.Block.Faculty.FacultyName,
                    BlockName = r.Room.Floor.Block.BlockName,
                    FloorName = r.Room.Floor.FloorName,
                    RoomName = r.Room.RoomName,
                };
            }).ToList();
            return result;
        }
        #region Manage Reservations
        [HttpGet]
        public IActionResult CompletedLoad()
        {
            try
            {
                IEnumerable<ReservationInfoVM> completedBookings = (from rr in Context.RoomReservations
                                                                    join c in Context.Course on rr.CourseId equals c.Id
                                                                    join l in Context.Lecturers on rr.LecturerId equals l.LecturerId
                                                                    join r in Context.Rooms on rr.RoomId equals r.Id
                                                                    join rt in Context.RoomTypes on r.RoomTypeId equals rt.Id
                                                                    join f in Context.Floors on r.FloorId equals f.Id
                                                                    join b in Context.Blocks on f.BlockId equals b.Id
                                                                    join fc in Context.Faculties on b.FacultyId equals fc.Id
                                                                    where rr.Status == "Completed"
                                                                    select new ReservationInfoVM()
                                                                    {
                                                                        EncryptCode = protector.Protect(rr.Id.ToString()),
                                                                        FacultyName = fc.FacultyName,
                                                                        BlockName = b.BlockName,
                                                                        FloorName = f.FloorName,
                                                                        RoomName = r.RoomName,
                                                                        Title = rr.Title,
                                                                        StartEndDate = rr.Start.ToShortDateString() + " " + rr.Start.ToShortTimeString() + " - " + rr.End.ToShortDateString() + " " + rr.End.ToShortTimeString(),
                                                                        CourseName = c.CourseName,
                                                                        LecName = l.FName,
                                                                        RoomStatus = rr.Status,
                                                                        IsSelectedCancelled = false,
                                                                        IsSelectedCompleted = false
                                                                    }).ToList();

                return Json(new { data = completedBookings });
            }
            catch (Exception)
            {
                return Json(new { status = "4" });
            }
        }
        [HttpGet]
        public IActionResult OngoingLoad()
        {
            try
            {
                IEnumerable<ReservationInfoVM> completedBookings = (from rr in Context.RoomReservations
                                                                    join c in Context.Course on rr.CourseId equals c.Id
                                                                    join l in Context.Lecturers on rr.LecturerId equals l.LecturerId
                                                                    join r in Context.Rooms on rr.RoomId equals r.Id
                                                                    join rt in Context.RoomTypes on r.RoomTypeId equals rt.Id
                                                                    join f in Context.Floors on r.FloorId equals f.Id
                                                                    join b in Context.Blocks on f.BlockId equals b.Id
                                                                    join fc in Context.Faculties on b.FacultyId equals fc.Id
                                                                    where rr.Status == "Created"
                                                                    select new ReservationInfoVM()
                                                                    {
                                                                        EncryptCode = protector.Protect(rr.Id.ToString()),
                                                                        FacultyName = fc.FacultyName,
                                                                        BlockName = b.BlockName,
                                                                        FloorName = f.FloorName,
                                                                        RoomName = r.RoomName,
                                                                        Title = rr.Title,
                                                                        StartEndDate = rr.Start.ToShortDateString() + " " + rr.Start.ToShortTimeString() + " - " + rr.End.ToShortDateString() + " " + rr.End.ToShortTimeString(),
                                                                        CourseName = c.CourseName,
                                                                        LecName = l.FName,
                                                                        RoomStatus = rr.Status,
                                                                        IsSelectedCancelled = false,
                                                                        IsSelectedCompleted = false
                                                                    }).ToList();

                return Json(new { data = completedBookings });
            }
            catch (Exception)
            {
                return Json(new { status = "4" });
            }
        }
        [HttpGet]
        public IActionResult CancelledLoad()
        {
            try
            {
                IEnumerable<ReservationInfoVM> completedBookings = (from rr in Context.RoomReservations
                                                                    join c in Context.Course on rr.CourseId equals c.Id
                                                                    join l in Context.Lecturers on rr.LecturerId equals l.LecturerId
                                                                    join r in Context.Rooms on rr.RoomId equals r.Id
                                                                    join rt in Context.RoomTypes on r.RoomTypeId equals rt.Id
                                                                    join f in Context.Floors on r.FloorId equals f.Id
                                                                    join b in Context.Blocks on f.BlockId equals b.Id
                                                                    join fc in Context.Faculties on b.FacultyId equals fc.Id
                                                                    where rr.Status == "Cancelled"
                                                                    select new ReservationInfoVM()
                                                                    {
                                                                        EncryptCode = protector.Protect(rr.Id.ToString()),
                                                                        FacultyName = fc.FacultyName,
                                                                        BlockName = b.BlockName,
                                                                        FloorName = f.FloorName,
                                                                        RoomName = r.RoomName,
                                                                        Title = rr.Title,
                                                                        StartEndDate = rr.Start.ToShortDateString() + " " + rr.Start.ToShortTimeString() + " - " + rr.End.ToShortDateString() + " " + rr.End.ToShortTimeString(),
                                                                        CourseName = c.CourseName,
                                                                        LecName = l.FName,
                                                                        RoomStatus = rr.Status,
                                                                        IsSelectedCancelled = false,
                                                                        IsSelectedCompleted = false
                                                                    }).ToList();

                return Json(new { data = completedBookings });
            }
            catch (Exception)
            {
                return Json(new { status = "4" });
            }
        }

        public IActionResult IndexReservationManage()
        {
            ViewBag.CompletedCount = Context.RoomReservations.Where(x => x.Status == "Completed").Count();
            ViewBag.OngoingCount = Context.RoomReservations.Where(x => x.Status == "Created").Count();
            ViewBag.CancelledCount = Context.RoomReservations.Where(x => x.Status == "Cancelled").Count();
            
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CancelBookingBulk(List<ReservationInfoVM> cancelledList)
        {
            using (var dbContext = Context.Database.BeginTransaction())
            {
                try
                {
                    foreach (var item in cancelledList)
                    {
                        int descryptAccessCode = int.Parse(protector.Unprotect(item.EncryptCode));
                        var roomBook = Context.RoomReservations.Where(x => x.Id == descryptAccessCode).FirstOrDefault();

                        if (roomBook != null)
                        {
                            roomBook.Status = "Cancelled";
                        }
                    }

                    Context.SaveChanges();
                    dbContext.Commit();
                    return Json(new { status = "1" });
                }
                catch (Exception)
                {
                    dbContext.Rollback();
                    return Json(new { status = "4" });
                }

            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CancelBooking([FromBody] string EncryptCode)
        {
            try
            {
                int descryptAccessCode = int.Parse(protector.Unprotect(EncryptCode));
                var roomBook = Context.RoomReservations.Where(x => x.Id == descryptAccessCode).FirstOrDefault();

                if (roomBook != null)
                {
                    roomBook.Status = "Cancelled";
                }

                Context.SaveChanges();
                return Json(new { status = "1" });
            }
            catch (Exception)
            {
                return Json(new { status = "4" });
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CompleteBooking(List<ReservationInfoVM> completedList)
        {
            using (var dbContext = Context.Database.BeginTransaction())
            {
                try
                {
                    foreach (var item in completedList)
                    {
                        int descryptAccessCode = int.Parse(protector.Unprotect(item.EncryptCode));
                        var roomBook = Context.RoomReservations.Where(x => x.Id == descryptAccessCode).FirstOrDefault();

                        if (roomBook != null)
                        {
                            roomBook.Status = "Completed";
                        }
                    }

                    Context.SaveChanges();
                    dbContext.Commit();
                    return Json(new { status = "1" });
                }
                catch (Exception)
                {
                    dbContext.Rollback();
                    return Json(new { status = "4" });
                }

            }
        }
        #endregion
    }
}
