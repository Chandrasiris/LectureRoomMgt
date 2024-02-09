using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using LectureRoomMgt.DAL;
using LectureRoomMgt.Models;
using LectureRoomMgt.Models.Staff;
using LectureRoomMgt.Security;

namespace LectureRoomMgt.Controllers
{
    [Authorize]
    public class BasicDataController : Controller
    {
        public WisdomAppDBContext Context { get; }
        public IDataProtector protector { get; }


        public BasicDataController(WisdomAppDBContext wisdomAppDBContext,
                                    IDataProtectionProvider dataProtectionProvider,
                                    DataProtectionPurposeStrings dataProtectionPurposeStrings)
        {
            Context = wisdomAppDBContext;
            protector = dataProtectionProvider.CreateProtector(dataProtectionPurposeStrings.BasicDataId);
        }

        [Authorize(Policy = "ViewBasicData")]
        public IActionResult IndexBasic()
        {
            try
            {
                ViewBag.TitleCount = Context.MasterTitles.ToList().Count;
                ViewBag.GenderCount = Context.MasterGenders.ToList().Count;
                ViewBag.DesignationCount = Context.MasterDesignations.ToList().Count;
                ViewBag.ComTypeCount = Context.CommunicationTypes.ToList().Count;

                return View();
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        #region Master Titles

        [HttpGet]
        public IActionResult TitleLoad()
        {
            try
            {
                IEnumerable<MasterTitle> titles = (from l in Context.MasterTitles
                                                   select new MasterTitle
                                                   {
                                                       EncryptTitleId = protector.Protect(l.Id.ToString()),
                                                       Title = l.Title
                                                   }).ToList();
                return Json(new { data = titles });
            }
            catch (Exception)
            {
                return Json(new { status = "4" });
            }
        }

        [Authorize(Policy = "CreateBasicData")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateTitle([FromBody] MasterTitle titleObj)
        {
            try
            {
                var title = new MasterTitle()
                {
                    Title = titleObj.Title,
                };
                Context.MasterTitles.Add(title);
                Context.SaveChanges();

                titleObj.EncryptTitleId = protector.Protect(title.Id.ToString());

                return Json(new { status = "1", titleObj });
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


        [Authorize(Policy = "RemoveBasicData")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteTitle([FromBody] string id)
        {
            try
            {
                int decrypTitleId = int.Parse(protector.Unprotect(id));
                var titleObj = Context.MasterTitles.Where(x => x.Id == decrypTitleId).FirstOrDefault();

                Context.Remove(titleObj);
                Context.SaveChanges();
                
                return Json(new { status = "1" });
            }
            catch (Exception ex)
            {
                if (ex.InnerException.Message.Contains("The DELETE statement conflicted with the REFERENCE constraint"))
                {
                    return Json(new { status = "3" });
                }
                return Json(new { status = "4" });
            }
        }

        #endregion

        #region Master Genders

        [HttpGet]
        public IActionResult GenderLoad()
        {
            try
            {
                IEnumerable<MasterGender> genders = (from l in Context.MasterGenders
                                                   select new MasterGender
                                                 {
                                                     EncryptGenderId = protector.Protect(l.Id.ToString()),
                                                     Gender = l.Gender
                                                   }).ToList();
                return Json(new { data = genders });
            }
            catch (Exception)
            {
                return Json(new { status = "4" });
            }
        }

        [Authorize(Policy = "CreateBasicData")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateGender([FromBody] MasterGender genderObj)
        {
            try
            {
                var genderNew = new MasterGender()
                {
                    Gender = genderObj.Gender,
                };
                Context.MasterGenders.Add(genderNew);
                Context.SaveChanges();

                genderObj.EncryptGenderId = protector.Protect(genderNew.Id.ToString());

                return Json(new { status = "1", genderObj });
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


        [Authorize(Policy = "RemoveBasicData")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteGender([FromBody] string id)
        {
            try
            {
                int decryptGenderId = int.Parse(protector.Unprotect(id));
                var genderObj = Context.MasterGenders.Where(x => x.Id == decryptGenderId).FirstOrDefault();

                Context.Remove(genderObj);
                Context.SaveChanges();

                return Json(new { status = "1" });
            }
            catch (Exception ex)
            {
                if (ex.InnerException.Message.Contains("The DELETE statement conflicted with the REFERENCE constraint"))
                {
                    return Json(new { status = "3" });
                }
                return Json(new { status = "4" });
            }
        }

        #endregion

        #region Master Designation

        [HttpGet]
        public IActionResult DesignationLoad()
        {
            try
            {
                IEnumerable<MasterDesignation> designations = (from l in Context.MasterDesignations
                                                               select new MasterDesignation
                                                               {
                                                                   EncryptDesignationId = protector.Protect(l.Id.ToString()),
                                                                   Designation = l.Designation
                                                               }).ToList();
                return Json(new { data = designations });
            }
            catch (Exception)
            {
                return Json(new { status = "4" });
            }
        }

        [Authorize(Policy = "CreateBasicData")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateDesignation([FromBody] MasterDesignation designationObj)
        {
            try
            {
                var designationNew = new MasterDesignation()
                {
                    Designation = designationObj.Designation,
                };
                Context.MasterDesignations.Add(designationNew);
                Context.SaveChanges();

                designationObj.EncryptDesignationId = protector.Protect(designationNew.Id.ToString());

                return Json(new { status = "1", designationObj });
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


        [Authorize(Policy = "RemoveBasicData")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteDesignation([FromBody] string id)
        {
            try
            {
                int decryptDesignationId = int.Parse(protector.Unprotect(id));
                var designationObj = Context.MasterDesignations.Where(x => x.Id == decryptDesignationId).FirstOrDefault();

                Context.Remove(designationObj);
                Context.SaveChanges();

                return Json(new { status = "1" });
            }
            catch (Exception ex)
            {
                if (ex.InnerException.Message.Contains("The DELETE statement conflicted with the REFERENCE constraint"))
                {
                    return Json(new { status = "3" });
                }
                return Json(new { status = "4" });
            }
        }

        #endregion

        #region Communication Types

        [HttpGet]
        public IActionResult ComTypesLoad()
        {
            try
            {
                IEnumerable<CommunicationType> communications = (from l in Context.CommunicationTypes
                                                                 select new CommunicationType
                                                                 {
                                                                     EncryptComType = protector.Protect(l.Id.ToString()),
                                                                     ComType = l.ComType
                                                                 }).ToList();
                return Json(new { data = communications });
            }
            catch (Exception)
            {
                return Json(new { status = "4" });
            }
        }

        [Authorize(Policy = "CreateBasicData")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateComType([FromBody] CommunicationType communicationObj)
        {
            try
            {
                var comTypeNew = new CommunicationType()
                {
                    ComType = communicationObj.ComType,
                };
                Context.CommunicationTypes.Add(comTypeNew);
                Context.SaveChanges();

                communicationObj.EncryptComType = protector.Protect(comTypeNew.Id.ToString());

                return Json(new { status = "1", communicationObj });
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


        [Authorize(Policy = "RemoveBasicData")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteComType([FromBody] string id)
        {
            try
            {
                int decryptComTypeId = int.Parse(protector.Unprotect(id));
                var comTypeObj = Context.CommunicationTypes.Where(x => x.Id == decryptComTypeId).FirstOrDefault();

                Context.Remove(comTypeObj);
                Context.SaveChanges();

                return Json(new { status = "1" });
            }
            catch (Exception ex)
            {
                if (ex.InnerException.Message.Contains("The DELETE statement conflicted with the REFERENCE constraint"))
                {
                    return Json(new { status = "3" });
                }
                return Json(new { status = "4" });
            }
        }

        #endregion

    }
}