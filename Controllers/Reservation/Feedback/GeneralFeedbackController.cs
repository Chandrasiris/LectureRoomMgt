using LectureRoomMgt.DAL;
using LectureRoomMgt.Models;
using LectureRoomMgt.Models.Reservation;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LectureRoomMgt.Controllers.Reservation.Feedback
{
    public class GeneralFeedbackController : Controller
    {
        public WisdomAppDBContext Context { get; }
        public UserManager<ApplicationUser> UserManager { get; }
        public SignInManager<ApplicationUser> SignInManager { get; }

        public GeneralFeedbackController( WisdomAppDBContext wisdomAppDBContext, UserManager<ApplicationUser> userManager,
                                 SignInManager<ApplicationUser> signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
            Context = wisdomAppDBContext;           
        }
        public IActionResult GenFeedBkIndex()
        {
            return View();
        }
        public IActionResult submitFeedback(FeedBackGeneral data)
        {
           string user = wisdomId().ToString();
            var d = new FeedBackGeneral();
            d.UserId = user;
            d.Description = data.Description;
            d.ResponseType = data.ResponseType;
            d.SubmitedOn = System.DateTime.Now;
            d.stars = data.stars;

            Context.FeedBackGenerals.Add(d);
            Context.SaveChanges();
            return Redirect("GenFeedBkIndex");
        }
        public async Task<string> wisdomId()
        {
            ApplicationUser applicationUser = await UserManager.GetUserAsync(User);
            return applicationUser.eWisdomId;
        }
    }
}
