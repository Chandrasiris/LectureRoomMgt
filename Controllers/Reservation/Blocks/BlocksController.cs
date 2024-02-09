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
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LectureRoomMgt.Controllers.Reservation.Blocks
{
    public class BlocksController : Controller
    {
        public UserManager<ApplicationUser> UserManager { get; }
        public SignInManager<ApplicationUser> SignInManager { get; }
        public WisdomAppDBContext Context { get; }
        private static bool UpdateDatabase = false;
        private ISession session;
        public ISession Session { get { return session; } }
        public BlocksController(UserManager<ApplicationUser> userManager,
                                 SignInManager<ApplicationUser> signInManager,
                                 WisdomAppDBContext wisdomAppDBContext, IHttpContextAccessor httpContextAccessor
                                 )
        {
            UserManager = userManager;
            SignInManager = signInManager;
            Context = wisdomAppDBContext;
            session = httpContextAccessor.HttpContext.Session;

        }
        public IActionResult BlockIndex()
        {
            ViewBag.Faculties = new SelectList(Context.Faculties.ToList(), "Id", "FacultyName");
            return View();
        }


        [HttpPost]
        public IActionResult BlockIndex(BlockVM blockVM)
        {
            if (blockVM.CallType == "B")
            {
                return Json(new { status = "1", redirectUrl = Url.Action("Block", "Blocks", new { FacId = blockVM.FacultyId }) });
            }
            else
            {
                return Json(new { status = "1", redirectUrl = Url.Action("BlockIndex", "Blocks", new { FacId = blockVM.FacultyId }) });
            }
        }


        public IActionResult Block(int FacId)
        {
            ViewBag.FacultyName = Context.Faculties.Where(x => x.Id == FacId).FirstOrDefault().FacultyName;
            ViewBag.FacId = FacId;

            return View();
        }



        private void PopulateFaculties()
        {
            using (Context)
            {
                var faculties = Context.Faculties.Select(c => new FacultyDD //1
                            {
                                FacutyId = c.Id,
                                 FacultyName= c.FacultyName
                            })
                            .OrderBy(e => e.FacultyName);
                ViewData["faculties"] = faculties.ToList();
                ViewData["defaultFaculty"] = faculties.First();
            }
        }
        public JsonResult GetFaculties()
        {            
                return Json(Context.Faculties
                    .Select(c => new { Id = c.Id, Name = c.FacultyName }).OrderBy(c => c.Name).ToList()); 
        }
        public ActionResult ReadBlocksOfSelectedFac(int FacultyId = 0)
        {
            return View("BlockIndex", BlocksOfFaculties(FacultyId));
        }
        private IList<BlockVM> BlocksOfFaculties(int facId = 0)
        {
            var info = from sc in Context.Blocks
                       where sc.FacultyId==facId
                       select new
                       {
                           sc.BlockName,  
                           sc.Faculty.FacultyName,
                           sc.FacultyId
                       };
            var result = info.AsEnumerable().Select(st =>
            {
                return new BlockVM
                {
                    BlockName = st.BlockName,
                    FacultyName=st.FacultyName,
                    FacultyId=st.FacultyId
                };
            }).ToList();
            return result;
        }

        public ActionResult Read([DataSourceRequest] DataSourceRequest request, int facultyId=0)
        {
            return Json(ReadData().ToDataSourceResult(request),facultyId);
        }
        public IEnumerable<BlockVM> ReadData(int facultyId=0) //1
        {
            return GetAll(facultyId);
        }

        public IList<BlockVM> GetAll(int facultyId=0)//1
        {
            using (Context)
            {
                var result = Session.GetObjectFromJson<IList<BlockVM>>("Blocks"); //1

                if (result == null || UpdateDatabase)
                {
                    var faculties = Context.Faculties.Where(c=>c.Id == facultyId).ToList();
                    if (faculties.Count>0)
                    {
                        result = Context.Blocks.ToList().Select(f =>
                        {
                            var faculty = faculties.FirstOrDefault(c => f.FacultyId == c.Id);
                            return new BlockVM //1
                            {
                                Id = f.Id,
                                BlockName = f.BlockName,
                                //Code=f.Code,
                                FacultyId = f.FacultyId,
                               // FacultyDD = new FacultyDD()
                                //{ FacutyId = faculty.Id, FacultyName = faculty.FacultyName }
                            };
                        }).ToList();
                    }
                    Session.SetObjectAsJson("Blocks", result);
                }

                return result;
            }
        }
        [HttpPost]
        
        public ActionResult Create([DataSourceRequest] DataSourceRequest request, BlockVM block)
        {
            if (block != null && ModelState.IsValid )
            {
                Create(block);
            }
            return Json(new[] { block }.ToDataSourceResult(request, ModelState));
        }

        public ActionResult Create(BlockVM block)
        {           
            using (Context)
            {
                List<string> blocks = block.BlockName.Split(',').ToList<string>();
                // bool t = Context.Blocks.Where(c=>blocks.Contains(c.BlockName)).ToList().Count>0;

                if (block.FacultyId != null)
                { 
                    foreach (var item in blocks)
                    {
                        bool t = Context.Blocks.Where(c => c.BlockName == item && c.FacultyId == block.FacultyId).Count() == 0;
                        if (t)
                        {
                            var obj = new Block();
                            obj.BlockName = item;
                            obj.FacultyId = block.FacultyId;
                            Context.Blocks.Add(obj);
                        }                    
                    }               
                    Context.SaveChanges();
                }
                return View("BlockIndex");
            }            
        }
            public void Insert(Block blockObj)
        {    
                using (Context)
                {
                    var entity = new Block();                    
                    entity.BlockName = blockObj.BlockName;
                entity.FacultyId = blockObj.FacultyId;
                if (entity.FacultyId == null)
                {
                    entity.FacultyId = 1;
                }

                if (blockObj.Faculty != null)
                {
                    entity.FacultyId = blockObj.Faculty.Id;
                }
                Context.Blocks.Add(entity);
                    Context.SaveChanges();
                }            
        }
        [AcceptVerbs("Post")]
        public ActionResult Update([DataSourceRequest] DataSourceRequest request, Models.Reservation.Faculty facultyObj)
        {
            if (facultyObj != null && ModelState.IsValid)
            {
                UpdateData(facultyObj);
            }

            return Json(new[] { facultyObj }.ToDataSourceResult(request, ModelState));
        }
        public void UpdateData(Models.Reservation.Faculty facultyObj)
        {
            if (!UpdateDatabase)
            {               
                var target = Context.Faculties.FirstOrDefault(e => e.Id == facultyObj.Id);

                if (target != null)
                {
                    target.FacultyName = facultyObj.FacultyName;
                    target.Code = facultyObj.Code;                   
                }
                Context.Faculties.Attach(target);
               // db.Entry(entity).State = EntityState.Modified;
                Context.SaveChanges();
                Session.SetObjectAsJson("Faculties", facultyObj);
            }
           
        }
        [AcceptVerbs("Post")]
        public ActionResult Delete([DataSourceRequest] DataSourceRequest request, Models.Reservation.Faculty facultyObj)
        {
            if (facultyObj != null)
            {
                Destroy(facultyObj);
            }

            return Json(new[] { facultyObj }.ToDataSourceResult(request, ModelState));
        }
        public void Destroy(Models.Reservation.Faculty facultyObj)
        {
            if (!UpdateDatabase)
            {
                var target = Context.Faculties.FirstOrDefault(e => e.Id == facultyObj.Id);

                if (target != null)
                {
                    Context.Faculties.Remove(target);
                }               
                Context.SaveChanges();
                Session.SetObjectAsJson("Faculties", facultyObj);               
            }
           
        }


        #region Block
        public IActionResult LoadBlocks([DataSourceRequest]DataSourceRequest request, int FacId)
        {
            try
            {
                List<BlockVM> blocks = (from c in Context.Blocks
                                        where c.FacultyId == FacId
                                        select new BlockVM()
                                        {
                                            Id = c.Id,
                                            BlockName = c.BlockName,
                                            Comment = c.Comment,
                                            Status = c.Status
                                        }).ToList();

                return Json(blocks.ToDataSourceResult(request));
            }
            catch (Exception)
            {
                ModelState.AddModelError("Block", "An error has occured, Please contact administrator !");

                return Json(ModelState);
            }
        }


        [HttpPost]
        //[Authorize(Policy = "CreateBlock")]
        public ActionResult CreateBlock([DataSourceRequest]DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<BlockVM> blocks, int FacId)
        {
            try
            {
                var blockList = new List<Block>();
                var blockVmList = new List<BlockVM>();


                if (ModelState.IsValid && blocks != null)
                {
                    foreach (var item in blocks.Reverse())
                    {
                        var Block = new Block()
                        {
                            BlockName = item.BlockName,
                            Comment = item.Comment,
                            Status = item.Status,
                            FacultyId = FacId
                        };

                        blockList.Add(Block);
                    }
                    Context.Blocks.AddRange(blockList);
                    Context.SaveChanges();

                    blockVmList = (from c in blockList
                                   select new BlockVM()
                                   {
                                       Id = c.Id,
                                       BlockName = c.BlockName,
                                       Comment = c.Comment,
                                       Status = c.Status
                                   }).ToList();

                }
                return Json(blockVmList.ToDataSourceResult(request, ModelState));
            }
            catch (Exception e)
            {
                ModelState.AddModelError("Block", "An error has occured, Please contact administrator !");

                return Json(blocks.ToDataSourceResult(request, ModelState));
            }
        }


        [HttpPost]
        //[Authorize(Policy = "ModifyBlock")]
        public IActionResult EditBlock([DataSourceRequest]DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<BlockVM> blocks, int FacId)
        {
            try
            {
                if (ModelState.IsValid && blocks != null)
                {
                    foreach (var item in blocks)
                    {
                        var blockObj = Context.Blocks.Where(x => x.Id == item.Id && x.FacultyId == FacId).FirstOrDefault();

                        if (blockObj != null)
                        {
                            blockObj.BlockName = item.BlockName;
                            blockObj.Comment = item.Comment;
                            blockObj.Status = item.Status;

                            Context.SaveChanges();
                        }
                    }
                }
                return Json(blocks.ToDataSourceResult(request, ModelState));
            }
            catch (Exception ex)
            {
                if (ex.InnerException.Message.Contains("Cannot insert duplicate key row in object"))
                {
                    ModelState.AddModelError("Block", "Duplicate record exists !");
                    return Json(blocks.ToDataSourceResult(request, ModelState));
                }
                ModelState.AddModelError("Block", "An error has occured, Please contact administrator !");
                return Json(blocks.ToDataSourceResult(request, ModelState));
            }
        }


        [HttpPost]
        //[Authorize(Policy = "RemoveBlock")]
        public IActionResult DeleteBlock([DataSourceRequest]DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<BlockVM> blocks, int FacId)
        {
            try
            {
                var blocksList = new List<Block>();

                foreach (var item in blocks)
                {
                    var blockObj = Context.Blocks.Where(x => x.Id == item.Id && x.FacultyId == FacId).FirstOrDefault();
                    blocksList.Add(blockObj);
                }

                if (blocksList.Count > 0)
                {
                    Context.RemoveRange(blocksList);
                    Context.SaveChanges();
                }
                return Json(new[] { blocks }.ToDataSourceResult(request, ModelState));
            }
            catch (Exception ex)
            {
                if (ex.InnerException.Message.Contains("The DELETE statement conflicted with the REFERENCE constraint"))
                {
                    ModelState.AddModelError("Block", "Access denied as this row is used by other tables !");
                    return Json(new[] { blocks }.ToDataSourceResult(request, ModelState));
                }
                ModelState.AddModelError("Block", "An error has occured, Please contact administrator !");
                return Json(new[] { blocks }.ToDataSourceResult(request, ModelState));
            }
        }

        #endregion

    }
}
