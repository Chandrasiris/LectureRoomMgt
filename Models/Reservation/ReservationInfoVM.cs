using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Kendo.Mvc.UI;
using LectureRoomMgt.Models.Lecturers;

namespace LectureRoomMgt.Models.Reservation
{
    public class ReservationInfoVM
    {
        private DateTime end;
        private DateTime start;
        public int? ReservationId { get; set; }    
        public string Title { get; set; }
        public bool IsAllDay { get; set; }
        public DateTime Start { get { return start; } set { start = value.ToUniversalTime(); } }
        public DateTime End { get { return end; } set { end = value.ToUniversalTime(); } }
        public DateTime Date { get; set; }
        public string RoomStatus { get; set; }
        public string ResStatus { get; set; }
        public int CourseId { get; set; }

        [Display(Name = "Course")]
        public string CourseName { get; set; }
        public int RoomId { get; set; }

        [Display(Name = "Room")]
        public string RoomName { get; set; }
        public string LecturerId { get; set; }

        [Display(Name = "Lecturer")]
        public string LecName { get; set; }
        public int FacultyId { get; set; }

        [Display(Name = "Faculty")]
        public string FacultyName { get; set; }
        public int BlockId { get; set; }

        [Display(Name = "Block")]
        public string BlockName { get; set; }
        public int FloorId { get; set; }

        [Display(Name = "Floor")]
        public string FloorName { get; set; }
        public bool IsReserved { get; set; }
        public string EncryptCode { get; set; }

        public bool IsSelectedCancelled { get; set; }
        public bool IsSelectedCompleted { get; set; }

        [Display(Name = "Date & Time")]
        public string StartEndDate { get; set; }

}
}
