using LectureRoomMgt.DAL;
using LectureRoomMgt.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LectureRoomMgt.Controllers.Reservation.DashboardsAndReports
{
    public class RoomStatusController : Controller
    {
        public UserManager<ApplicationUser> UserManager { get; }
        public SignInManager<ApplicationUser> SignInManager { get; }
        public WisdomAppDBContext Context { get; }



        public RoomStatusController(UserManager<ApplicationUser> userManager,
                                 SignInManager<ApplicationUser> signInManager,
                                 WisdomAppDBContext wisdomAppDBContext
                                 )
        {
            UserManager = userManager;
            SignInManager = signInManager;
            Context = wisdomAppDBContext;

        }
        public IActionResult IndexRoomStatus()
        {
            ViewBag.Fac = Context.Faculties.ToList().OrderBy(c => c.Id);
            ViewBag.Block = Context.Blocks.ToList().OrderBy(c => c.Id);
            ViewBag.Floor = Context.Floors.ToList().OrderBy(c => c.Id);
            ViewBag.rooms = Context.Rooms.Where(x => x.Status == "A").Include(c => c.Floor).Include(c => c.Floor.Block).Include(c => c.Floor.Block.Faculty).Include(c => c.RoomReservations.Where(c => c.Start >= System.DateTime.Now.Date)).ToList().OrderBy(x => x.Floor.Block.Faculty.Id).ThenBy(x => x.Floor.Block.Id).ThenBy(x => x.Floor.Id);
            return View();
        }
        public IActionResult IndexRoomStatuDetails(int facId = 0, string facName = "", string blockName="",int blockId=0)
        {
            ViewBag.rooms = Context.Rooms.Where(x => x.Status == "A").Include(c => c.Floor).Include(c => c.Floor.Block).Include(c => c.Floor.Block.Faculty).Include(p => p.RoomType).Include(p => p.RoomImages).Include(f => f.RoomFacilities).Include(a => a.RoomImageDefaults).Include(c => c.RoomReservations.Where(c => c.Start >= System.DateTime.Now.Date)).ToList().OrderBy(x => x.Floor.Block.Faculty.Id).ThenBy(x => x.Floor.Block.Id).ThenBy(x => x.Floor.Id);
            //ViewBag.Fac = Context.Faculties.ToList().OrderBy(c => c.Id);
            //ViewBag.Block = Context.Blocks.ToList().OrderBy(c => c.Id);
            ViewBag.Floor = Context.Floors.Where(c=>c.BlockId==blockId).ToList().OrderBy(c => c.Id);
            ViewBag.FacId = facId;
            ViewBag.FacName = facName; 
            ViewBag.BlockName = blockName;
            return View();
        }
        }
}
