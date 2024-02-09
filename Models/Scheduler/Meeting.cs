using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LectureRoomMgt.Models.Scheduler
{
    public class Meeting: ISchedulerEvent
    {
        public Meeting()
        {
            MeetingAttendees = new HashSet<MeetingAttendee>();
        }

        public int MeetingID { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Description { get; set; }
        public bool IsAllDay { get; set; }
        public int? RecurrenceID { get; set; }
        public string RecurrenceRule { get; set; }
        public string RecurrenceException { get; set; }
        public string StartTimezone { get; set; }
        public string EndTimezone { get; set; }
        public int? Attendee { get; set; }
        public int? RoomID { get; set; }

        public virtual ICollection<MeetingAttendee> MeetingAttendees { get; set; }
        public virtual Meeting Recurrence { get; set; }
        public virtual ICollection<Meeting> InverseRecurrence { get; set; }
    }
}
