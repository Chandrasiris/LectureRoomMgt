using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using LectureRoomMgt.Models.Reservation;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using LectureRoomMgt.Models;
using LectureRoomMgt.DAL;
using Microsoft.AspNetCore.Http;
using LectureRoomMgt.Extensions;
using System.Net.Http.Headers;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace LectureRoomMgt.Controllers.Reservation.Faculty
{
    public class RoomGalleryController : Controller
    {
        public UserManager<ApplicationUser> UserManager { get; }
        public SignInManager<ApplicationUser> SignInManager { get; }
        public WisdomAppDBContext Context { get; }
        private ISession session;
        private readonly IWebHostEnvironment env;
        public ISession Session { get { return session; } }
        public RoomGalleryController(UserManager<ApplicationUser> userManager,
                                 SignInManager<ApplicationUser> signInManager,
                                 WisdomAppDBContext wisdomAppDBContext, IHttpContextAccessor httpContextAccessor, IWebHostEnvironment environment
                                 )
        {
            UserManager = userManager;
            env = environment;
            SignInManager = signInManager;
            Context = wisdomAppDBContext;
            session = httpContextAccessor.HttpContext.Session;
        }
        public IActionResult RoomGalleryIndex()//(string roomName="", int roomId = 0)
        {
           
            return View();
           RoomImageVM viewModel = new RoomImageVM();
            viewModel.RoomImageList =Context.RoomImages.Where(c=>c.RoomId == roomId).ToList();
            viewModel.RoomImage = new RoomImage();
            ViewData["roomName"] = roomName;
            ViewData["roomId"] = roomId;
            return View(viewModel);


        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [RequestSizeLimit(202428800)]        
        public IActionResult Save(IFormFile images,RoomImageVM vm)
        {           
            if (images != null)
            {
                List<string> fileExts = new List<string>();
                var ImageList = new List<RoomImage>();
                foreach (var image in images)
                {
                    var fileContent = ContentDispositionHeaderValue.Parse(image.ContentDisposition);
                    string fileExt = Path.GetExtension(fileContent.FileName.ToString().Trim('"'));
                    var imageItem = new RoomImage()
                    {
                        vm.RoomId,
                        Ext = fileExt,    //URL is Id.fileExt  -ex. 96.jpg                  
                    };
                    Context.RoomImages.Add(imageItem);
                    ImageList.Add(imageItem);
                    fileExts.Add(fileExt);
                }
                if (images.Count() == ImageList.Count)
                {
                    Context.SaveChanges();
                    var Ids = ImageList.Select(c => c.Id).ToList(); //retrieving Ids of inserted images
                    int i = 0;
                    foreach (var image in images)
                    {
                        /* Directory structure for Image gallery
                         wwwroot --> RoomGallery --> {RoomId} --> */
           string folderPath = Path.Combine(env.WebRootPath, "RoomGallery") + $@"/{3}";// vm.RoomId}";
              if (!(Directory.Exists(folderPath)))
              {
                  Directory.CreateDirectory(folderPath);
              }
              string fileName = Ids[i].ToString() + fileExts[i];
              string filePath = Path.Combine(env.WebRootPath, "RoomGallery") + $@"/{3}" + $@"/{fileName}"; //vm.RoomId}" + $@"/{fileName}";
              if (!(System.IO.File.Exists(filePath)))
              {
                  using (var fileStream = new FileStream(filePath, FileMode.Create))
                  {
                      image.CopyTo(fileStream);
                  }
              }
              i++;
          }
      }
  }
  return RedirectToAction("RoomGalleryIndex", "RoomGallery", new { roomName = "hj", roomId = 3 });// vm.RoomName, roomId = vm.RoomId });

            return RedirectToAction("RoomGalleryIndex", "RoomGallery", new { roomName = "hj", roomId = 3 });
        }
        public IActionResult DeletePhoto(int roomId,string roomName, int imageId)
        {
            var photo = Context.RoomImages.Find(imageId);
            if (photo != null)
            {
                Context.RoomImages.Remove(photo);
                Context.SaveChanges();
                int id = photo.Id;
                string fileName = id + photo.Ext;
                string filePath = Path.Combine(env.WebRootPath, "RoomGallery") + $@"/{roomId}" + $@"/{fileName}";
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
            }
            return RedirectToAction("RoomGalleryIndex", "RoomGallery", new { roomId, roomName});
        }


       

    }
}
