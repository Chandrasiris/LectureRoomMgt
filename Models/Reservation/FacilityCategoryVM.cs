using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LectureRoomMgt.Models.Reservation
{
    public class FacilityCategoryVM
    {
        public int Id { get; set; }
        public string Category { get; set; }
        [StringLength(100)] public string Comment { get; set; }
    }
}
