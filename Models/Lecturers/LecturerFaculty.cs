using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LectureRoomMgt.Models.Reservation;
namespace LectureRoomMgt.Models.Lecturers
{
    public class LecturerFaculty
    {
        [Key] public int Id { get; set; }
        [MaxLength(10)] public string LecturerId { get; set; }
        public Lecturer Lecturer { get; set; }
        public int FacultyId { get; set; }
        public Faculty Faculty { get; set; }
        [NotMapped] public int[] FacultyIdList { get; set; } // a lecturer can belong to many faculties
        public DateTime RegisteredOn { get; set; }
        public DateTime DiscontinuedOn { get; set; }
    }
}