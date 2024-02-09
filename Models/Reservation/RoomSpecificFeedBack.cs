using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LectureRoomMgt.Models.Reservation
{
    public class RoomSpecificFeedBack
    {
        public int RoomId { get; set; }
        public string UserId { get; set; }
        public int ResponseType { get; set; } //1-happy, 2-Unhappy, 3-Neutral
        public int stars { get; set; }
        public string Description { get; set; }
        public DateTime SubmitedOn { get; set; }
        public string Status { get; set; }
    }
}
