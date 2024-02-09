using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using LectureRoomMgt.DAL;
using LectureRoomMgt.Models;
using LectureRoomMgt.Models.Lecturers;
using LectureRoomMgt.Models.ViewModels;
using LectureRoomMgt.Security;

namespace LectureRoomMgt.Controllers.Lecturers
{
    [Authorize]
    public class LecturerController : Controller
    {
        public WisdomAppDBContext Context { get; }
        public IWebHostEnvironment WebHostEnvironment { get; }
        public IDataProtector protector { get; }

        public UserManager<ApplicationUser> UserManager { get; }

        public LecturerController(WisdomAppDBContext wisdomAppDBContext,
                                IWebHostEnvironment webHostEnvironment,
                                IDataProtectionProvider dataProtectionProvider,
                                UserManager<ApplicationUser> userManager,
                                DataProtectionPurposeStrings dataProtectionPurposeStrings)
        {
            Context = wisdomAppDBContext;
            WebHostEnvironment = webHostEnvironment;
            UserManager = userManager;
            protector = dataProtectionProvider.CreateProtector(dataProtectionPurposeStrings.LecturerId);

            GetDropDownLists();
        }

        List<MasterTitle> titles = null;
        List<MasterGender> genders = null;

        private void GetDropDownLists()
        {
            titles = Context.MasterTitles.OrderBy(x => x.Title).ToList();
            genders = Context.MasterGenders.OrderBy(x => x.Gender).ToList();

        }

        #region Lecturer Profile

        [Authorize(Policy = "LecturersOnly")]
        public async Task<string> wisdomId()
        {
            ApplicationUser applicationUser = await UserManager.GetUserAsync(User);
            return applicationUser.eWisdomId;
        }
        public async Task<ActionResult> RegisterLecturer()
        {
            try
            {
                var user = await UserManager.FindByNameAsync(User.Identity.Name);

                ViewBag.Titles = new SelectList(titles, "Title", "Title");
                ViewBag.Gender = new SelectList(genders, "Gender", "Gender");


                var tempLoginObj = Context.TempLogins.Where(x => x.User == User.Identity.Name).FirstOrDefault();
                var lecturerObj = Context.Lecturers.Where(x => x.Username == User.Identity.Name).FirstOrDefault();

                if (lecturerObj != null)
                {
                    return View(lecturerObj);
                }


                lecturerObj = new Lecturer()
                {
                    LecturerId = user.eWisdomId,
                    JoinedDate = DateTime.Now,
                    Dob = DateTime.Now
                };

                return View(lecturerObj);
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        [Authorize(Policy = "LecturersOnly")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegisterLecturer(Lecturer lecturer)
        {
            try
            {
                var tempLoginObj = Context.TempLogins.Where(x => x.User == User.Identity.Name).FirstOrDefault();
                var lecturerObj = Context.Lecturers.Where(x => x.AccessCode == tempLoginObj.AccessCode).FirstOrDefault();
                string LecId = wisdomId().Result;//"L" + DateTime.Now.Ticks.ToString().Substring(0, 9);
                if (lecturerObj != null)
                {
                    lecturerObj.Title = lecturer.Title;
                    lecturerObj.JoinedDate = lecturer.JoinedDate.Date;
                    lecturerObj.FName = lecturer.FName;
                    lecturerObj.SName = lecturer.SName;
                    lecturerObj.Dob = lecturer.Dob;
                    lecturerObj.Email = lecturer.Email;
                    lecturerObj.Mobile = lecturer.Mobile;
                    lecturerObj.HomeTel = lecturer.HomeTel;
                    lecturerObj.OfficeTel = lecturer.OfficeTel;
                    lecturerObj.Gender = lecturer.Gender;
                    lecturerObj.Qualifications = lecturer.Qualifications;
                    lecturerObj.Username = User.Identity.Name;

                    if (lecturer.IsImageChange || lecturer.IsImageDeleted)
                    {
                        string fileExtension = null;
                        if (lecturer.LecturerImageFile != null)
                        {
                            fileExtension = Path.GetExtension(lecturer.LecturerImageFile.FileName);
                            string filePath = Path.Combine(WebHostEnvironment.WebRootPath, $@"Resources/Uploads/Lecturers") + $@"/{lecturerObj.LecturerId + fileExtension}";

                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                lecturer.LecturerImageFile.CopyTo(stream);
                            }
                        }
                        else
                        {
                            string filePath = Path.Combine(WebHostEnvironment.WebRootPath, $@"Resources/Uploads/Lecturers") + $@"/{lecturerObj.ProfileImgPath}";

                            if (System.IO.File.Exists(filePath))
                            {
                                System.IO.File.Delete(Path.Combine(filePath));
                            }
                        }
                        lecturerObj.ProfileImgPath = lecturer.LecturerImageFile != null ? lecturerObj.LecturerId + fileExtension : null;
                    }
                }
                else
                {

                    var LecturerNew = new Lecturer()
                    {
                        LecturerId = LecId,// "L" + DateTime.Now.Ticks.ToString().Substring(0, 9),
                        Title = lecturer.Title,
                        SysDate = DateTime.Now,
                        JoinedDate = lecturer.JoinedDate.Date,
                        FName = lecturer.FName,
                        SName = lecturer.SName,
                        Dob = lecturer.Dob,
                        Email = lecturer.Email,
                        Mobile = lecturer.Mobile,
                        HomeTel = lecturer.HomeTel,
                        OfficeTel = lecturer.OfficeTel,
                        Gender = lecturer.Gender,
                        Qualifications = lecturer.Qualifications,
                        ProfileStatus = "P",
                        LecturerStatus = "A",
                        Username = User.Identity.Name,
                        AccessCode = tempLoginObj.AccessCode
                    };

                    if (lecturer.IsImageChange || lecturer.IsImageDeleted)
                    {
                        string fileExtension = null;
                        if (lecturer.LecturerImageFile != null)
                        {
                            fileExtension = Path.GetExtension(lecturer.LecturerImageFile.FileName);
                            string filePath = Path.Combine(WebHostEnvironment.WebRootPath, $@"Resources/Uploads/Lecturers") + $@"/{LecturerNew.LecturerId + fileExtension}";

                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                lecturer.LecturerImageFile.CopyTo(stream);
                            }
                        }
                        LecturerNew.ProfileImgPath = lecturer.LecturerImageFile != null ? LecturerNew.LecturerId + fileExtension : null;
                    }
                    Context.Lecturers.Add(LecturerNew);
                }
                Context.SaveChanges();

                return Json(new { status = "1" });
            }
            catch (Exception)
            {
                return Json(new { status = "4" });
            }
        }


        [Authorize(Policy = "LecturersOnly")]
        public IActionResult IndexAccount()
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



        [Authorize(Policy = "LecturersOnly")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> IndexAccount([FromBody] UserViewModel userViewModel)
        {
            using (var dbContext = Context.Database.BeginTransaction())
            {
                try
                {
                    ApplicationUser user = await UserManager.FindByNameAsync(User.Identity.Name);

                    var result = await UserManager.ChangePasswordAsync(user, userViewModel.Password, userViewModel.NewPassword);

                    if (result.Succeeded)
                    {
                        dbContext.Commit();
                        return Json(new { status = "1" });
                    }

                    string message = "";
                    foreach (var error in result.Errors)
                    {
                        message = error.Description;
                    }
                    dbContext.Rollback();
                    return Json(new { status = "3", message });
                }
                catch (Exception)
                {
                    dbContext.Rollback();
                    return Json(new { status = "4" });
                }
            }
        }


        #endregion

        #region Lecturer

        [HttpGet]
        public IActionResult LecturerLoad()
        {
            try
            {
                IEnumerable<Lecturer>lecturerList = (from l in Context.Lecturers
                                                     where l.LecturerStatus == "A"
                                                    orderby l.SysDate descending
                                                    select new Lecturer
                                                    {
                                                        EncryptLecturerId = protector.Protect(l.LecturerId),
                                                        FName = l.FName,
                                                        Dob = l.Dob,
                                                        Mobile = l.Mobile,
                                                    }).ToList();

                return Json(new { data = lecturerList });
            }
            catch (Exception)
            {
                return Json(new { status = "4" });
            }
        }



        [Authorize(Policy = "CreateLecturer")]
        public IActionResult IndexLecturer()
        {
            try
            {
                ViewBag.Titles = new SelectList(titles, "Title", "Title");
                ViewBag.Gender = new SelectList(genders, "Gender", "Gender");

                return View();
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        [Authorize(Policy = "CreateLecturer")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult IndexLecturer(Lecturer lecturer)
        {
            try
            {
                var tempLoginObj = new TempLogin()
                {
                    AccessCode = Guid.NewGuid().ToString(),
                    Name = lecturer.SName,
                    Tel = lecturer.Mobile,
                    Email = lecturer.Email != null ? lecturer.Email : lecturer.Mobile + "@gmail.com",
                    UserType = "L",
                    RegisteredState = "P",
                    RequestedDate = DateTime.Now,
                    IsExternal = false
                };
                Context.TempLogins.Add(tempLoginObj);


                var lecturerNew = new Lecturer()
                {
                    LecturerId = lecturer.LecturerId != null ? lecturer.LecturerId.ToUpper() : "L" + DateTime.Now.Ticks.ToString().Substring(0, 9),
                    Title = lecturer.Title,
                    SysDate = DateTime.Now,
                    JoinedDate = lecturer.JoinedDate.Date,
                    FName = lecturer.FName,
                    SName = lecturer.SName,
                    Dob = lecturer.Dob,
                    Email = lecturer.Email,
                    Mobile = lecturer.Mobile,
                    HomeTel = lecturer.HomeTel,
                    OfficeTel = lecturer.OfficeTel,
                    Gender = lecturer.Gender,
                    Qualifications = lecturer.Qualifications,
                    ProfileStatus = "A",
                    LecturerStatus = "A",
                    AccessCode = tempLoginObj.AccessCode
                };

                if (lecturer.IsImageChange || lecturer.IsImageDeleted)
                {
                    string fileExtension = null;
                    if (lecturer.LecturerImageFile != null)
                    {
                        fileExtension = Path.GetExtension(lecturer.LecturerImageFile.FileName);
                        string filePath = Path.Combine(WebHostEnvironment.WebRootPath, $@"Resources/Uploads/Lecturers") + $@"/{lecturerNew.LecturerId + fileExtension}";

                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            lecturer.LecturerImageFile.CopyTo(stream);
                        }
                    }
                    lecturerNew.ProfileImgPath = lecturer.LecturerImageFile != null ? lecturerNew.LecturerId + fileExtension : null;
                }
                Context.Lecturers.Add(lecturerNew);
                Context.SaveChanges();

                return Json(new { status = "1" });
            }
            catch (Exception)
            {
                return Json(new { status = "4" });
            }
        }



        [Authorize(Policy = "ViewLecturer")]
        public IActionResult Index()
        {
            try
            {
                var lecturers = Context.Lecturers.Where(x => x.LecturerStatus == "A").ToList();

                ViewBag.Count = lecturers.Count();

                return View();
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        [Authorize(Policy = "ModifyLecturer")]
        [HttpGet]
        public IActionResult EditLecturer(string id)
        {
            try
            {
                string decryptLecturerId = protector.Unprotect(id);
                var lecturerObj = Context.Lecturers.Where(x => x.LecturerId == decryptLecturerId).FirstOrDefault();

                var lecturerEdit = new Lecturer()
                {
                    EncryptLecturerId = id,
                    LecturerId = lecturerObj.LecturerId,
                    Title = lecturerObj.Title,
                    JoinedDate = lecturerObj.JoinedDate.Date,
                    FName = lecturerObj.FName,
                    SName = lecturerObj.SName,
                    Dob = lecturerObj.Dob,
                    Email = lecturerObj.Email,
                    Mobile = lecturerObj.Mobile,
                    HomeTel = lecturerObj.HomeTel,
                    OfficeTel = lecturerObj.OfficeTel,
                    Gender = lecturerObj.Gender,
                    Qualifications = lecturerObj.Qualifications,
                    ProfileImgPath = lecturerObj.ProfileImgPath
                };

                ViewBag.Titles = new SelectList(titles, "Title", "Title");
                ViewBag.Gender = new SelectList(genders, "Gender", "Gender");

                return PartialView("_PartialLecturerEdit", lecturerEdit);
            }
            catch (Exception)
            {
                return Json(new { status = "4" });
            }
        }

        [Authorize(Policy = "ModifyLecturer")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditLecturer(Lecturer lecturerObj)
        {
            try
            {
                string decryptlecturerId = protector.Unprotect(lecturerObj.EncryptLecturerId);
                Lecturer lecturer = Context.Lecturers.Where(x => x.LecturerId == decryptlecturerId).FirstOrDefault();

                lecturer.Title = lecturerObj.Title;
                lecturer.JoinedDate = lecturerObj.JoinedDate.Date;
                lecturer.FName = lecturerObj.FName;
                lecturer.SName = lecturerObj.SName;
                lecturer.Dob = lecturerObj.Dob;
                lecturer.Email = lecturerObj.Email;
                lecturer.Mobile = lecturerObj.Mobile;
                lecturer.HomeTel = lecturerObj.HomeTel;
                lecturer.OfficeTel = lecturerObj.OfficeTel;
                lecturer.Gender = lecturerObj.Gender;
                lecturer.Qualifications = lecturerObj.Qualifications;

                if (lecturerObj.IsImageChange || lecturerObj.IsImageDeleted)
                {
                    string fileExtension = null;
                    if (lecturerObj.LecturerImageFile != null)
                    {
                        fileExtension = Path.GetExtension(lecturerObj.LecturerImageFile.FileName);
                        string filePath = Path.Combine(WebHostEnvironment.WebRootPath, $@"Resources/Uploads/Lecturers") + $@"/{lecturer.LecturerId + fileExtension}";

                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            lecturerObj.LecturerImageFile.CopyTo(stream);
                        }
                    }
                    else
                    {
                        string filePath = Path.Combine(WebHostEnvironment.WebRootPath, $@"Resources/Uploads/Lecturers") + $@"/{lecturer.ProfileImgPath}";

                        if (System.IO.File.Exists(filePath))
                        {
                            System.IO.File.Delete(Path.Combine(filePath));
                        }
                    }


                    lecturer.ProfileImgPath = lecturerObj.LecturerImageFile != null ? lecturer.LecturerId + fileExtension : null;
                }
                lecturerObj.LecturerImageFile = null;

                Context.SaveChanges();
                return Json(new { status = "1", lecturerObj });
            }
            catch (Exception)
            {
                return Json(new { status = "4" });
            }
        }

        [Authorize(Policy = "RemoveLecturer")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteLecturer([FromBody] string id)
        {
            using (var dbContext = Context.Database.BeginTransaction())
            {
                try
                {
                    string decryptLecturerId = protector.Unprotect(id);

                    var lecturerObj = Context.Lecturers.Where(x => x.LecturerId == decryptLecturerId).FirstOrDefault();
                    var tempLoinObj = Context.TempLogins.Where(x => x.AccessCode == lecturerObj.AccessCode).FirstOrDefault();


                    if (lecturerObj != null)
                    {
                        string filePath = Path.Combine(WebHostEnvironment.WebRootPath, $@"Resources/Uploads/Lecturers") + $@"/{lecturerObj.ProfileImgPath}";

                        if (System.IO.File.Exists(filePath))
                        {
                            System.IO.File.Delete(Path.Combine(filePath));
                        }
                        Context.Remove(lecturerObj);
                        Context.Remove(tempLoinObj);
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