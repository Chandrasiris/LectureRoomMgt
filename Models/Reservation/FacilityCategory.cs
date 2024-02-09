using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LectureRoomMgt.Models.Reservation
{
    public class FacilityCategory
    {
        public int Id { get; set; }       
        [StringLength(100)] public string Category { get; set; }
        [StringLength(100)] public string Comment { get; set; }
        public ICollection<FacilityCommon> Facilities { get; set; }
        public ICollection<RoomFacility> RoomFacilities { get; set; }


    }
}
