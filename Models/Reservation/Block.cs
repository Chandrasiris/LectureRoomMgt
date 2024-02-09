using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LectureRoomMgt.Models.Reservation
{
    public class Block
    {
        public int Id { get; set; }
        [NotMapped] public int? BlockId => Id;
        [StringLength(100)] public string BlockName { get; set; }
        [StringLength(100)] public string Status { get; set; }
        [StringLength(200)] public string Comment { get; set; }
        public int? FacultyId { get; set; }      
        public Faculty Faculty { get; set; }       
        public ICollection<Floor> Floors { get; set; }
    }
}
