using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using LectureRoomMgt.DAL;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using LectureRoomMgt.Models.Reservation;
using System.Linq;

namespace LectureRoomMgt.Controllers.Reservation.Faculty
{
    public class RoomGalleryController : Controller
    {
        public WisdomAppDBContext Context { get; }
        private readonly IWebHostEnvironment env;
        public RoomGalleryController(WisdomAppDBContext wisdomAppDBContext, IWebHostEnvironment environment)
        {
            env = environment;
            Context = wisdomAppDBContext;
        }
        public IActionResult RoomGalleryIndex(string roomName="", int roomId = 0)
        {
            RoomImageVM viewModel = new RoomImageVM();
            viewModel.RoomImageList = Context.RoomImages.Where(c => c.RoomId == roomId).ToList();
            viewModel.RoomImage = new RoomImage();
            ViewData["roomName"] = roomName;
            ViewData["roomId"] = roomId;
            return View(viewModel);
        }
        [RequestSizeLimit(2000000000)] //B
        public async Task<ActionResult> UploadAsync(IEnumerable<IFormFile> files, int roomId)
        {
            if (files != null)
            {
                foreach (var file in files)
                {
                    var fileContent = ContentDispositionHeaderValue.Parse(file.ContentDisposition); 
                    var fileName = Path.GetFileName(fileContent.FileName.ToString().Trim('"'));
                    var physicalPath = Path.Combine(env.WebRootPath, "RoomGallery", roomId.ToString());
                    if (!(Directory.Exists(physicalPath)))
                    {
                        System.IO.Directory.CreateDirectory(physicalPath);
                    }
                    physicalPath = Path.Combine(physicalPath, fileName);

                    var imageItem = new RoomImage()
                    {
                        RoomId=roomId,
                        Ext = fileName,    //URL is -ext. 96.jpg                  
                    };
                    Context.RoomImages.Add(imageItem);
                    Context.SaveChanges();
                    using (var fileStream = new FileStream(physicalPath, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }
                }
            }            
            return Content("");
        }

        public ActionResult RemoveAsync(string[] fileNames, int roomId)
        {  
            if (fileNames != null)
            {
                foreach (var fullName in fileNames)
                {
                    var fileName = Path.GetFileName(fullName);
                    var physicalPath = Path.Combine(env.WebRootPath, "RoomGallery", roomId.ToString(), fileName);

                    // TODO: Verify user permissions.

                    if (System.IO.File.Exists(physicalPath))
                    {
                        var photo = Context.RoomImages.Where(c=>c.Ext==fileName).First();
                        if (photo != null)
                        {
                            Context.RoomImages.Remove(photo);
                            Context.SaveChanges();
                            System.IO.File.Delete(physicalPath);
                        }
                    }
                }
            }
            return Content("");
        }
        public IActionResult DeletePhoto(int roomId, string roomName, int imageId)
        {
            var photo = Context.RoomImages.Find(imageId);
            if (photo != null)
            {
                Context.RoomImages.Remove(photo);
                Context.SaveChanges();
                var fileName = Path.GetFileName(photo.Ext);
                var filePath = Path.Combine(env.WebRootPath, "RoomGallery", roomId.ToString(), fileName);             
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
            }
            return RedirectToAction("RoomGalleryIndex", "RoomGallery", new { roomId, roomName });
        }

        public IActionResult MakeDefault(int roomId, string roomName, string imageName)
        {
            var photo = Context.RoomImageDefaults.Where(a=>a.RoomId==roomId).FirstOrDefault();
            if (photo != null)
            {
                photo.ImageName = imageName;
            }
            else
            {
                var imageItem = new RoomImageDefault()
                {
                    RoomId = roomId,
                    ImageName = imageName,
                };
                Context.RoomImageDefaults.Add(imageItem);
            }
               
            Context.SaveChanges();

            return RedirectToAction("RoomGalleryIndex", "RoomGallery", new { roomId, roomName });
        }
    }
}
