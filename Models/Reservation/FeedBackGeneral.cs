using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LectureRoomMgt.Models.Reservation
{
    public class FeedBackGeneral
    { 
        public int Id { get; set; }
        [StringLength(10)]
        public string UserId { get; set; }       
        public int ResponseType { get; set; } //1-happy, 2-Unhappy, 3-Neutral
        public int stars { get; set; }
        public string Description { get; set; }
        public DateTime SubmitedOn { get; set; }
        public string Status { get; set; }
    }
}
