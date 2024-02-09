namespace LectureRoomMgt.Models.Scheduler
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Kendo.Mvc.UI;

    public class TaskViewModel : ISchedulerEvent
    {       
        public int TaskID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        private DateTime start;
        public DateTime Start
        {
            get
            {
                return start;
            }
            set
            {
                start = value.ToUniversalTime();
            }
        }
        public string StartTimezone { get; set; }

        private DateTime end;
        public DateTime End
        {
            get
            {
                return end;
            }
            set
            {
                end = value.ToUniversalTime();
            }
        }
        public string EndTimezone { get; set; }

        public string RecurrenceRule { get; set; }
        public int? RecurrenceID { get; set; }
        public string RecurrenceException { get; set; }
        public bool IsAllDay { get; set; }
        public int? OwnerID { get; set; }

        public int? RoomId { get; set; }
        public string LecturerId { get; set; }
        //public int? FacultyId { get; set; }
        //public int? BlockId { get; set; }
        //public int? FloorId { get; set; }
        public Taask ToEntity()
        {
            return new Taask
            {
                TaaskID = TaskID,
                Title = Title,
                Start = Start,
                StartTimezone = StartTimezone,
                End = End,
                EndTimezone = EndTimezone,
                Description = Description,
                RecurrenceRule = RecurrenceRule,
                RecurrenceException = RecurrenceException,
                RecurrenceID = RecurrenceID,
                IsAllDay = IsAllDay,
                OwnerID = OwnerID,
                RoomId=RoomId,LecturerId=LecturerId
               //,FacultyId=FacultyId,BlockId=BlockId,FloorId=FloorId
            };
        }
    }
}