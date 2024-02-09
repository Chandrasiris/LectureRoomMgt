using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using LectureRoomMgt.Models.Courses;
using LectureRoomMgt.Models.Lecturers;

namespace LectureRoomMgt.Models.Reservation
{
    public class RoomReservation
    {
        private DateTime end;
        private DateTime start;
        public int? Id { get; set; }
        //---------------------------------------------interface
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsAllDay { get; set; }
        public DateTime Start { get { return start; } set { start = value.ToUniversalTime(); } }
        public DateTime End { get { return end; } set { end = value.ToUniversalTime(); } }
        public string StartTimezone { get; set; }
        public string EndTimezone { get; set; }
        public string RecurrenceRule { get; set; }
        public string RecurrenceException { get; set; }
        public int? RecurrenceID { get; set; }
        //--------------------------------------------------------
        public int? CourseId { get; set; }
        public Course Course { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }
        public string LecturerId { get; set; }
        public Lecturer Lecturer { get; set; }
        public string Status { get; set; } //A - active,C-completed, X-cancelled, NA - Not active
        [NotMapped] public string ResStatus => $"{Status}";
        //public string GradeSyl => $"{Grade}-{SyllabiId}";
        public string Comment { get; set; }
        [NotMapped] public int Faculty { get; set; }
        [NotMapped] public int Block { get; set; }
        [NotMapped] public int Floor { get; set; }
    }
}
