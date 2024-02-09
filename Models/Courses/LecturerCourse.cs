using LectureRoomMgt.Models.Lecturers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LectureRoomMgt.Models.Courses
{
    public class LecturerCourse
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        [NotMapped]public List<int> CourseIds { get; set; }
        public Course Course { get; set; }
        public string LecturerId { get; set; }
        public Lecturer Lecturer { get; set; }
        public DateTime RegisteredOn { get; set; }
        public DateTime DiscontinuedOn { get; set; }


    }
}
