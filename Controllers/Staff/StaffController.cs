using ExcelDataReader;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
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
using LectureRoomMgt.Models.Staff;
using LectureRoomMgt.Models.ViewModels;
using LectureRoomMgt.Security;

namespace LectureRoomMgt.Controllers.Staff
{
    [Authorize]
    public class StaffController : Controller
    {
        public WisdomAppDBContext Context { get; }
        public IDataProtector protector { get; }

        public IWebHostEnvironment WebHostEnvironment { get; }
        public UserManager<ApplicationUser> UserManager { get; }

        public StaffController(WisdomAppDBContext wisdomAppDBContext,
                                UserManager<ApplicationUser> userManager,
                                IDataProtectionProvider dataProtectionProvider,
                                IWebHostEnvironment webHostEnvironment,
                                DataProtectionPurposeStrings dataProtectionPurposeStrings)
        {
            Context = wisdomAppDBContext;
            WebHostEnvironment = webHostEnvironment;
            UserManager = userManager;
            protector = dataProtectionProvider.CreateProtector(dataProtectionPurposeStrings.StaffId);

            GetDropDownLists();

        }


        #region Employee

        List<MasterTitle> titles = null;
        List<MasterGender> genders = null;
        List<MasterDesignation> designations = null;

        private void GetDropDownLists()
        {
            titles = Context.MasterTitles.OrderBy(x => x.Title).ToList();
            genders = Context.MasterGenders.OrderBy(x => x.Gender).ToList();
            designations = Context.MasterDesignations.OrderBy(x => x.Designation).ToList();

        }


        [HttpGet]
        public IActionResult EmployeeLoad()
        {
            try
            {
                IEnumerable<Employee> empList = (from l in Context.Employees
                                                 orderby l.SysDate descending
                                                 select new Employee
                                                 {
                                                     EncryptEmpId = protector.Protect(l.EmpId),
                                                     SName = l.SName,
                                                     Gender = l.Gender,
                                                     Dob = l.Dob,
                                                     Mobile = l.Mobile,
                                                 }).ToList();

                return Json(new { data = empList });
            }
            catch (Exception)
            {
                return Json(new { status = "4" });
            }
        }

        [Authorize(Policy = "ViewStaff")]
        public IActionResult IndexEmployee()
        {
            try
            {
                var employees = Context.Employees.ToList();

                ViewBag.Titles = new SelectList(titles, "Title", "Title");
                ViewBag.Gender = new SelectList(genders, "Gender", "Gender");
                ViewBag.Designation = new SelectList(designations, "Designation", "Designation");

                ViewBag.Count = employees.Count();

                return View();
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        [Authorize(Policy = "CreateStaff")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateEmployee(Employee employeeObj)
        {
            try
            {
                var employeeNew = new Employee()
                {
                    EmpId = employeeObj.EmpId != null ? employeeObj.EmpId.ToUpper() : "I" + DateTime.Now.Ticks.ToString().Substring(0, 9),
                    Title = employeeObj.Title,
                    SysDate = DateTime.Now,
                    JoinedDate = employeeObj.JoinedDate.Date,
                    FName = employeeObj.FName,
                    SName = employeeObj.SName,
                    Dob = employeeObj.Dob,
                    Email = employeeObj.Email,
                    Mobile = employeeObj.Mobile,
                    HomeTel = employeeObj.HomeTel,
                    OfficeTel = employeeObj.OfficeTel,
                    Gender = employeeObj.Gender,
                    Designation = employeeObj.Designation,
                    Comment = employeeObj.Comment

                };

                //if (employeeObj.IsImageChange || employeeObj.IsImageDeleted)
                //{
                //    string fileExtension = null;
                //    if (employeeObj.EmployeeImageFile != null)
                //    {
                //        fileExtension = Path.GetExtension(employeeObj.EmployeeImageFile.FileName);
                //        string filePath = Path.Combine(WebHostEnvironment.WebRootPath, $@"Resources/Uploads/Employees") + $@"/{employeeNew.EmpId + fileExtension}";

                //        using (var stream = new FileStream(filePath, FileMode.Create))
                //        {
                //            employeeObj.EmployeeImageFile.CopyTo(stream);
                //        }
                //    }
                //    employeeNew.ProfileImgPath = employeeObj.EmployeeImageFile != null ? employeeNew.EmpId + fileExtension : null;
                //}
                Context.Employees.Add(employeeNew);
                Context.SaveChanges();

                employeeObj.EncryptEmpId = protector.Protect(employeeNew.EmpId);
                employeeObj.EmpId = null;
                employeeObj.EmployeeImageFile = null;


                return Json(new { status = "1", employeeObj });
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


        [Authorize(Policy = "ModifyStaff")]
        [HttpGet]
        public IActionResult EditEmployee(string id)
        {
            try
            {
                string decryptEmployeeId = protector.Unprotect(id);
                var employee = Context.Employees.Where(x => x.EmpId == decryptEmployeeId).FirstOrDefault();

                var employeeEdit = new Employee()
                {
                    EncryptEmpId = id,
                    MEmpId = employee.EmpId,
                    MTitle = employee.Title,
                    MJoinedDate = employee.JoinedDate.Date,
                    MFName = employee.FName,
                    MSName = employee.SName,
                    MDob = employee.Dob,
                    MMobile = employee.Mobile,
                    MHomeTel = employee.HomeTel,
                    MOfficeTel = employee.OfficeTel,
                    MGender = employee.Gender,
                    MDesignation = employee.Designation,
                    MProfileImgPath = employee.ProfileImgPath,
                    MComment = employee.Comment,
                    MEmail = employee.Email

                };

                ViewBag.Titles = new SelectList(titles, "Title", "Title");
                ViewBag.Gender = new SelectList(genders, "Gender", "Gender");
                ViewBag.Designation = new SelectList(designations, "Designation", "Designation");


                return PartialView("_PartialEmployeeEdit", employeeEdit);
            }
            catch (Exception)
            {
                return Json(new { status = "4" });
            }
        }


        [Authorize(Policy = "ModifyStaff")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditEmployee(Employee employeeObj)
        {
            try
            {
                string decryptEmployeeId = protector.Unprotect(employeeObj.EncryptEmpId);
                Employee employee = Context.Employees.Where(x => x.EmpId == decryptEmployeeId).FirstOrDefault();

                employee.Title = employeeObj.Title;
                employee.JoinedDate = employeeObj.JoinedDate.Date;
                employee.FName = employeeObj.FName;
                employee.SName = employeeObj.SName;
                employee.Dob = employeeObj.Dob;
                employee.Mobile = employeeObj.Mobile;
                employee.HomeTel = employeeObj.HomeTel;
                employee.OfficeTel = employeeObj.OfficeTel;
                employee.Gender = employeeObj.Gender;
                employee.Designation = employeeObj.Designation;
                employee.Comment = employeeObj.Comment;


                //if (employeeObj.IsImageChange || employeeObj.IsImageDeleted)
                //{
                //    string fileExtension = null;
                //    if (employeeObj.EmployeeImageFile != null)
                //    {
                //        fileExtension = Path.GetExtension(employeeObj.EmployeeImageFile.FileName);
                //        string filePath = Path.Combine(WebHostEnvironment.WebRootPath, $@"Resources/Uploads/Employees") + $@"/{employee.EmpId + fileExtension}";

                //        using (var stream = new FileStream(filePath, FileMode.Create))
                //        {
                //            employeeObj.EmployeeImageFile.CopyTo(stream);
                //        }
                //    }
                //    else
                //    {
                //        string filePath = Path.Combine(WebHostEnvironment.WebRootPath, $@"Resources/Uploads/Employees") + $@"/{employee.ProfileImgPath}";

                //        if (System.IO.File.Exists(filePath))
                //        {
                //            System.IO.File.Delete(Path.Combine(filePath));
                //        }
                //    }
                //    employee.ProfileImgPath = employeeObj.EmployeeImageFile != null ? employee.EmpId + fileExtension : null;
                //}

                Context.SaveChanges();

                employeeObj.EmpId = null;
                employeeObj.EmployeeImageFile = null;

                return Json(new { status = "1", employeeObj });
            }
            catch (Exception)
            {
                return Json(new { status = "4" });
            }
        }

        [Authorize(Policy = "RemoveStaff")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteEmployee([FromBody] string id)
        {
            try
            {
                string decryptEmployeeId = protector.Unprotect(id);
                var employee = Context.Employees.Where(x => x.EmpId == decryptEmployeeId).FirstOrDefault();

                if (employee != null)
                {
                    string filePath = Path.Combine(WebHostEnvironment.WebRootPath, $@"Resources/Uploads/Employees") + $@"/{employee.ProfileImgPath}";

                    if (System.IO.File.Exists(filePath))
                    {
                        System.IO.File.Delete(Path.Combine(filePath));
                    }
                    Context.Remove(employee);
                }
                Context.SaveChanges();

                return Json(new { status = "1" });
            }
            catch (Exception)
            {
                return Json(new { status = "4" });
            }
        }

        #endregion

        #region Attendance

        [Authorize(Policy = "ProcessAttendance")]
        [HttpGet]
        public IActionResult ProcessAttendance()
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


        [Authorize(Policy = "ProcessAttendance")]
        [HttpPost]
        public IActionResult ProcessAttendance(IFormFile attendanceFile, DateTime processDate)
        {
            using (var dbContext = Context.Database.BeginTransaction())
            {
                try
                {
                    var attendMasterExist = Context.AttendanceMasters.Where(x => x.ProcessedDate.Date == processDate.Date).FirstOrDefault();
                    if (attendMasterExist != null)
                    {
                        return Json(new { status = "3" });
                    }

                    var attendanceMaster = new AttendanceMaster()
                    {
                        FileName = attendanceFile.FileName,
                        ProcessedDate = processDate,
                        ProcessedBy = User.Identity.Name
                    };
                    Context.AttendanceMasters.Add(attendanceMaster);
                    Context.SaveChanges();

                    System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
                    List<AttendanceDetail> attendanceList = new List<AttendanceDetail>();

                    using (var stream = new MemoryStream())
                    {
                        attendanceFile.CopyTo(stream);
                        using (var reader = ExcelReaderFactory.CreateReader(stream))
                        {
                            while (reader.Read())
                            {
                                if (reader.GetValue(0).ToString() != "Dept")
                                {
                                    if (DateTime.Parse(reader.GetValue(4).ToString()).ToShortDateString() == processDate.ToShortDateString())
                                    {
                                        var attendanceDetails = new AttendanceDetail()
                                        {
                                            ProcessId = attendanceMaster.ProcessId,
                                            UserId = reader.GetValue(1).ToString(),
                                            AttendedDate = DateTime.Parse(reader.GetValue(4).ToString()),
                                            TimeIn = reader.IsDBNull(5) ? null : reader.GetValue(5).ToString(),
                                            TimeOut = reader.IsDBNull(6) ? null : reader.GetValue(6).ToString()
                                        };
                                        attendanceList.Add(attendanceDetails);
                                    }
                                }
                            }
                        }
                    }
                    Context.AttendanceDetails.AddRange(attendanceList);
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

        #region Staff Only
        [Authorize(Policy = "StaffOnly")]
        public async Task<ActionResult> Index()
        {
            try
            {
                var user = await UserManager.FindByNameAsync(User.Identity.Name);

                ViewBag.Titles = new SelectList(titles, "Title", "Title");
                ViewBag.Gender = new SelectList(genders, "Gender", "Gender");
                ViewBag.Designation = new SelectList(designations, "Designation", "Designation");

                var tempLoginObj = Context.TempLogins.Where(x => x.User == User.Identity.Name).FirstOrDefault();
                var empployeeObj = Context.Employees.Where(x => x.Username == User.Identity.Name).FirstOrDefault();

                if (empployeeObj != null)
                {
                    return View(empployeeObj);
                }

                empployeeObj = new Employee()
                {
                    EmpId = user.eWisdomId,
                    JoinedDate = DateTime.Now,
                    Dob = DateTime.Now,
                };
                return View(empployeeObj);
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        [Authorize(Policy = "StaffOnly")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee employeeObj)
        {
            try
            {
                var tempLoginObj = Context.TempLogins.Where(x => x.User == User.Identity.Name).FirstOrDefault();
                Employee employee = Context.Employees.Where(x => x.EmpId == employeeObj.EmpId).FirstOrDefault();

                if (employee != null)
                {
                    employee.Title = employeeObj.Title;
                    employee.JoinedDate = employeeObj.JoinedDate.Date;
                    employee.FName = employeeObj.FName;
                    employee.SName = employeeObj.SName;
                    employee.Dob = employeeObj.Dob;
                    employee.Mobile = employeeObj.Mobile;
                    employee.HomeTel = employeeObj.HomeTel;
                    employee.OfficeTel = employeeObj.OfficeTel;
                    employee.Gender = employeeObj.Gender;
                    employee.Designation = employeeObj.Designation;
                    employee.Comment = employeeObj.Comment;


                    //if (employeeObj.IsImageChange || employeeObj.IsImageDeleted)
                    //{
                    //    string fileExtension = null;
                    //    if (employeeObj.EmployeeImageFile != null)
                    //    {
                    //        fileExtension = Path.GetExtension(employeeObj.EmployeeImageFile.FileName);
                    //        string filePath = Path.Combine(WebHostEnvironment.WebRootPath, $@"Resources/Uploads/Employees") + $@"/{employee.EmpId + fileExtension}";

                    //        using (var stream = new FileStream(filePath, FileMode.Create))
                    //        {
                    //            employeeObj.EmployeeImageFile.CopyTo(stream);
                    //        }
                    //    }
                    //    else
                    //    {
                    //        string filePath = Path.Combine(WebHostEnvironment.WebRootPath, $@"Resources/Uploads/Employees") + $@"/{employee.ProfileImgPath}";

                    //        if (System.IO.File.Exists(filePath))
                    //        {
                    //            System.IO.File.Delete(Path.Combine(filePath));
                    //        }
                    //    }
                    //    employee.ProfileImgPath = employeeObj.EmployeeImageFile != null ? employee.EmpId + fileExtension : null;
                    //}

                    Context.SaveChanges();

                    return Json(new { status = "1" });
                }
                else
                {
                    var employeeNew = new Employee()
                    {
                        EmpId = employeeObj.EmpId != null ? employeeObj.EmpId.ToUpper() : "I" + DateTime.Now.Ticks.ToString().Substring(0, 9),
                        Title = employeeObj.Title,
                        SysDate = DateTime.Now,
                        JoinedDate = employeeObj.JoinedDate.Date,
                        FName = employeeObj.FName,
                        SName = employeeObj.SName,
                        Dob = employeeObj.Dob,
                        Email = employeeObj.Email,
                        Mobile = employeeObj.Mobile,
                        HomeTel = employeeObj.HomeTel,
                        OfficeTel = employeeObj.OfficeTel,
                        Gender = employeeObj.Gender,
                        Designation = employeeObj.Designation,
                        Comment = employeeObj.Comment,
                        AccessCode = tempLoginObj.AccessCode,
                        Username = User.Identity.Name

                    };

                    //if (employeeObj.IsImageChange || employeeObj.IsImageDeleted)
                    //{
                    //    string fileExtension = null;
                    //    if (employeeObj.EmployeeImageFile != null)
                    //    {
                    //        fileExtension = Path.GetExtension(employeeObj.EmployeeImageFile.FileName);
                    //        string filePath = Path.Combine(WebHostEnvironment.WebRootPath, $@"Resources/Uploads/Employees") + $@"/{employeeNew.EmpId + fileExtension}";

                    //        using (var stream = new FileStream(filePath, FileMode.Create))
                    //        {
                    //            employeeObj.EmployeeImageFile.CopyTo(stream);
                    //        }
                    //    }
                    //    employeeNew.ProfileImgPath = employeeObj.EmployeeImageFile != null ? employeeNew.EmpId + fileExtension : null;
                    //}
                    Context.Employees.Add(employeeNew);
                    Context.SaveChanges();

                    return Json(new { status = "1" });
                }
            }
            catch (Exception)
            {
                return Json(new { status = "4" });
            }
        }


        [Authorize(Policy = "StaffOnly")]
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


        [Authorize(Policy = "StaffOnly")]
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

    }
}
