using LectureRoomMgt.DAL;
using LectureRoomMgt.Models.Events;
using LectureRoomMgt.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace LectureRoomMgt.Controllers
{
    [Authorize]
    public class EventsController : Controller
    {
        public WisdomAppDBContext Context { get; }
        public IDataProtector protector { get; }

        public EventsController(WisdomAppDBContext wisdomAppDBContext,
                               IDataProtectionProvider dataProtectionProvider,
                               DataProtectionPurposeStrings dataProtectionPurposeStrings)
        {
            Context = wisdomAppDBContext;
            protector = dataProtectionProvider.CreateProtector(dataProtectionPurposeStrings.EventDataId);
        }

        #region Events

        [HttpGet]
        public IActionResult MasterEventLoad()
        {
            try
            {
                IEnumerable<MasterEvent> masterEvents = (from e in Context.MasterEvents
                                                         select new MasterEvent
                                                         {
                                                             EncryptEventId = protector.Protect(e.EventId),
                                                             EventId = e.EventId,
                                                             EventName = e.EventName,
                                                         }).ToList();

                return Json(new { data = masterEvents });
            }
            catch (Exception)
            {
                return Json(new { status = "4" });
            }
        }


        [Authorize(Policy = "ViewEvent")]
        public IActionResult IndexMasterEvents()
        {
            try
            {
                ViewBag.Count = Context.MasterEvents.ToList().Count();

                return View();
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        [Authorize(Policy = "CreateEvent")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateMasterEvent([FromBody] MasterEvent eventObj)
        {
            try
            {
                var masterEvent = new MasterEvent()
                {
                    EventId = eventObj.EventId.ToUpper(),
                    EventName = eventObj.EventName,
                };
                Context.MasterEvents.Add(masterEvent);
                Context.SaveChanges();

                eventObj.EventId = eventObj.EventId.ToUpper();
                eventObj.EncryptEventId = protector.Protect(masterEvent.EventId);

                return Json(new { status = "1", eventObj });
            }
            catch (Exception ex)
            {
                if (ex.InnerException.Message.Contains("Violation of PRIMARY KEY constraint"))
                {
                    return Json(new { status = "3" });
                }
                return Json(new { status = "4" });
            }
        }

        [Authorize(Policy = "ModifyEvent")]
        [HttpGet]
        public IActionResult EditMasterEvent(string id)
        {
            try
            {
                string descryptEventId = protector.Unprotect(id);
                var eventObj = Context.MasterEvents.Where(x => x.EventId == descryptEventId).FirstOrDefault();

                var masterEvent = new MasterEvent()
                {
                    EncryptEventId = id,
                    MEventName = eventObj.EventName,
                };
                return PartialView("_PartialMasterEventEdit", masterEvent);
            }
            catch (Exception)
            {
                return Json(new { status = "4" });
            }
        }

        [Authorize(Policy = "ModifyEvent")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditMasterEvent([FromBody] MasterEvent masterEvent)
        {
            try
            {
                string descryptEventId = protector.Unprotect(masterEvent.EncryptEventId);
                var eventObj = Context.MasterEvents.Where(x => x.EventId == descryptEventId).FirstOrDefault();

                if (eventObj != null)
                {
                    eventObj.EventName = masterEvent.EventName;
                    Context.SaveChanges();


                    masterEvent.EventId = descryptEventId;
                    return Json(new { status = "1", masterEvent });
                }
                return Json(new { status = "2" });
            }
            catch (Exception)
            {
                return Json(new { status = "4" });
            }
        }

        [Authorize(Policy = "RemoveEvent")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteMasterEvent([FromBody] string id)
        {
            try
            {
                string descryptEventId = protector.Unprotect(id);
                var eventObj = Context.MasterEvents.Where(x => x.EventId == descryptEventId).FirstOrDefault();

                Context.Remove(eventObj);
                Context.SaveChanges();

                return Json(new { status = "1" });
            }
            catch (Exception ex)
            {
                if (ex.InnerException.Message.Contains("The DELETE statement conflicted with the REFERENCE constraint"))
                {
                    return Json(new { status = "3" });
                }
                return Json(new { status = "4" });
            }
        }
        #endregion

        #region University Events

        [HttpGet]
        public IActionResult EventLoad()
        {
            try
            {
                IEnumerable<UniversityEvent> events = (from e in Context.MasterEvents
                                                   join se in Context.UniversityEvents on e.EventId equals se.EventId
                                                   select new UniversityEvent
                                                   {
                                                       EncryptId = protector.Protect(se.Id.ToString()),
                                                       EventName = e.EventName,
                                                       IsHoliday = se.IsHoliday,
                                                       DateRange = DateTime.ParseExact(se.StartDate.ToShortDateString(), "M/d/yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd") + " " + se.StartDate.ToShortTimeString() + " - " +
                                                                   DateTime.ParseExact(se.EndDate.ToShortDateString(), "M/d/yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd") + " " + se.EndDate.ToShortTimeString(),
                                                       Comment = se.Comment
                                                   }).ToList();

                return Json(new { data = events });
            }
            catch (Exception)
            {
                return Json(new { status = "4" });
            }
        }

        [Authorize(Policy = "ViewUniversityEvent")]
        public IActionResult IndexEvents()
        {
            try
            {
                ViewBag.Events = new SelectList(Context.MasterEvents.OrderBy(x => x.EventName).ToList(), "EventId", "EventName");
                ViewBag.Count = Context.UniversityEvents.ToList().Count();

                return View();
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        [Authorize(Policy = "CreateUniversityEvent")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateUniversity([FromBody] UniversityEvent eventObj)
        {
            try
            {
                DateTime startDateTime = DateTime.Parse(eventObj.DateRange.Substring(0, 19));
                DateTime endDateTime = DateTime.Parse(eventObj.DateRange.Substring(22, 19));

                var universityEvent = new UniversityEvent()
                {
                    EventId = eventObj.EventId,
                    StartDate = startDateTime,
                    EndDate = endDateTime,
                    IsHoliday = eventObj.IsHoliday,
                    Comment = eventObj.Comment
                };
                Context.UniversityEvents.Add(universityEvent);
                Context.SaveChanges();

                eventObj.EncryptId = protector.Protect(universityEvent.Id.ToString());
                eventObj.EventId = null;

                return Json(new { status = "1", eventObj });
            }
            catch (Exception ex)
            {
                if (ex.InnerException.Message.Contains("Cannot insert duplicate key row"))
                {
                    return Json(new { status = "3" });
                }
                return Json(new { status = "4" });
            }
        }

        [Authorize(Policy = "ModifyUniversityEvent")]
        [HttpGet]
        public IActionResult EditEvent(string id)
        {
            try
            {
                int descryptEventId = int.Parse(protector.Unprotect(id));

                var eventObj = (from e in Context.MasterEvents
                                join se in Context.UniversityEvents on e.EventId equals se.EventId
                                where se.Id == descryptEventId
                                select new UniversityEvent
                                {
                                    EventName = e.EventName,
                                    IsHoliday = se.IsHoliday,
                                    DateRange = DateTime.ParseExact(se.StartDate.ToShortDateString(), "M/d/yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd") + " " + se.StartDate.ToShortTimeString() + " - " +
                                               DateTime.ParseExact(se.EndDate.ToShortDateString(), "M/d/yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd") + " " + se.EndDate.ToShortTimeString(),
                                    Comment = se.Comment
                                }).FirstOrDefault();


                var universityEvent = new UniversityEvent()
                {
                    EncryptId = id,
                    MEventName = eventObj.EventName,
                    MIsHoliday = eventObj.IsHoliday,
                    MDateRange = eventObj.DateRange,
                    MComment = eventObj.Comment
                };
                return PartialView("_PartialEventEdit", universityEvent);
            }
            catch (Exception)
            {
                return Json(new { status = "4" });
            }
        }

        [Authorize(Policy = "ModifyUniversityEvent")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditEvent([FromBody] UniversityEvent universityEvent)
        {
            try
            {
                int descryptEventId = int.Parse(protector.Unprotect(universityEvent.EncryptId));
                var eventObj = Context.UniversityEvents.Where(x => x.Id == descryptEventId).FirstOrDefault();

                DateTime startDateTime = DateTime.Parse(universityEvent.DateRange.Substring(0, 19));
                DateTime endDateTime = DateTime.Parse(universityEvent.DateRange.Substring(22, 19));

                if (eventObj != null)
                {
                    eventObj.StartDate = startDateTime;
                    eventObj.EndDate = endDateTime;
                    eventObj.IsHoliday = universityEvent.IsHoliday;
                    eventObj.Comment = universityEvent.Comment;

                    Context.SaveChanges();

                    return Json(new { status = "1", universityEvent });
                }
                return Json(new { status = "2" });
            }
            catch (Exception)
            {
                return Json(new { status = "4" });
            }
        }

        [Authorize(Policy = "RemoveUniversityEvent")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteEvent([FromBody] string id)
        {
            try
            {
                int descryptEventId = int.Parse(protector.Unprotect(id));
                var eventObj = Context.UniversityEvents.Where(x => x.Id == descryptEventId).FirstOrDefault();

                Context.Remove(eventObj);
                Context.SaveChanges();

                return Json(new { status = "1" });
            }
            catch (Exception)
            {
                return Json(new { status = "4" });
            }
        }
        #endregion

        #region Calender

        [HttpGet]
        public IActionResult GetEvents()
        {
            try
            {
                IEnumerable<UniversityEvent> eventList = (from e in Context.MasterEvents
                                                      join se in Context.UniversityEvents on e.EventId equals se.EventId
                                                      select new UniversityEvent
                                                      {
                                                          EventName = e.EventName,
                                                          StringStartDate = se.StartDate.ToString().Substring(0, 10) + 'T' + se.StartDate.ToString().Substring(11, 8),
                                                          StringEndDate = se.EndDate.ToString().Substring(0, 10) + 'T' + se.EndDate.ToString().Substring(11, 8)
                                                      }).ToList();

                return Json(new { eventList });
            }
            catch (Exception)
            {
                return Json(new { eventList = "4" });
            }
        }

        [Authorize(Policy = "ViewCalender")]
        public IActionResult IndexCalender()
        {
            try
            {
                return View();
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        #endregion
    }
}