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

namespace LectureRoomMgt.Controllers.Reservation.Faculty
{
    public class FacultyController : Controller
    {
        public UserManager<ApplicationUser> UserManager { get; }
        public SignInManager<ApplicationUser> SignInManager { get; }
        public WisdomAppDBContext Context { get; }
        private static bool UpdateDatabase = false;
        private ISession session;
        public ISession Session { get { return session; } }
        public FacultyController(UserManager<ApplicationUser> userManager,
                                 SignInManager<ApplicationUser> signInManager,
                                 WisdomAppDBContext wisdomAppDBContext, IHttpContextAccessor httpContextAccessor
                                 )
        {
            UserManager = userManager;
            SignInManager = signInManager;
            Context = wisdomAppDBContext;
            session = httpContextAccessor.HttpContext.Session;

        }
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(ReadData().ToDataSourceResult(request));
        }
        public IEnumerable<Models.Reservation.Faculty> ReadData()
        {
            return GetAll();
        }

        public IList<Models.Reservation.Faculty> GetAll()
        {
            using (Context)
            {
                var result = Session.GetObjectFromJson<IList<Models.Reservation.Faculty>>("Faculties");

                if (result == null || UpdateDatabase)
                {
                    result = Context.Faculties.ToList().Select(f =>                    
                    {                       
                        return new Models.Reservation.Faculty
                        {
                            Id = f.Id,
                           FacultyName=f.FacultyName,
                           Code=f.Code
                        };
                    }).ToList();
                    Session.SetObjectAsJson("Faculties", result);
                }
                return result;
            }
        }
        [AcceptVerbs("Post")]
        public ActionResult Create([DataSourceRequest] DataSourceRequest request, Models.Reservation.Faculty facultyObj)
        {
            if (facultyObj != null && ModelState.IsValid)
            {
                facultyObj.Status="A";
                Insert(facultyObj);
            }

            return Json(new[] { facultyObj }.ToDataSourceResult(request, ModelState));
        }
        public void Insert(Models.Reservation.Faculty facultyObj)
        {           
                using (Context)
                {
                    var entity = new Models.Reservation.Faculty();

                    entity.Code = facultyObj.Code;
                    entity.FacultyName = facultyObj.FacultyName;
                    Context.Faculties.Add(entity);
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
    }
}
