using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LectureRoomMgt.Models.Reservation
{
    public class Floor
    {
        public int Id { get; set; }
        //[StringLength(15)] public string Code { get; set; }
        [StringLength(100)] public string FloorName { get; set; }
        public int? BlockId { get; set; }       
        public Block Block { get; set; }
        [StringLength(100)] public string Status { get; set; } //A,NA
        [StringLength(200)] public string Comment { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }

    }
}
