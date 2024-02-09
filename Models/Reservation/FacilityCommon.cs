using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LectureRoomMgt.Models.Reservation
{
    public class FacilityCommon //CommonFacilities
    {
        
        public int Id { get; set; }
        public int? FacilityCategoryId { get; set; }
        [NotMapped][ StringLength(100)] public string Category { get; set; }
        [StringLength(100)] public string FacilityDescription { get; set; }        
        [StringLength(100)] public string Status { get; set; }
        public int Qty { get; set; }
        public int InUse { get; set; }
        [StringLength(200)] public string Comment { get; set; }
        [UIHint("FacilityCategory")]
        public FacilityCategory FacilityCategory { get; set; }
        

    }
}
