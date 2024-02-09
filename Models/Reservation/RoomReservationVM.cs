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
    public class RoomReservationVM : ISchedulerEvent
    {
        private DateTime end;
        private DateTime start;
        public int? ReservationId { get; set; }
        public int? RecurrenceID { get; set; }
        public string Image { get; set; }

        //---------------------
        //Interface
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsAllDay { get; set; }
        public DateTime Start { get { return start; } set { start = value.ToUniversalTime(); } }
        public DateTime End { get { return end; } set { end = value.ToUniversalTime(); } }
        public string StartTimezone { get; set; }
        public string EndTimezone { get; set; }
        public string RecurrenceRule { get; set; }
        public string RecurrenceException { get; set; }
        //------------------------------------------
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
        public string Comment { get; set; }
        public int CourseId { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }
        public string RoomName { get; set; }
        public string LecturerId { get; set; }
        public int FacultyId { get; set; }
        public int BlockId { get; set; }
        public int FloorId { get; set; }

    }
}
