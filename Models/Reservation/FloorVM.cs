using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LectureRoomMgt.Models.Reservation
{
    public class FloorVM
    {        
        [StringLength(100)] public string FloorName { get; set; }
        public string BlockName { get; set; }
        public int? FloorId { get; set; }

        [Display(Name = "Block")]
        [Required]
        public int? BlockId { get; set; }
        public string FacultyName { get; set; }

        [Display(Name = "Faculty")]
        [Required]
        public int? FacultyId { get; set; }


        public string Status { get; set; } //A,NA
        [StringLength(200)] public string Comment { get; set; }

        public int Id { get; set; }
        public string CallType { get; set; }

    }
}
