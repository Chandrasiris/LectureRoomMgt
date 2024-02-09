using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LectureRoomMgt.Models.Reservation
{
    public class RoomFacilityVM
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public int? FacilityCategoryId { get; set; }
        [NotMapped] public string FacilityCategoryDescription { get; set; }
        public int Qty { get; set; }
        public string Status { get; set; }
        public string Comment { get; set; }
        [UIHint("FacilityCategoryDDL")]
        public FacilityCategoryDDL FacilityCategoryDDL { get; set; }     
    }
}
