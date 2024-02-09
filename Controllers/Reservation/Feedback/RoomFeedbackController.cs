using LectureRoomMgt.DAL;
using LectureRoomMgt.Models;
using LectureRoomMgt.Models.Reservation;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LectureRoomMgt.Controllers.Reservation.Feedback
{
    public class RoomFeedbackController : Controller
    {
        public WisdomAppDBContext Context { get; }
        public UserManager<ApplicationUser> UserManager { get; }
        public SignInManager<ApplicationUser> SignInManager { get; }

        public RoomFeedbackController(WisdomAppDBContext wisdomAppDBContext, UserManager<ApplicationUser> userManager,
                                 SignInManager<ApplicationUser> signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
            Context = wisdomAppDBContext;
        }
        public IActionResult RoomFeedBkIndex()
        {
            return View();
        }
        public IActionResult submitFeedback(FeedBackRoom data)
        {
            string user = wisdomId().ToString();
            var d = new FeedBackRoom();
            d.UserId = user;
            d.RoomId = data.RoomId;
            d.Description = data.Description;
            d.ResponseType = data.ResponseType;
            d.SubmitedOn = System.DateTime.Now;
            d.stars = data.stars;

            Context.FeedBackRooms.Add(d);
            Context.SaveChanges();
            return Redirect("RoomFeedBkIndex");
        }
        public async Task<string> wisdomId()
        {
            ApplicationUser applicationUser = await UserManager.GetUserAsync(User);
            return applicationUser.eWisdomId;
        }
    }
}
