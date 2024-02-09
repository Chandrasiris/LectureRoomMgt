using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LectureRoomMgt.Controllers.Reservation.Rooms
{
    public class Uploader : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult Submit(IEnumerable<IFormFile> files)
        {
            IEnumerable<string> fileInfo = new List<string>();

            if (files != null)
            {
                fileInfo = GetFileInfo(files);
            }

            return View("Result", fileInfo);
        }

        private IEnumerable<string> GetFileInfo(IEnumerable<IFormFile> files)
        {
            List<string> fileInfo = new List<string>();

            foreach (var file in files)
            {
                var fileContent = ContentDispositionHeaderValue.Parse(file.ContentDisposition);
                var fileName = Path.GetFileName(fileContent.FileName.ToString().Trim('"'));

                fileInfo.Add(string.Format("{0} ({1} bytes)", fileName, file.Length));
            }

            return fileInfo;
        }
    }
}
