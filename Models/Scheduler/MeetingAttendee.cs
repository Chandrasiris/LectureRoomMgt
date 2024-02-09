using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LectureRoomMgt.Models.Scheduler
{
    public class MeetingAttendee
    {
        public int MeetingID { get; set; }
        public int AttendeeID { get; set; }

        public virtual Meeting Meeting { get; set; }
    }
}
