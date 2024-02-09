using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LectureRoomMgt.Models.Lecturers;

namespace LectureRoomMgt.Models.Reservation
{
    public class FacultyVM
    {
        public int Id { get; set; }
        [StringLength(100)] public string Code { get; set; }
        [StringLength(100)] public string FacultyName { get; set; }    
         [NotMapped] public string FacName => $"Code-{Code}-{FacultyName}";   
    }
}
