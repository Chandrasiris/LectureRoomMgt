using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LectureRoomMgt.Models.Reservation
{
    public class FacultyContact
    {
        public int Id { get; set; }
        [ForeignKey("CommunicationType")]
        [StringLength(100)] public string Type { get; set; }//tel,email        [StringLength(100)] public string ContactPerson { get; set; }
        [StringLength(100)] public string ContactDes { get; set; }
        [StringLength(100)] public string Status { get; set; } //A,NA
        [StringLength(200)] public string Comment { get; set; }
        public int? FacultyId { get; set; }
        public Faculty Faculty { get; set; }

        public CommunicationType CommunicationType { get; set; }
    }
}
