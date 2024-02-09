using LectureRoomMgt.DAL;
using LectureRoomMgt.Models;
using LectureRoomMgt.Models.Claims;
using LectureRoomMgt.Models.ViewModels;
using LectureRoomMgt.Security;
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
using System.Security.Claims;
using System.Threading.Tasks;
using LectureRoomMgt.ClassFiles;
using LectureRoomMgt.Models.Lecturers;
using EmailService;

namespace LectureRoomMgt.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        public UserManager<ApplicationUser> UserManager { get; }
        public RoleManager<IdentityRole> RoleManager { get; }
        public WisdomAppDBContext Context { get; }
        public IDataProtector protector { get; }
        public IWebHostEnvironment WebHostEnvironment { get; }
        private readonly IEmailSender _emailSender;

        public AdminController(UserManager<ApplicationUser> userManager,
                               RoleManager<IdentityRole> roleManager,
                               WisdomAppDBContext wisdomAppDBContext,
                               IDataProtectionProvider dataProtectionProvider,
                               IWebHostEnvironment webHostEnvironment,
                               DataProtectionPurposeStrings dataProtectionPurposeStrings,
                                IEmailSender emailSender)
        {
            UserManager = userManager;
            RoleManager = roleManager;
            Context = wisdomAppDBContext;
            protector = dataProtectionProvider.CreateProtector(dataProtectionPurposeStrings.AdministrationId);
            WebHostEnvironment = webHostEnvironment;
            _emailSender = emailSender;

            GetLogins();
        }

        #region Methods

        IEnumerable<TempLogin> logins = null;
        private void GetLogins()
        {
            logins = (from l in Context.TempLogins
                      select new TempLogin
                      {
                          EncryptAccessCode = protector.Protect(l.AccessCode),
                          User = l.User,
                          RegisteredDate = l.RegisteredDate,
                          RegisteredState = l.RegisteredState,
                          Name = l.Name != null ? l.Name : l.AdmissionNo,
                          NIC = l.NIC,
                          Tel = l.Tel,
                          UserType = l.UserType,
                          IsExternal = l.IsExternal,
                          Email = l.Email
                      }).ToList();
        }


        #endregion

        #region Users

        [HttpGet]
        public IActionResult UsersLoad()
        {
            try
            {
                List<UserViewModel> users = new List<UserViewModel>();

                foreach (ApplicationUser identityUser in UserManager.Users.Where(x => x.UserType == "I"))
                {
                    var registerUser = new UserViewModel()
                    {
                        EncryptUserId = protector.Protect(identityUser.Id),
                        Username = identityUser.UserName,
                        Email = identityUser.Email
                    };
                    users.Add(registerUser);
                }
                return Json(new { data = users });
            }
            catch (Exception)
            {
                return Json(new { status = "4" });
            }
        }


        List<UserViewModel> users = new List<UserViewModel>();
        private void GetAllUsers()
        {
            users = new List<UserViewModel>();

            foreach (ApplicationUser identityUser in UserManager.Users.Where(x => x.UserType == "I"))
            {
                var registerUser = new UserViewModel()
                {
                    EncryptUserId = protector.Protect(identityUser.Id),
                    Username = identityUser.UserName,
                    Email = identityUser.Email
                };
                users.Add(registerUser);
            }
        }

        //[Authorize(Policy = "ViewUser")]
        public IActionResult IndexUsers()
        {
            GetAllUsers();

            ViewBag.Count = users.Count;

            return View();
        }

        //[Authorize(Policy = "CreateUser")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateUser([Bind("Username", "Password", "ConfirmPassword")] [FromBody] UserViewModel registerViewModel)
        {
            using (var dbContext = Context.Database.BeginTransaction())
            {
                try
                {
                    var user = new ApplicationUser { UserName = registerViewModel.Username, UserType = "I" };
                    var result = await UserManager.CreateAsync(user, registerViewModel.Password);

                    if (result.Succeeded)
                    {
                        var tempLoginObj = new TempLogin()
                        {
                            AccessCode = Guid.NewGuid().ToString(),
                            User = registerViewModel.Username,
                            UserType = "I",
                            Email = registerViewModel.Username + "@company.com",
                            RegisteredState = "R",
                            RegisteredDate = DateTime.Now,
                            IsExternal = false
                        };
                        Context.TempLogins.Add(tempLoginObj);

                        List<Claim> studentClaim = new List<Claim>()
                        {
                            new Claim("Staff","Staff"),
                        };

                        IdentityResult result2 = await UserManager.AddClaimsAsync(user, studentClaim);

                        if (!result2.Succeeded)
                        {
                            List<string> errorList2 = new List<string>();

                            foreach (var error2 in result2.Errors)
                            {
                                errorList2.Add(error2.Description);
                            }

                            if (errorList2.Count > 0)
                            {
                                dbContext.Rollback();
                                return Json(new { status = "3" });
                            }
                        }

                        dbContext.Commit();
                        Context.SaveChanges();

                        registerViewModel.EncryptUserId = protector.Protect(user.Id);

                        GetAllUsers();
                        return Json(new { status = "1", registerViewModel, users.Count });
                    }

                    bool duplicates = false;
                    string message = "";
                    foreach (var error in result.Errors)
                    {
                        if (error.Code == "DuplicateUserName")
                        {
                            duplicates = true;
                            message = error.Description;
                        }
                    }

                    if (duplicates)
                    {
                        dbContext.Rollback();
                        return Json(new { status = "2", message });
                    }
                    else
                    {
                        dbContext.Rollback();
                        return Json(new { status = "3" });
                    }
                }
                catch (Exception)
                {
                    dbContext.Rollback();
                    return Json(new { status = "4" });
                }

            }
        }

        //[Authorize(Policy = "ModifyUser")]
        public async Task<IActionResult> EditUser(string id)
        {
            try
            {
                if (id == null)
                {
                    return Json(new { status = "1" });
                }
                string decryptId = protector.Unprotect(id);

                ApplicationUser user = await UserManager.FindByIdAsync(decryptId);

                if (user == null)
                {
                    return Json(new { status = "4" });
                }
                else
                {
                    var registerUser = new UserViewModel()
                    {
                        EncryptUserId = id,
                        MUsername = user.UserName,
                    };
                    return PartialView("_PartialUserEdit", registerUser);
                }
            }
            catch (Exception)
            {
                return Json(new { status = "4" });
            }
        }

        //[Authorize(Policy = "ModifyUser")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditUser([Bind("Username", "Password", "ConfirmPassword", "EncryptUserId")] [FromBody] UserViewModel registerViewModel)
        {
            using (var dbContext = Context.Database.BeginTransaction())
            {
                try
                {
                    ApplicationUser user = await UserManager.FindByNameAsync(registerViewModel.Username);

                    var resultRemovePassword = await UserManager.RemovePasswordAsync(user);

                    if (resultRemovePassword.Succeeded)
                    {
                        var resultAddPassword = await UserManager.AddPasswordAsync(user, registerViewModel.Password);

                        if (resultAddPassword.Succeeded)
                        {
                            dbContext.Commit();
                            return Json(new { status = "1", registerViewModel });
                        }
                    }
                    dbContext.Rollback();
                    return Json(new { status = "3" });
                }
                catch (Exception)
                {
                    dbContext.Rollback();
                    return Json(new { status = "4" });
                }
            }
        }

        //[Authorize(Policy = "RemoveUser")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteUser([FromBody] string UserId)
        {
            using (var dbContext = Context.Database.BeginTransaction())
            {
                try
                {
                    string decryptId = protector.Unprotect(UserId);

                    ApplicationUser user = await UserManager.FindByIdAsync(decryptId);

                    var tempLogin = Context.TempLogins.Where(x => x.User == user.UserName).FirstOrDefault();

                    if (tempLogin.User == "Admin")
                    {
                        dbContext.Rollback();
                        return Json(new { status = "2" });
                    }

                    if (tempLogin != null)
                    {
                        Context.Remove(tempLogin);
                        Context.SaveChanges();
                    }

                    var result = await UserManager.DeleteAsync(user);

                    if (result.Succeeded)
                    {
                        dbContext.Commit();
                        return Json(new { status = "1" });
                    }
                    else
                    {
                        dbContext.Rollback();
                        return Json(new { status = "3" });
                    }
                }
                catch (Exception)
                {
                    dbContext.Rollback();
                    return Json(new { status = "4" });
                }
            }
        }

        #endregion

        #region Users-Claims

        List<ClaimViewModel> userClaims = new List<ClaimViewModel>();
        List<ClaimAction> varClaims = new List<ClaimAction>();
        private async Task GetAllUserClaims(string userId)
        {
            userClaims = new List<ClaimViewModel>();
            var user = await UserManager.FindByIdAsync(userId);

            List<Claim> ClaimsList = new List<Claim>();
            varClaims = Context.ClaimActions.OrderBy(x => x.ClaimType).ToList();

            foreach (var item in varClaims)
            {
                var claimsObj = new Claim(item.ClaimType, item.ClaimValue);

                ClaimsList.Add(claimsObj);
            }
            var existingUserClaims = await UserManager.GetClaimsAsync(user);

            var model = new UserClaimsViewModel()
            {
                UserId = userId
            };
            foreach (Claim claim in ClaimsList)
            {
                var claims = new ClaimViewModel()
                {
                    ClaimType = claim.Type,
                    ClaimTypeValue = claim.Value
                };

                if (existingUserClaims.Any(c => c.Type == claim.Value))
                {
                    claims.IsSelected = true;
                }
                userClaims.Add(claims);
            }
        }

        //[Authorize(Policy = "ViewUserClaim")]
        [HttpGet]
        public async Task<IActionResult> IndexUsersClaims(string userId)
        {
            try
            {
                string decryptUserId = protector.Unprotect(userId);
                var user = await UserManager.FindByIdAsync(decryptUserId);

                if (user == null)
                {
                    return View("NotFound");
                }
                ViewBag.UserName = "User " + user.UserName;

                await GetAllUserClaims(decryptUserId);

                List<ClaimViewModel> formattedUserClaim = new List<ClaimViewModel>();
                foreach (var item in varClaims)
                {
                    var claim = userClaims.Where(x => x.ClaimType == item.ClaimType).FirstOrDefault();

                    var newClaim = new ClaimViewModel()
                    {
                        ClaimType = claim.ClaimType,
                        ClaimTypeValue = claim.ClaimTypeValue,
                        IsSelected = claim.IsSelected,
                        GroupId = item.GroupId
                    };
                    formattedUserClaim.Add(newClaim);
                }

                ViewBag.GroupClaims = Context.ClaimGroups.ToList();
                ViewBag.List = formattedUserClaim;
                ViewBag.UserId = userId;

                return View();

            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        //[Authorize(Policy = "CreateUserClaim")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateUsersClaims(List<ClaimViewModel> claimsList, string userId)
        {
            using (var dbContext = Context.Database.BeginTransaction())
            {
                try
                {
                    var staffonlyClaim = new ClaimViewModel()
                    {
                        ClaimType = "Staff",
                        IsSelected = true
                    };
                    claimsList.Add(staffonlyClaim);

                    string decryptUserId = protector.Unprotect(userId);
                    var user = await UserManager.FindByIdAsync(decryptUserId);

                    if (user == null)
                    {
                        return Json(new { status = "3" });
                    }

                    var claims = await UserManager.GetClaimsAsync(user);
                    var result = await UserManager.RemoveClaimsAsync(user, claims);

                    if (!result.Succeeded)
                    {
                        dbContext.Rollback();
                        return Json(new { status = "3" });
                    }

                    var resultAddClaims = await UserManager.AddClaimsAsync(user, claimsList.ToList().Where(x => x.IsSelected == true).Select(x => new Claim(x.ClaimType, x.ClaimType)));

                    if (resultAddClaims.Succeeded)
                    {
                        dbContext.Commit();
                        return Json(new { status = "1" });
                    }
                    dbContext.Rollback();
                    return Json(new { status = "3" });
                }
                catch (Exception)
                {
                    dbContext.Rollback();
                    return Json(new { status = "4" });
                }
            }
        }

        #endregion

        #region Roles

        [HttpGet]
        public IActionResult RolesLoad()
        {
            try
            {
                List<RolesViewModel> roles = new List<RolesViewModel>();

                foreach (IdentityRole identityRole in RoleManager.Roles)
                {
                    var roleModel = new RolesViewModel()
                    {
                        EncryptRoleId = protector.Protect(identityRole.Id),
                        Rolename = identityRole.Name
                    };
                    roles.Add(roleModel);
                }
                return Json(new { data = roles });
            }
            catch (Exception)
            {
                return Json(new { status = "4" });
            }
        }


        List<RolesViewModel> roles = new List<RolesViewModel>();
        private void GetAllRoles()
        {
            roles = new List<RolesViewModel>();

            foreach (IdentityRole identityRole in RoleManager.Roles)
            {
                var roleModel = new RolesViewModel()
                {
                    EncryptRoleId = protector.Protect(identityRole.Id),
                    Rolename = identityRole.Name
                };
                roles.Add(roleModel);
            }
        }

        [Authorize(Policy = "ViewRole")]
        public IActionResult IndexRoles()
        {
            GetAllRoles();

            ViewBag.Count = roles.Count;

            return View();
        }

        [Authorize(Policy = "CreateRole")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateRole([Bind("Rolename")] [FromBody] RolesViewModel rolesViewModel)
        {
            try
            {
                var role = new IdentityRole { Name = rolesViewModel.Rolename };
                var result = await RoleManager.CreateAsync(role);

                if (result.Succeeded)
                {
                    GetAllRoles();

                    rolesViewModel.EncryptRoleId = protector.Protect(role.Id);

                    return Json(new { status = "1", rolesViewModel, roles.Count });
                }

                bool duplicates = false;
                string message = "";
                foreach (var error in result.Errors)
                {
                    if (error.Code == "DuplicateRoleName")
                    {
                        duplicates = true;
                        message = error.Description;
                    }
                }

                if (duplicates)
                {
                    return Json(new { status = "2", message });
                }
                else
                {
                    return Json(new { status = "3" });
                }
            }
            catch (Exception)
            {
                return Json(new { status = "4" });
            }
        }

        [Authorize(Policy = "ModifyRole")]
        [HttpGet]
        public async Task<IActionResult> EditRole(string id)
        {
            try
            {
                if (id == null)
                {
                    return Json(new { status = "4" });
                }

                string decryptRoleId = protector.Unprotect(id);
                IdentityRole role = await RoleManager.FindByIdAsync(decryptRoleId);

                if (role == null)
                {
                    return Json(new { status = "4" });
                }
                else
                {
                    var roleModel = new RolesViewModel()
                    {
                        EncryptRoleId = id,
                        MRolename = role.Name
                    };
                    return PartialView("_PartialRoleEdit", roleModel);
                }
            }
            catch (Exception)
            {
                return Json(new { status = "4" });
            }
        }

        [Authorize(Policy = "ModifyRole")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditRole([Bind("EncryptRoleId", "Rolename")] [FromBody] RolesViewModel rolesViewModel)
        {
            try
            {
                string decryptRoleId = protector.Unprotect(rolesViewModel.EncryptRoleId);
                IdentityRole role = await RoleManager.FindByIdAsync(decryptRoleId);

                role.Name = rolesViewModel.Rolename;

                var result = await RoleManager.UpdateAsync(role);

                if (result.Succeeded)
                {
                    return Json(new { status = "1", rolesViewModel });
                }

                bool duplicates = false;
                string message = "";
                foreach (var error in result.Errors)
                {
                    if (error.Code == "DuplicateRoleName")
                    {
                        duplicates = true;
                        message = error.Description;
                    }
                }

                if (duplicates)
                {
                    return Json(new { status = "2", message });
                }
                else
                {
                    return Json(new { status = "3" });
                }
            }
            catch (Exception)
            {
                return Json(new { status = "4" });
            }
        }

        [Authorize(Policy = "RemoveRole")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteRole([FromBody] string RoleId)
        {
            try
            {
                string decryptRoleId = protector.Unprotect(RoleId);
                IdentityRole role = await RoleManager.FindByIdAsync(decryptRoleId);

                var result = await RoleManager.DeleteAsync(role);

                if (result.Succeeded)
                {
                    return Json(new { status = "1" });
                }
                else
                {
                    return Json(new { status = "3" });
                }
            }
            catch (Exception)
            {
                return Json(new { status = "4" });
            }
        }
        #endregion

        #region Users-Roles

        List<UsersRolesViewModel> userRoles = new List<UsersRolesViewModel>();
        private async Task GetAllUsersRoles(string roleName)
        {
            userRoles = new List<UsersRolesViewModel>();

            foreach (ApplicationUser identityUser in UserManager.Users.Where(x => x.UserType == "I"))
            {
                var userRolesModel = new UsersRolesViewModel()
                {
                    EncryptUserId = protector.Protect(identityUser.Id),
                    Username = identityUser.UserName,
                };

                if (await UserManager.IsInRoleAsync(identityUser, roleName))
                {
                    userRolesModel.IsSelected = true;
                }
                userRoles.Add(userRolesModel);
                userRoles.Sort((x, y) => x.Username.CompareTo(y.Username));
            }
        }

        [Authorize(Policy = "ViewRoleUser")]
        [HttpGet]
        public async Task<IActionResult> IndexUsersRoles(string roleId)
        {
            string decryptRoleId = protector.Unprotect(roleId);
            var role = await RoleManager.FindByIdAsync(decryptRoleId);

            if (role == null)
            {
                return View("Not Found");
            }

            ViewBag.RoleName = role.Name + " role";
            await GetAllUsersRoles(role.Name);

            ViewBag.List = userRoles;
            ViewBag.RoleId = roleId;

            return View();
        }

        //[Authorize(Policy = "CreateRoleUser")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateUsersRoles(List<UsersRolesViewModel> userRoleList, string roleId)
        {
            using (var dbContext = Context.Database.BeginTransaction())
            {
                try
                {
                    string decryptRoleId = protector.Unprotect(roleId);
                    var role = await RoleManager.FindByIdAsync(decryptRoleId);

                    if (role == null)
                    {
                        return Json(new { status = "3" });
                    }

                    int errorCount = 0;
                    for (int i = 0; i < userRoleList.Count; i++)
                    {
                        string decryptUserId = protector.Unprotect(userRoleList[i].UserId);
                        var user = await UserManager.FindByIdAsync(decryptUserId);

                        IdentityResult result = null;
                        if (userRoleList[i].IsSelected && !(await UserManager.IsInRoleAsync(user, role.Name)))
                        {
                            result = await UserManager.AddToRoleAsync(user, role.Name);
                        }
                        else if (!userRoleList[i].IsSelected && await UserManager.IsInRoleAsync(user, role.Name))
                        {
                            result = await UserManager.RemoveFromRoleAsync(user, role.Name);
                        }
                        else
                        {
                            continue;
                        }
                        if (!result.Succeeded)
                        {
                            errorCount++;
                        }
                    }

                    if (errorCount <= 0)
                    {
                        dbContext.Commit();
                        return Json(new { status = "1" });
                    }
                    dbContext.Rollback();
                    return Json(new { status = "3" });
                }
                catch (Exception)
                {
                    dbContext.Rollback();
                    return Json(new { status = "4" });
                }
            }
        }

        #endregion

        #region Role-Claims

        List<ClaimViewModel> roleClaims = new List<ClaimViewModel>();
        List<ClaimAction> varRoleClaims = new List<ClaimAction>();
        private async Task GetAllRoleClaims(string roleId)
        {
            roleClaims = new List<ClaimViewModel>();

            var role = await RoleManager.FindByIdAsync(roleId);

            List<Claim> ClaimsList = new List<Claim>();
            varRoleClaims = Context.ClaimActions.OrderBy(x => x.ClaimType).ToList();

            foreach (var item in varRoleClaims)
            {
                var claimsObj = new Claim(item.ClaimType, item.ClaimValue);

                ClaimsList.Add(claimsObj);
            }

            var existingRoleClaims = await RoleManager.GetClaimsAsync(role);

            var model = new RoleClaimsViewModel()
            {
                RoleId = roleId
            };

            foreach (Claim claim in ClaimsList)
            {
                var claims = new ClaimViewModel()
                {
                    ClaimType = claim.Type,
                    ClaimTypeValue = claim.Value
                };

                if (existingRoleClaims.Any(c => c.Type == claim.Value))
                {
                    claims.IsSelected = true;
                }
                roleClaims.Add(claims);
            }
        }

        //[Authorize(Policy = "ViewRoleClaim")]
        [HttpGet]
        public async Task<IActionResult> IndexRolesClaims(string roleId)
        {
            try
            {
                string decryptRoleId = protector.Unprotect(roleId);
                var role = await RoleManager.FindByIdAsync(decryptRoleId);

                if (role == null)
                {
                    return View("NotFound");
                }
                ViewBag.RoleName = role.Name + " role";
                await GetAllRoleClaims(decryptRoleId);

                List<ClaimViewModel> formattedRoleClaim = new List<ClaimViewModel>();
                foreach (var item in varRoleClaims)
                {
                    var claim = roleClaims.Where(x => x.ClaimType == item.ClaimType).FirstOrDefault();

                    var newClaim2 = new ClaimViewModel()
                    {
                        ClaimType = claim.ClaimType,
                        ClaimTypeValue = claim.ClaimTypeValue,
                        IsSelected = claim.IsSelected,
                        GroupId = item.GroupId
                    };
                    formattedRoleClaim.Add(newClaim2);
                }

                ViewBag.GroupClaims = Context.ClaimGroups.ToList();
                ViewBag.List = formattedRoleClaim;
                ViewBag.RoleId = roleId;

                return View();

            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        //[Authorize(Policy = "CreateRoleClaim")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateRolesClaims(List<ClaimViewModel> claimsList, string roleId)
        {
            using (var dbContext = Context.Database.BeginTransaction())
            {
                try
                {
                    var staffonlyClaim = new ClaimViewModel()
                    {
                        ClaimType = "Staff",
                        IsSelected = true
                    };
                    claimsList.Add(staffonlyClaim);

                    string decryptRoleId = protector.Unprotect(roleId);
                    var role = await RoleManager.FindByIdAsync(decryptRoleId);

                    if (role == null)
                    {
                        return Json(new { status = "3" });
                    }
                    var existingRoleClaims = await RoleManager.GetClaimsAsync(role);

                    int errorCount = 0;
                    foreach (Claim claim in existingRoleClaims)
                    {
                        var result = await RoleManager.RemoveClaimAsync(role, claim);

                        if (!result.Succeeded)
                        {
                            errorCount++;
                        }
                    }

                    if (errorCount > 0)
                    {
                        dbContext.Rollback();
                        return Json(new { status = "3" });
                    }

                    errorCount = 0;
                    foreach (var item in claimsList)
                    {
                        IdentityResult resultAddClaims = null;
                        if (item.IsSelected)
                        {
                            resultAddClaims = await RoleManager.AddClaimAsync(role, new Claim(item.ClaimType, item.ClaimType));
                        }

                        if (resultAddClaims != null && !resultAddClaims.Succeeded)
                        {
                            errorCount++;
                        }
                    }

                    if (errorCount > 0)
                    {
                        dbContext.Rollback();
                        return Json(new { status = "3" });
                    }
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

        #region University

        //[Authorize(Policy = "ViewUniversity")]
        public IActionResult IndexUniversity()
        {
            try
            {
                var company = (from c in Context.MasterCompanies
                               select new MasterCompany()
                               {
                                   CompanyName = c.CompanyName,
                                   ShortName = c.ShortName,
                                   Telephone = c.Telephone,
                                   WorkTelephone = c.WorkTelephone,
                                   CompanyEmail = c.CompanyEmail,
                                   Address = c.Address,
                                   LinkedIn = c.LinkedIn,
                                   Facebook = c.Facebook,
                                   Instagram = c.Instagram,
                                   Twitter = c.Twitter,
                                   Youtube = c.Youtube,
                                   Email = c.Email,
                                   MEmailPassword = c.EmailPassword,
                                   ProfileImgPath = c.ProfileImgPath
                               }).FirstOrDefault();


                return View(company);
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        //[Authorize(Policy = "CreateUniversity")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateUniversity(MasterCompany masterCompany)
        {
            try
            {
                var company = Context.MasterCompanies.FirstOrDefault();

                if (company != null)
                {
                    company.CompanyName = masterCompany.CompanyName.ToUpper();
                    company.ShortName = masterCompany.ShortName.ToUpper();
                    company.Email = masterCompany.Email;
                    company.EmailPassword = masterCompany.EmailPassword != null ? CommonMethods.EncryptText(masterCompany.EmailPassword) : masterCompany.MEmailPassword;
                    company.Address = masterCompany.Address;
                    company.Telephone = masterCompany.Telephone;
                    company.WorkTelephone = masterCompany.WorkTelephone;
                    company.CompanyEmail = masterCompany.CompanyEmail;
                    company.Twitter = masterCompany.Twitter;
                    company.Facebook = masterCompany.Facebook;
                    company.LinkedIn = masterCompany.LinkedIn;
                    company.Instagram = masterCompany.Instagram;
                    company.Youtube = masterCompany.Youtube;

                    if (masterCompany.IsImageChange || masterCompany.IsImageDeleted)
                    {
                        string fileExtension = null;
                        if (masterCompany.UniversityImageFile != null)
                        {
                            fileExtension = Path.GetExtension(masterCompany.UniversityImageFile.FileName);
                            string filePath = Path.Combine(WebHostEnvironment.WebRootPath, $@"Resources/Uploads/University") + $@"/{"UniversityPicture" + fileExtension}";

                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                masterCompany.UniversityImageFile.CopyTo(stream);
                            }
                        }
                        company.ProfileImgPath = company.UniversityImageFile != null ? "UniversityPicture" + fileExtension : null;
                    }
                }
                else
                {
                    var newCompany = new MasterCompany()
                    {
                        CompID = "KU" + DateTime.Now.Ticks.ToString().Substring(0, 7),
                        CompanyName = masterCompany.CompanyName.ToUpper(),
                        ShortName = masterCompany.ShortName.ToUpper(),
                        Email = masterCompany.Email,
                        EmailPassword = CommonMethods.EncryptText(masterCompany.EmailPassword),
                        Address = masterCompany.Address,
                        Telephone = masterCompany.Telephone,
                        WorkTelephone = masterCompany.WorkTelephone,
                        CompanyEmail = masterCompany.CompanyEmail,
                        Twitter = masterCompany.Twitter,
                        Facebook = masterCompany.Facebook,
                        LinkedIn = masterCompany.LinkedIn,
                        Instagram = masterCompany.Instagram,
                        Youtube = masterCompany.Youtube
                    };

                    if (masterCompany.IsImageChange || masterCompany.IsImageDeleted)
                    {
                        string fileExtension = null;
                        if (masterCompany.UniversityImageFile != null)
                        {
                            fileExtension = Path.GetExtension(masterCompany.UniversityImageFile.FileName);
                            string filePath = Path.Combine(WebHostEnvironment.WebRootPath, $@"Resources/Uploads/University") + $@"/{"UniversityPicture" + fileExtension}";

                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                masterCompany.UniversityImageFile.CopyTo(stream);
                            }
                        }
                        newCompany.ProfileImgPath = masterCompany.UniversityImageFile != null ? "UniversityPicture" + fileExtension : null;
                    }
                    Context.MasterCompanies.Add(newCompany);
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

        #region Temp-Login

        [HttpGet]
        public IActionResult StaffLoad()
        {
            try
            {
                IEnumerable<TempLogin> staffLogin = logins.Where(x => x.UserType == "I").Select(x => new TempLogin()
                {
                    User = x.User,
                    StringDate = x.RegisteredDate.ToString()
                });

                return Json(new { data = staffLogin });
            }
            catch (Exception)
            {
                return Json(new { status = "4" });
            }
        }

        [HttpGet]
        public IActionResult RegisteredLoad()
        {
            try
            {
                IEnumerable<TempLogin> registeredLogin = logins.Where(x => x.RegisteredState == "R" && x.UserType != "I");

                return Json(new { data = registeredLogin });
            }
            catch (Exception)
            {
                return Json(new { status = "4" });
            }
        }

        [HttpGet]
        public IActionResult ApprovedLoad()
        {
            try
            {
                IEnumerable<TempLogin> approvedLogin = logins.Where(x => x.RegisteredState == "A" && x.UserType != "I");

                return Json(new { data = approvedLogin });
            }
            catch (Exception)
            {
                return Json(new { status = "4" });
            }
        }

        [HttpGet]
        public IActionResult PendingLoad()
        {
            try
            {
                IEnumerable<TempLogin> pendingLogin = logins.Where(x => x.RegisteredState == "P" && x.UserType != "I");

                return Json(new { data = pendingLogin });
            }
            catch (Exception)
            {
                return Json(new { status = "4" });
            }
        }

        [HttpGet]
        public IActionResult DeactivatedLoad()
        {
            try
            {
                IEnumerable<TempLogin> deacivatedLogin = logins.Where(x => x.RegisteredState == "D" && x.UserType != "I");

                return Json(new { data = deacivatedLogin });
            }
            catch (Exception)
            {
                return Json(new { status = "4" });
            }
        }

        //[Authorize(Policy = "ViewLoginProfiles")]
        public IActionResult IndexTempLogin()
        {
            ViewBag.PendingCount = logins.Where(x => x.RegisteredState == "P" && x.UserType != "I").Count();
            ViewBag.RegisteredCount = logins.Where(x => x.RegisteredState == "R" && x.UserType != "I").Count();
            ViewBag.DeactivatedCount = logins.Where(x => x.RegisteredState == "D" && x.UserType != "I").Count();
            ViewBag.ApprovedCount = logins.Where(x => x.RegisteredState == "A" && x.UserType != "I").Count();
            ViewBag.StaffCount = logins.Where(x => x.UserType == "I").Count();

            return View();
        }

        //[Authorize(Policy = "ApproveLoginProfiles")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ApproveProfiles(List<TempLogin> loginsApprove)
        {
            using (var dbContext = Context.Database.BeginTransaction())
            {
                try
                {
                    foreach (var item in loginsApprove)
                    {
                        string descryptAccessCode = protector.Unprotect(item.AccessCode);
                        var tempLogin = Context.TempLogins.Where(x => x.AccessCode == descryptAccessCode).FirstOrDefault();

                        if (tempLogin != null)
                        {
                            tempLogin.RegisteredState = "A";
                            tempLogin.ApproveddDate = DateTime.Now;
                        }
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

        //[Authorize(Policy = "DissaproveLoginProfiles")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DissapproveProfiles(List<TempLogin> loginsDissapprove)
        {
            using (var dbContext = Context.Database.BeginTransaction())
            {
                try
                {
                    foreach (var item in loginsDissapprove)
                    {
                        string descryptAccessCode = protector.Unprotect(item.AccessCode);
                        var tempLogin = Context.TempLogins.Where(x => x.AccessCode == descryptAccessCode).FirstOrDefault();

                        if (tempLogin != null)
                        {
                            tempLogin.RegisteredState = "P";
                            tempLogin.ApproveddDate = null;
                        }
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

        //[Authorize(Policy = "DeactivateLoginProfiles")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeactivateProfiles(List<TempLogin> loginsDeactivate)
        {
            using (var dbContext = Context.Database.BeginTransaction())
            {
                try
                {
                    foreach (var item in loginsDeactivate)
                    {
                        string descryptAccessCode = protector.Unprotect(item.AccessCode);
                        var tempLogin = Context.TempLogins.Where(x => x.AccessCode == descryptAccessCode).FirstOrDefault();

                        if (tempLogin != null)
                        {
                            tempLogin.RegisteredState = "D";
                            tempLogin.DeactivatedDate = DateTime.Now;
                        }
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

        //[Authorize(Policy = "RejectLoginProfiles")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RejectProfile([FromBody] string AccessCode)
        {
            try
            {
                string descryptAccessCode = protector.Unprotect(AccessCode);
                var tempLogin = Context.TempLogins.Where(x => x.AccessCode == descryptAccessCode).FirstOrDefault();

                if (tempLogin != null)
                {
                    Context.Remove(tempLogin);
                    Context.SaveChanges();

                    return Json(new { status = "1" });
                }
                return Json(new { status = "3" });
            }
            catch (Exception)
            {
                return Json(new { status = "4" });
            }
        }


        [HttpGet]
        public IActionResult LoginLoad()
        {
            try
            {
                IEnumerable<TempLogin> lectureLogins = (from t in Context.TempLogins
                                                        where t.UserType == "L" && t.RegisteredState == "P"
                                                        select new TempLogin()
                                                        {
                                                            Name = t.Name,
                                                            Tel = t.Tel,
                                                            Email = t.Email,
                                                            UserType = t.UserType,
                                                            EncryptAccessCode = protector.Protect(t.AccessCode)
                                                        }).ToList();

                IEnumerable<TempLogin> staffLogins = (from t in Context.TempLogins
                                                      where t.UserType == "I" && t.RegisteredState == "A"
                                                      select new TempLogin()
                                                      {
                                                          Name = t.Name,
                                                          Tel = t.Tel,
                                                          Email = t.Email,
                                                          UserType = t.UserType,
                                                          EncryptAccessCode = protector.Protect(t.AccessCode)
                                                      }).ToList();

                IEnumerable<TempLogin> staffAssistLogins = (from t in Context.TempLogins
                                                            where t.UserType == "A" && t.RegisteredState == "A"
                                                            select new TempLogin()
                                                            {
                                                                Name = t.Name,
                                                                Tel = t.Tel,
                                                                Email = t.Email,
                                                                UserType = t.UserType,
                                                                EncryptAccessCode = protector.Protect(t.AccessCode)
                                                            }).ToList();

                IEnumerable<TempLogin> studentLogins = (from t in Context.TempLogins
                                                        where t.UserType == "S" && t.RegisteredState == "A"
                                                        select new TempLogin()
                                                        {
                                                            Name = t.Name,
                                                            Tel = t.Tel,
                                                            Email = t.Email,
                                                            UserType = t.UserType,
                                                            EncryptAccessCode = protector.Protect(t.AccessCode)
                                                        }).ToList();

                IEnumerable<TempLogin> pendingLogins = lectureLogins.Union(staffLogins).Union(staffAssistLogins).Union(studentLogins);


                return Json(new { data = pendingLogins });
            }
            catch (Exception)
            {
                return Json(new { status = "4" });
            }
        }


        //[Authorize(Policy = "CreateLoginProfiles")]
        public IActionResult IndexTempLoginCreate()
        {
            try
            {
                var tempLoginsTeachers = Context.TempLogins.Where(x => x.UserType == "L" && x.RegisteredState == "P").Select(x => x.UserType).ToList().Count();
                var tempLoginsStaff = Context.TempLogins.Where(x => x.UserType == "I" && x.RegisteredState == "A").Select(x => x.UserType).ToList().Count();
                var tempLoginsStaffAssist = Context.TempLogins.Where(x => x.UserType == "A" && x.RegisteredState == "A").Select(x => x.UserType).ToList().Count();
                var tempLoginsStudent = Context.TempLogins.Where(x => x.UserType == "S" && x.RegisteredState == "A").Select(x => x.UserType).ToList().Count();

                ViewBag.Count = tempLoginsTeachers + tempLoginsStaff + tempLoginsStaffAssist + tempLoginsStudent;

                return View();
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        //[Authorize(Policy = "CreateLoginProfiles")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateTempLogin([Bind("Name", "Tel", "Email", "UserType")] [FromBody] TempLogin tempObj)
        {
            try
            {
                if (!string.IsNullOrEmpty(tempObj.Email))
                {
                    var tempLogin = Context.TempLogins.Where(x => x.Email == tempObj.Email).FirstOrDefault();

                    if (tempLogin != null)
                    {
                        return Json(new { status = "2" });
                    }
                }
                else
                {
                    var tempLoginStudent = Context.TempLogins.Where(x => x.AdmissionNo == tempObj.AdmissionNo).FirstOrDefault();

                    if (tempLoginStudent != null)
                    {
                        return Json(new { status = "2" });
                    }
                }

                TempLogin tempLoginObj = null;

                if (tempObj.UserType == "I")
                {
                    tempLoginObj = new TempLogin()
                    {
                        AccessCode = Guid.NewGuid().ToString(),
                        Name = tempObj.Name,
                        Tel = tempObj.Tel,
                        Email = tempObj.Email,
                        UserType = "I",
                        RegisteredState = "A",
                        ApproveddDate = DateTime.Now,
                        IsExternal = false
                    };

                    var schoolInfo = Context.MasterCompanies.FirstOrDefault();

                    if (schoolInfo != null && schoolInfo.Email != null)
                    {
                        #region Email Send
                        string File_Path = Path.Combine(WebHostEnvironment.WebRootPath, EmailUtil.WelcomeEmail.GetFile());
                        StreamReader strR = new StreamReader(File_Path);
                        string Mail_Text = strR.ReadToEnd();
                        strR.Close();

                        // EmailUtil.WelcomeEmail.CreateEmail(schoolInfo, MailText, tempLoginObj.AccessCode, tempLoginObj.Email);                        
                        #endregion

                    }
                }
                else if (tempObj.UserType == "L")
                {
                    tempLoginObj = new TempLogin()
                    {
                        AccessCode = Guid.NewGuid().ToString(),
                        AdmissionNo = DateTime.Now.Ticks.ToString().Substring(0, 2) + DateTime.Now.Ticks.ToString().Substring(6, 3),
                        Email = tempObj.Email,
                        UserType = "L",
                        RegisteredState = "P",
                        ApproveddDate = DateTime.Now,
                        IsExternal = false
                    };
                }
                else if (tempObj.UserType == "A")
                {
                    tempLoginObj = new TempLogin()
                    {
                        AccessCode = Guid.NewGuid().ToString(),
                        AdmissionNo = DateTime.Now.Ticks.ToString().Substring(0, 2) + DateTime.Now.Ticks.ToString().Substring(6, 3),
                        Email = tempObj.Email,
                        UserType = "A",
                        RegisteredState = "P",
                        ApproveddDate = DateTime.Now,
                        IsExternal = false
                    };
                }

                else
                {
                    tempLoginObj = new TempLogin()
                    {
                        AccessCode = Guid.NewGuid().ToString(),
                        AdmissionNo = DateTime.Now.Ticks.ToString().Substring(0, 2) + DateTime.Now.Ticks.ToString().Substring(6, 3),
                        Email = tempObj.Email,
                        UserType = "S",
                        RegisteredState = "P",
                        ApproveddDate = DateTime.Now,
                        IsExternal = false
                    };
                }
                Context.TempLogins.Add(tempLoginObj);
                Context.SaveChanges();

                #region Email Send
                string bodyText = "Crete your Login by using this Access Code (please copy and paste): " + tempLoginObj.AccessCode;
                var message = new Message(new string[] { tempLoginObj.Email }, "Access Code for KLN CMS", bodyText);
                _emailSender.sendEmail(message);
                #endregion

                tempObj.EncryptAccessCode = protector.Protect(tempLoginObj.AccessCode);

                return Json(new { status = "1", tempObj });
            }
            catch (Exception ex)
            {
                return Json(new { status = ex.ToString() });
            }
        }

        //[Authorize(Policy = "ModifyLoginProfiles")]
        [HttpGet]
        public IActionResult EditTempLogin(string code)
        {
            try
            {
                string decryptAccessCode = protector.Unprotect(code);
                var tempLogin = Context.TempLogins.Where(x => x.AccessCode == decryptAccessCode).FirstOrDefault();

                var tempLoginObj = new TempLogin()
                {
                    EncryptAccessCode = code,
                    MName = tempLogin.Name,
                    MTel = tempLogin.Tel,
                    MEmail = tempLogin.Email,
                    MUserType = tempLogin.UserType
                };

                return PartialView("_PartialTempLoginEdit", tempLoginObj);
            }
            catch (Exception)
            {
                return Json(new { status = "4" });
            }
        }

        //[Authorize(Policy = "ModifyLoginProfiles")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditTempLogin([FromBody] TempLogin tempLogin)
        {
            try
            {
                string decryptAccessCode = protector.Unprotect(tempLogin.EncryptAccessCode);
                var tempAc = Context.TempLogins.Where(x => x.AccessCode == decryptAccessCode).FirstOrDefault();

                tempAc.Name = tempLogin.Name;
                tempAc.Tel = tempLogin.Tel;
                tempAc.Email = tempLogin.UserType == "S" ? tempLogin.AdmissionNo + "@test.com" : tempLogin.Email;
                tempAc.UserType = tempLogin.UserType;

                Context.SaveChanges();
                tempLogin.Email = tempAc.Email;

                return Json(new { status = "1", tempLogin });
            }
            catch (Exception)
            {
                return Json(new { status = "4" });
            }
        }

        //[Authorize(Policy = "RemoveLoginProfiles")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteTempLogin([FromBody] string TempId)
        {
            try
            {
                string decryptAccessCode = protector.Unprotect(TempId);
                var tempLogin = Context.TempLogins.Where(x => x.AccessCode == decryptAccessCode).FirstOrDefault();

                if (tempLogin != null)
                {
                    Context.Remove(tempLogin);

                    Context.SaveChanges();
                    return Json(new { status = "1" });
                }
                return Json(new { status = "3" });
            }
            catch (Exception)
            {
                return Json(new { status = "4" });
            }
        }

        #endregion

        #region Pending Profiles


        #region Lecturer
        [HttpGet]
        public IActionResult PendingLecturerLoad()
        {
            try
            {
                IEnumerable<Lecturer> lecturerList = (from l in Context.Lecturers
                                                      where l.LecturerStatus == "P"
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


        //[Authorize(Policy = "ViewPendingProfiles")]
        [HttpGet]
        public IActionResult IndexPendingLecturers()
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


        //[Authorize(Policy = "ViewPendingProfiles")]
        public IActionResult ViewPendingLecturer(string EncryptLecturerId)
        {
            try
            {
                var descryptId = protector.Unprotect(EncryptLecturerId);

                var genders = Context.MasterGenders.OrderBy(x => x.Gender).ToList();
                var titles = Context.MasterTitles.OrderBy(x => x.Title).ToList();

                ViewBag.Titles = new SelectList(titles, "Title", "Title");
                ViewBag.Gender = new SelectList(genders, "Gender", "Gender");

                var lecturerObj = Context.Lecturers.Where(x => x.LecturerId == descryptId).FirstOrDefault();

                if (lecturerObj != null)
                {
                    return View(lecturerObj);
                }
                return View();
            }
            catch (Exception)
            {
                return View("Error");
            }
        }


        //[Authorize(Policy = "ApprovePendingProfiles")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ApproveLecturerProfile(Lecturer lecturer)
        {
            try
            {
                var lecturerObj = Context.Lecturers.Where(x => x.LecturerId == lecturer.LecturerId).FirstOrDefault();

                if (lecturerObj != null)
                {
                    lecturerObj.Title = lecturerObj.Title;
                    lecturerObj.JoinedDate = lecturerObj.JoinedDate.Date;
                    lecturerObj.FName = lecturerObj.FName;
                    lecturerObj.SName = lecturerObj.SName;
                    lecturerObj.Dob = lecturerObj.Dob;
                    lecturerObj.Email = lecturerObj.Email;
                    lecturerObj.Mobile = lecturerObj.Mobile;
                    lecturerObj.HomeTel = lecturerObj.HomeTel;
                    lecturerObj.OfficeTel = lecturerObj.OfficeTel;
                    lecturerObj.Gender = lecturerObj.Gender;
                    lecturerObj.Qualifications = lecturerObj.Qualifications;
                    lecturerObj.ProfileStatus = "A";
                    lecturerObj.LecturerStatus = "A";

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
                Context.SaveChanges();
                return Json(new { status = "1" });
            }
            catch (Exception)
            {
                return Json(new { status = "4" });
            }
        }


        //[Authorize(Policy = "DeletePendingProfiles")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePendingLecturer([FromBody] string id)
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

        #endregion


    }
}