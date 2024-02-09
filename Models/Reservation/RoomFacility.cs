using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LectureRoomMgt.Models.Reservation
{
    public class RoomFacility
    {
        public int Id { get; set; }
       public int RoomId { get; set; }
        public int FacilityCategoryId { get; set; } 
        public int Qty { get; set; }
        public string Status { get; set; }
        public string Comment { get; set; }
        public Room Room { get; set; }
        [UIHint("FacilityCategory")]
        public FacilityCategory FacilityCategory { get; set; }       
    }
}
