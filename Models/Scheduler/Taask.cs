using LectureRoomMgt.Models.Lecturers;
using LectureRoomMgt.Models.Reservation;
using System;
using System.Collections.Generic;

namespace LectureRoomMgt.Models
{
    public partial class Taask
    {
        public int? RoomId { get; set; }
        public Room Room { get; set; }
        public string LecturerId { get; set; }
        public Lecturer Lecturer { get; set; }
        public int TaaskID { get; set; }
        public string Description { get; set; }
        public DateTime End { get; set; }
        public string EndTimezone { get; set; }
        public bool IsAllDay { get; set; }
        public int? OwnerID { get; set; }
        public string RecurrenceException { get; set; }
        public int? RecurrenceID { get; set; }
        public string RecurrenceRule { get; set; }
        public DateTime Start { get; set; }
        public string StartTimezone { get; set; }
        public string Title { get; set; }

        public virtual Taask Recurrence { get; set; }
        public virtual ICollection<Taask> InverseRecurrence { get; set; }
    }
}
