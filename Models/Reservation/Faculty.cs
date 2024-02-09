using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using LectureRoomMgt.Models.Lecturers;

namespace LectureRoomMgt.Models.Reservation
{
    public class Faculty
    {
        public int Id { get; set; }
        [StringLength(100)] public string Code { get; set; }
        [StringLength(100)] public string FacultyName { get; set; }
        [StringLength(100)] public string Head { get; set; }
        [StringLength(100)] public string Status { get; set; } //A,NA
        [StringLength(200)] public string Comment { get; set; }
        public ICollection<FacultyContact> FacultyContacts { get; set; }
        public ICollection<Block> Blocks { get; set; }
        public ICollection<LecturerFaculty> lecturerFaculties { get; set; }
    }
}
