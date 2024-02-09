using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using LectureRoomMgt.Models.Scheduler;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using LectureRoomMgt.DAL;
using LectureRoomMgt.Models;
using LectureRoomMgt.Models.Reservation;

namespace LectureRoomMgt.Controllers.Reservation
{
    public class _SchedulerController : Controller
    {
        public WisdomAppDBContext Context { get; }
        public UserManager<ApplicationUser> UserManager { get; }

        private ISchedulerEventService<TaskViewModel> taskService;

        public _SchedulerController(
            ISchedulerEventService<TaskViewModel> schedulerTaskService, UserManager<ApplicationUser> userManager,
                              WisdomAppDBContext wisdomAppDBContext)
        {
            taskService = schedulerTaskService; 
            Context = wisdomAppDBContext;
            UserManager = userManager;
        }

        public IActionResult SchedulerIndex()
        {
            return View();
        }

        public virtual JsonResult Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(taskService.GetAll().ToDataSourceResult(request));
        }

        public virtual JsonResult Destroy([DataSourceRequest] DataSourceRequest request, TaskViewModel task)
        {
            if (ModelState.IsValid)
            {
                taskService.Delete(task, ModelState);
            }

            return Json(new[] { task }.ToDataSourceResult(request, ModelState));
        }

        public virtual JsonResult Create([DataSourceRequest] DataSourceRequest request, TaskViewModel task,string LecturerId)//, RoomReservationVM r )
        {
            if (ModelState.IsValid)
            {
                taskService.Insert(task, ModelState);
            }

            return Json(new[] { task }.ToDataSourceResult(request, ModelState));
        }

        public virtual JsonResult Update([DataSourceRequest] DataSourceRequest request, TaskViewModel task)
        {
            //example custom validation:
            if (task.Start.Hour < 8 || task.Start.Hour > 22)
            {
                ModelState.AddModelError("start", "Start date must be in working hours (8h - 22h)");
            }

            if (ModelState.IsValid)
            {
                taskService.Update(task, ModelState);
            }

            return Json(new[] { task }.ToDataSourceResult(request, ModelState));
        }
    }
}
