using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LectureRoomMgt.Models.Scheduler
{
    public class MyReservations
    {
        public string RoomName { get; set; }
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public string Description { get; set; }
        public string Notices { get; set; }
        public DateTime Start { get; set; }
        public string FormattedDate => Start.ToString("MMM dd");
        public string FormattedTimeS => Start.ToString("hh m tt");
        public string FormattedDay => Start.ToString("ddd"); 
        public int FormattedDayNumber => Start.Day;
        public DateTime End { get; set; }
        public string FormattedTimeE => End.ToString("hh m tt");
    }
}
