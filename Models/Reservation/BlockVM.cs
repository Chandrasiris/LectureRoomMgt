using LectureRoomMgt.Models.Scheduler;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LectureRoomMgt.Models.Reservation
{
    public class BlockVM
    {
        public int Id { get; set; }
        [StringLength(100)] public string BlockName { get; set; }
        public string  FacultyName { get; set; }

        [Display(Name = "Faculty")]
        public int? FacultyId { get; set; }

        [Display(Name = "Block")]
        public int? BlockId { get; set; }

        public List<Block> Blocks;

        public string CallType { get; set; }
        [StringLength(100)] public string Status { get; set; }
        [StringLength(200)] public string Comment { get; set; }

        public GridLayoutData GridLayoutData { get; set; }
    }
}
