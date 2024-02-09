using System.Linq;
using System.Threading.Tasks;
using LectureRoomMgt.DAL;
using LectureRoomMgt.Models;
using LectureRoomMgt.Models.Courses;
using LectureRoomMgt.Models.Lecturers;
using LectureRoomMgt.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LectureRoomMgt.Controllers.Lecturers
{
    public class LecturerFacultyController : Controller
    {
        public WisdomAppDBContext Context { get; }
        public IDataProtector protector { get; }
        public UserManager<ApplicationUser> UserManager { get; }
        public LecturerFacultyController(WisdomAppDBContext wisdomAppDBContext,
                                IDataProtectionProvider dataProtectionProvider,
                                UserManager<ApplicationUser> userManager,
                                DataProtectionPurposeStrings dataProtectionPurposeStrings)
        {
            Context = wisdomAppDBContext;
            UserManager = userManager;
            protector = dataProtectionProvider.CreateProtector(dataProtectionPurposeStrings.LecturerId);
        }
        public IActionResult Index()
        {
            var dataF = from e in Context.Faculties//.Where(c => c.Status == "A")
                        select new
                        {
                            Id = e.Id,
                            FacultyName = e.Code + "-" + e.FacultyName
                        };
            ViewBag.Faculties = new SelectList(dataF.ToList(), "Id", "FacultyName");
            ViewBag.Lecturers = new SelectList(Context.Lecturers.Where(c => c.LecturerStatus == "A").Select(c => new { c.LecturerId, c.FName }).ToList(), "LecturerId", "FName");

            return View();
        }
        [HttpPost]
        public IActionResult InsertLecFaculty(LecturerFaculty obj)
        {
           // saveLecFaculty(obj);
            return RedirectToAction("Index");
        }
        [Authorize(Policy = "LecturersOnly")]
        public IActionResult IndexInsertByLec()
        {                    
            var dataF = from e in Context.Faculties
                        select new
                        {
                            Id = e.Id,
                            FacultyName = e.Code + "-" + e.FacultyName
                        };
            ViewBag.Faculties = new SelectList(dataF.ToList(), "Id", "FacultyName");
            var dataCourses = from e in Context.Course
                        select new
                        {
                            Id = e.Id,
                            CourseName = e.Code + "-" + e.CourseName
                        };
            ViewBag.Courses = new SelectList(dataCourses.ToList(), "Id", "CourseName");
            return View();
        }
        [Authorize(Policy = "LecturersOnly")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> InsertByLecturer(LeturerFacultyVM obj)
        {
            ApplicationUser user = await UserManager.FindByNameAsync(User.Identity.Name);
            if (obj.CallType== "faculty")
            {
                saveLecFaculty(user.eWisdomId, obj.FacultyId);
            }
            else if (obj.CallType=="course")
            {
                saveLecCourse(user.eWisdomId, obj.CourseId);
            }
            return RedirectToAction("IndexInsertByLec");
        }
        private void saveLecFaculty(string LecturerId, int facultyId){          
            var RegisteredFac = Context.LecturerFaculties.Where(c => c.LecturerId == LecturerId).Select(c => c.FacultyId).ToList();               
                if (!(RegisteredFac.Contains(facultyId)))
                {
                    var lecFac = new LecturerFaculty()
                    {
                        FacultyId = facultyId,
                        LecturerId = LecturerId,
                        RegisteredOn = System.DateTime.Now.Date
                    };
                    Context.LecturerFaculties.Add(lecFac);
                }                
            Context.SaveChanges();            
        }
        private void saveLecCourse(string LecturerId, int courseId)
        {
            var RegisteredCourses = Context.LecturerCourses.Where(c => c.LecturerId == LecturerId).Select(c => c.CourseId).ToList();
            if (!(RegisteredCourses.Contains(courseId)))
            {
                var lecCourse = new LecturerCourse()
                {
                    CourseId = courseId,
                    LecturerId = LecturerId,
                    RegisteredOn = System.DateTime.Now.Date

                };
                Context.LecturerCourses.Add(lecCourse);
            }
            Context.SaveChanges();
        }
    }
}

