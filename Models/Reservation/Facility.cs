using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LectureRoomMgt.Models.Reservation
{
    public class Facility
    {
        
        public int Id { get; set; }
        [NotMapped][ StringLength(100)] public string Category { get; set; }
        [StringLength(100)] public string SubCategory { get; set; }
        [StringLength(100)] public string SubCat2 { get; set; }
        [StringLength(100)] public string FacilityDescription { get; set; }
        [StringLength(200)] public string Comment { get; set; }
        [StringLength(10)] public string Status { get; set; }
        public int? FacilityCatId { get; set; }
        public FacilityCategory   FacilityCategory { get; set; }
        public ICollection<RoomFacility> RoomFacilities { get; set; }

    }
}
