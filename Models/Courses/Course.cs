using LectureRoomMgt.Models.Lecturers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LectureRoomMgt.Models.Courses
{
    public class Course
    {
        public int Id { get; set; }  
        [StringLength(100)] public string Code { get; set; }
        [StringLength(100)] public string CourseName { get; set; }
        public string Comment { get; set; }
        [StringLength(100)] public string Status { get; set; }
        public ICollection<LecturerCourse> LecturerCourses { get; set; }

    }
}
