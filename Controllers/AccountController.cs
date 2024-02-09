using LectureRoomMgt.DAL;
using LectureRoomMgt.Models;
using LectureRoomMgt.Models.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using LectureRoomMgt.ClassFiles;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication;
using LectureRoomMgt.Models.ErrrorLog;

namespace LectureRoomMgt.Controllers
{
    public class AccountController : Controller
    {
        public UserManager<ApplicationUser> UserManager { get; }
        public SignInManager<ApplicationUser> SignInManager { get; }
        public WisdomAppDBContext Context { get; }
        public IWebHostEnvironment WebHostEnvironment { get; }
        public AccountController(UserManager<ApplicationUser> userManager,
                                 SignInManager<ApplicationUser> signInManager,
                                 WisdomAppDBContext wisdomAppDBContext,
                                 IWebHostEnvironment webHostEnvironment)
        {
            UserManager = userManager;
            SignInManager = signInManager;
            Context = wisdomAppDBContext;
            WebHostEnvironment = webHostEnvironment;
        }
        [HttpPost]
        public IActionResult ExternalLogin(string provider, string returnUrl = null)
        {
            //var redirectUrl = Url.Action(nameof(ExternalLoginCallback), "Account", new { returnUrl });
            var redirectUrl = Url.Action("Callback", "Account");

            var properties = SignInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
            return Challenge(properties, provider);
        }
        //public async Task<IActionResult> ExternalLoginCallback(string returnUrl = null, string remoteError = null)
        public async Task<IActionResult> Callback(string returnUrl = null, string remoteError = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            if (remoteError != null)
            {
                ModelState.AddModelError(string.Empty, $"Error from external provider: {remoteError}");
                return RedirectToAction("Index", "Account");
            }

            // Get the login information about the user from the external login provider
            var info = await SignInManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                ModelState.AddModelError(string.Empty, "Error loading external login information.");
                return RedirectToAction("Index", "Account");
            }

            // If the user already has a login (i.e if there is a record in AspNetUserLogins
            // table) then sign-in the user with this external login provider
            var signInResult = await SignInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false, bypassTwoFactor: true);

            if (signInResult.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            // If there is no record in AspNetUserLogins table, the user may not have
            // a local account
            else
            {
                // Get the email claim value
                var email = info.Principal.FindFirstValue(ClaimTypes.Email);

                if (email != null)
                {
                    // Create a new user without password if we do not have a user already
                    var user = await UserManager.FindByEmailAsync(email);

                    if (user == null)
                    {
                        user = new ApplicationUser
                        {
                            UserName = info.Principal.FindFirstValue(ClaimTypes.Email),
                            Company = info.Principal.FindFirstValue(ClaimTypes.Name),
                            Email = info.Principal.FindFirstValue(ClaimTypes.Email),
                            UserType = "L"
                        };

                        var result = await UserManager.CreateAsync(user);

                        if (result.Succeeded)
                        {
                            //IdentityResult result2 = null;

                            List<Claim> lecturerClaim = new List<Claim>()
                            {
                                new Claim("Lecturer","Lecturer"),
                            };
                            //  result2 = 
                            await UserManager.AddClaimsAsync(user, lecturerClaim);
                            await SignInManager.SignInAsync(user, false);
                        }
                    }
                    // Add a login (i.e insert a row for the user in AspNetUserLogins table)
                    await UserManager.AddLoginAsync(user, info);
                    await SignInManager.SignInAsync(user, false);

                    return RedirectToAction("Index", "Home");
                }
                // If we cannot find the user email we cannot continue
                ViewBag.ErrorTitle = $"Email claim not received from: {info.LoginProvider}";
                ViewBag.ErrorMessage = "Please contact support";
                return View("Error");
            }
        }

        public IActionResult createOnlineEvent()
        {
            return View();
        }

        public async Task<ActionResult> Index()
        {
            try
            {
                if (UserManager.Users.ToList().Count == 0)
                {
                    await UserManager.CreateAsync(new ApplicationUser { UserName = "Admin", UserType = "I" }, "Abcd@1234");
                    var user = await UserManager.FindByNameAsync("Admin");

                    List<Claim> ClaimsList = new List<Claim>()
                    {
                        #region Claim List
                        new Claim("1","1"),
                        new Claim("2","2"),
                        new Claim("3","3"),
                        new Claim("4","4"),
                        new Claim("5","5"),
                        new Claim("6","6"),
                        new Claim("7","7"),
                        new Claim("8","8"),
                        new Claim("11","11"),
                        new Claim("12","12"),
                        new Claim("13","13"),
                        new Claim("14","14"),
                        new Claim("15","15"),
                        new Claim("16","16"),
                        new Claim("17","17"),
                        new Claim("18","18"),
                        new Claim("19","19"),
                        new Claim("20","20"),
                        new Claim("21","21"),
                        new Claim("22","22"),
                        new Claim("23","23"),
                        new Claim("24","24"),
                        new Claim("25","25"),
                        new Claim("26","26"),
                        new Claim("27","27"),
                        new Claim("28","28"),
                        new Claim("29","29"),
                        new Claim("30","30"),
                        new Claim("31","31"),
                        new Claim("32","32"),
                        new Claim("33","33"),
                        new Claim("34","34"),
                        new Claim("35","35"),
                        new Claim("36","36"),
                        new Claim("37","37"),
                        new Claim("38","38"),
                        new Claim("39","39"),
                        new Claim("40","40"),
                        new Claim("41","41"),
                        new Claim("42","42"),
                        new Claim("43","43"),
                        new Claim("44","44"),
                        new Claim("45","45"),
                        new Claim("46","46"),
                        new Claim("47","47"),
                        new Claim("48","48"),
                        new Claim("49","49"),
                        new Claim("50","50"),
                        new Claim("51","51"),
                        new Claim("52","52"),
                        new Claim("53","53"),
                        new Claim("54","54"),
                        new Claim("55","55"),
                        new Claim("56","56"),
                        new Claim("57","57"),
                        new Claim("58","58"),
                        new Claim("59","59"),
                        new Claim("60","60"),
                        new Claim("61","61"),
                        new Claim("62","62"),
                        new Claim("63","63"),
                        new Claim("64","64"),
                        new Claim("65","65"),
                        new Claim("66","66"),
                        new Claim("67","67"),
                        new Claim("68","68"),
                        new Claim("69","69"),
                        new Claim("70","70"),
                        new Claim("71","71"),
                        new Claim("72","72"),
                        new Claim("73","73"),
                        new Claim("74","74"),
                        new Claim("75","75"),
                        new Claim("76","76"),
                        new Claim("77","77"),
                        new Claim("78","78"),
                        new Claim("79","79"),
                        new Claim("80","80"),
                        new Claim("81","81"),
                        new Claim("82","82"),
                        new Claim("83","83"),
                        new Claim("Staff","Staff")
                        #endregion
                    };

                    await UserManager.AddClaimsAsync(user, ClaimsList);

                    var tempLoginObj = new TempLogin()
                    {
                        AccessCode = Guid.NewGuid().ToString(),
                        User = "Admin",
                        UserType = "I",
                        Email = "admin@company.com",
                        RegisteredState = "R",
                        RegisteredDate = DateTime.Now,
                        IsExternal = false
                    };
                    Context.TempLogins.Add(tempLoginObj);
                    Context.SaveChanges();
                }

                return View();
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index([Bind("Username", "Password")] UserViewModel registerViewModel, string o = "")
        {
            try
            {
                if (o == "")
                {
                    ApplicationUser user = await UserManager.FindByNameAsync(registerViewModel.Username);
                    var result = await UserManager.CheckPasswordAsync(user, registerViewModel.Password);
                    if (result)
                    {
                        var TempUser = Context.TempLogins.Where(x => x.User == registerViewModel.Username).FirstOrDefault();

                        if (TempUser != null)
                        {
                            if (TempUser.RegisteredState == "D")
                            {
                                ModelState.AddModelError("", "Your account is deactivated :(");
                                return View(registerViewModel);
                            }

                            if (TempUser.RegisteredState == "P")
                            {
                                ModelState.AddModelError("", "Your account is not approved yet :(");
                                return View(registerViewModel);
                            }

                            var userLog = new UserLoginLog()
                            {
                                User = TempUser.User,
                                DateLogin = DateTime.Now
                            };
                            Context.UserLoginLogs.Add(userLog);
                            Context.SaveChanges();
                        }
                        await SignInManager.SignInAsync(user, false);

                        if (TempUser.UserType == "I")
                        {
                            return RedirectToAction("Index", "Home");
                        }
                        else if (TempUser.UserType == "L")
                        {
                            return RedirectToAction("IndexLecturer", "Home");
                        }
                        else if (TempUser.UserType == "A")
                        {
                            return RedirectToAction("IndexStaffAssist", "Home");
                        }
                        else if (TempUser.UserType == "S")
                        {
                            return RedirectToAction("IndexStudent", "Home");
                        }

                    }
                    ModelState.AddModelError("", "Invalid credentials");
                }
                if (o != "")
                {
                    var TempUser = Context.TempLogins.Where(x => x.AccessCode == o).FirstOrDefault();
                    ApplicationUser user = await UserManager.FindByNameAsync(TempUser.User);
                    if (TempUser != null)
                    {
                        if (TempUser.RegisteredState == "D")
                        {
                            ModelState.AddModelError("", "Your account is deactivated :(");
                            return View(registerViewModel);
                        }
                        var userLog = new UserLoginLog()
                        {
                            User = TempUser.User,
                            DateLogin = DateTime.Now
                        };
                        Context.UserLoginLogs.Add(userLog);
                        Context.SaveChanges();
                    }
                    await SignInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Home");
                }
                return View(registerViewModel);

            }
            catch (Exception ex)
            {
                var errorLog = new ErrorLog()
                {
                    ControllerName = "Account",
                    ActionName = "Index",
                    Error = ex.Message,
                    DateLogin = DateTime.Now,
                    User = User.Identity.Name
                };

                Context.ErrorLogs.Add(errorLog);
                Context.SaveChanges();

                ModelState.AddModelError("", "Invalid credentials");

                await SignInManager.SignOutAsync();
                return View(registerViewModel);
            }
        }

        [HttpPost]
        public async Task<ActionResult> LogOut()
        {
            await SignInManager.SignOutAsync();
            return RedirectToAction("Index", "Account");
        }


        [HttpGet]
        public IActionResult Register()
        {
            return PartialView("_PartialRegisterUser");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register([Bind("AccessCode", "Username", "Password", "ConfirmPassword")] [FromBody] UserViewModel registerViewModel)
        {
            using (var dbContext = Context.Database.BeginTransaction())
            {
                var TempUser = Context.TempLogins.Where(x => x.AccessCode == registerViewModel.AccessCode).ToList();
                var SystemId = "";

                if (TempUser.First().UserType == "L")
                {
                    SystemId = "L" + DateTime.Now.Ticks.ToString().Substring(0, 9);
                }
                else if (TempUser.First().UserType == "I")
                {
                    SystemId = "I" + DateTime.Now.Ticks.ToString().Substring(0, 9);
                }
                else if (TempUser.First().UserType == "A")
                {
                    SystemId = "A" + DateTime.Now.Ticks.ToString().Substring(0, 9);
                }
                else if (TempUser.First().UserType == "S")
                {
                    SystemId = "S" + DateTime.Now.Ticks.ToString().Substring(0, 9);
                }

                var user = new ApplicationUser { eWisdomId = SystemId, UserName = registerViewModel.Username, UserType = TempUser.First().UserType };
                var result = await UserManager.CreateAsync(user, registerViewModel.Password);

                if (result.Succeeded)
                {
                    IdentityResult result2 = null;

                    if (TempUser.First().UserType == "L")
                    {
                        List<Claim> lecturerClaim = new List<Claim>()
                        {
                            new Claim("Lecturer","Lecturer"),
                        };
                        result2 = await UserManager.AddClaimsAsync(user, lecturerClaim);
                    }
                    else if (TempUser.First().UserType == "I")
                    {
                        List<Claim> teacherClaim = new List<Claim>()
                        {
                            new Claim("Staff","Staff"),
                        };
                        result2 = await UserManager.AddClaimsAsync(user, teacherClaim);
                    }
                    else if (TempUser.First().UserType == "A")
                    {
                        List<Claim> staffAssistClaim = new List<Claim>()
                        {
                            new Claim("StaffAssist","StaffAssist"),
                        };
                        result2 = await UserManager.AddClaimsAsync(user, staffAssistClaim);
                    }
                    else if (TempUser.First().UserType == "S")
                    {
                        List<Claim> studentClaim = new List<Claim>()
                        {
                            new Claim("Student","Student"),
                        };
                        result2 = await UserManager.AddClaimsAsync(user, studentClaim);
                    }

                    if (!result2.Succeeded)
                    {
                        List<string> errorList2 = new List<string>();

                        foreach (var error2 in result2.Errors)
                        {
                            errorList2.Add(error2.Description);
                        }
                        dbContext.Rollback();
                        return Json(new { status = "3", errorList2 });
                    }

                    TempUser.First().RegisteredState = "P";

                    if (TempUser.First().UserType == "I")
                    {
                        TempUser.First().RegisteredState = "R";
                    }
                    
                    TempUser.First().RegisteredDate = DateTime.Now;
                    TempUser.First().User = registerViewModel.Username;

                    Context.SaveChanges();

                    dbContext.Commit();

                    if (TempUser.First().UserType == "I")
                    {
                        return Json(new { status = "2" });
                    }
                    return Json(new { status = "1" });
                }

                List<string> errorList = new List<string>();

                foreach (var error in result.Errors)
                {
                    errorList.Add(error.Description);
                }
                dbContext.Rollback();
                return Json(new { status = "3", errorList });
            }
        }


        [HttpGet]
        public IActionResult RegisterStudent()
        {
            return PartialView("_PartialRegisterStudentUser");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegisterStudent([Bind("RegNo")] [FromBody] UserViewModel registerViewModel)
        {
            using (var dbContext = Context.Database.BeginTransaction())
            {
                try
                {
                    var TempUser = Context.TempLogins.Where(x => x.AdmissionNo == registerViewModel.RegNo).FirstOrDefault();

                    if (TempUser != null)
                    {
                        if (TempUser.RegisteredState == "R")
                        {
                            return Json(new { status = "1" });
                        }
                    }
                    return Json(new { status = "4" });
                }
                catch (Exception)
                {
                    dbContext.Rollback();
                    return Json(new { status = "4" });
                }
            }
        }


        [HttpGet]
        public IActionResult RequestCode()
        {
            return PartialView("_PartialRequestAccessCode");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RequestCode([Bind("UserType", "Name", "NIC", "Tel", "Email")] [FromBody] TempLogin tempLogin)
        {
            using (var dbContext = Context.Database.BeginTransaction())
            {
                try
                {
                    if (tempLogin.UserType.ToUpper() == "L" && (tempLogin.Name == "" || tempLogin.NIC == "" || tempLogin.Tel == ""))
                    {
                        return Json(new { status = "2" });
                    }
                    else
                    {
                        if (tempLogin.UserType.ToUpper() == "L")
                        {
                            var Templecturer = Context.TempLogins.Where(x => x.NIC == tempLogin.NIC && x.UserType == "L" && x.RegisteredState == "A").FirstOrDefault();

                            if (Templecturer == null)
                            {
                                return Json(new { status = "3" });
                            }

                            Templecturer.RegisteredDate = DateTime.Now;
                            Templecturer.Email = tempLogin.Email;
                            Templecturer.Name = tempLogin.Name;
                            Templecturer.Tel = tempLogin.Tel;

                            Context.SaveChanges();

                            string savedCode = Templecturer.AccessCode;



                            var uniInfo = Context.MasterCompanies.FirstOrDefault();

                            if (!string.IsNullOrEmpty(uniInfo.Email))
                            {
                                #region Email Send
                                string FilePath = Path.Combine(WebHostEnvironment.WebRootPath, EmailUtil.WelcomeEmail.GetFile());
                                StreamReader str = new StreamReader(FilePath);
                                string MailText = str.ReadToEnd();
                                str.Close();

                                EmailUtil.WelcomeEmail.CreateEmail(uniInfo, MailText, savedCode, tempLogin.Email);
                                #endregion

                                dbContext.Commit();
                                return Json(new { status = "1" });
                            }
                            else
                            {
                                dbContext.Rollback();
                                return Json(new { status = "4" });
                            }
                        }
                        else
                        {
                            var TempUser = Context.TempLogins.Where(x => x.Email == tempLogin.Email).FirstOrDefault();

                            if (TempUser != null)
                            {
                                if (TempUser.RegisteredState == "R")
                                {
                                    return Json(new { status = "5" });
                                }
                                else
                                {
                                    return Json(new { status = "6" });
                                }
                            }

                            var tempLoginObj = new TempLogin()
                            {
                                AccessCode = Guid.NewGuid().ToString(),
                                UserType = tempLogin.UserType,
                                Name = tempLogin.Name,
                                NIC = tempLogin.NIC,
                                Tel = tempLogin.Tel,
                                Email = tempLogin.Email,
                                RegisteredState = "P",
                                RequestedDate = DateTime.Now,
                                IsExternal = true
                            };

                            Context.TempLogins.Add(tempLoginObj);
                            Context.SaveChanges();

                            string code = tempLoginObj.AccessCode;

                            var uniInfo = Context.MasterCompanies.FirstOrDefault();

                            if (!string.IsNullOrEmpty(uniInfo.Email))
                            {
                                #region Email Send
                                string FilePath = Path.Combine(WebHostEnvironment.WebRootPath, EmailUtil.WelcomeEmail.GetFile());
                                StreamReader str = new StreamReader(FilePath);
                                string MailText = str.ReadToEnd();
                                str.Close();

                                EmailUtil.WelcomeEmail.CreateEmail(uniInfo, MailText, code, tempLogin.Email);
                                #endregion

                                dbContext.Commit();
                                return Json(new { status = "1" });
                            }
                            else
                            {
                                dbContext.Rollback();
                                return Json(new { status = "4" });
                            }
                        }

                    }
                }
                catch (Exception)
                {
                    dbContext.Rollback();
                    return Json(new { status = "4" });
                }
            }
        }

        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return PartialView("_PartialForgotPassword");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ForgotPassword([FromBody] UserViewModel userViewModel)
        {
            using (var dbContext = Context.Database.BeginTransaction())
            {
                try
                {
                    var TempUser = Context.TempLogins.Where(x => x.User == userViewModel.Username).FirstOrDefault();
                    var user = await UserManager.FindByNameAsync(TempUser.User);

                    if (userViewModel.ForgotPwType == "E")
                    {
                        if (TempUser != null)
                        {
                            if (TempUser.Email != userViewModel.Email)
                            {
                                dbContext.Rollback();
                                return Json(new { status = "3" });
                            }
                        }
                        else
                        {
                            dbContext.Rollback();
                            return Json(new { status = "3" });
                        }

                        TempUser.ResetToken = Guid.NewGuid().ToString();
                        Context.SaveChanges();

                        var schoolInfo = Context.MasterCompanies.FirstOrDefault();

                        if (!string.IsNullOrEmpty(schoolInfo.Email))
                        {
                            #region Email Send
                            string FilePath = Path.Combine(WebHostEnvironment.WebRootPath, EmailUtil.ResetEmail.GetFile());
                            StreamReader str = new StreamReader(FilePath);
                            string MailText = str.ReadToEnd();
                            str.Close();

                            EmailUtil.ResetEmail.CreateEmail(schoolInfo, MailText, TempUser.ResetToken, TempUser.Email);
                            #endregion

                            dbContext.Commit();
                            return Json(new { status = "1" });
                        }
                        else
                        {
                            dbContext.Rollback();
                            return Json(new { status = "4" });
                        }
                    }
                    else if (userViewModel.ForgotPwType == "R")
                    {
                        if (TempUser.ResetToken != "Admin reset")
                        {
                            if (TempUser.ResetToken != userViewModel.ResetToken)
                            {
                                dbContext.Rollback();
                                return Json(new { status = "4" });
                            }
                        }

                        TempUser.ResetToken = null;
                        Context.SaveChanges();

                        var resultRemovePassword = await UserManager.RemovePasswordAsync(user);

                        if (resultRemovePassword.Succeeded)
                        {
                            var resultAddPassword = await UserManager.AddPasswordAsync(user, userViewModel.NewPassword);

                            if (!resultAddPassword.Succeeded)
                            {
                                return Json(new { status = "5" });
                            }
                        }
                        dbContext.Commit();
                        return Json(new { status = "2" });
                    }
                    dbContext.Rollback();
                    return Json(new { status = "6" });
                }
                catch (Exception)
                {
                    dbContext.Rollback();
                    return Json(new { status = "6" });
                }
            }
        }
    }
}


