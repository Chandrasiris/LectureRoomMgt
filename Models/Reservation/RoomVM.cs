using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LectureRoomMgt.Models.Reservation
{
    public class RoomVM
    {
        public int RoomId { get; set; }
        [StringLength(100)] public string RoomName { get; set; }
        public string RoomGrade { get; set; }
        public string RoomType { get; set; }//Leture Room, Conference Room,        
        public int  Capacity { get; set; } //Number of seats
       public string Status { get; set; } //A, NA
        public string Gallery { get; set; } //A, NA 
        public int CustomerRating { get; set; }
         public string Comment { get; set; }
       public int? RoomTypeId { get; set; }
        public int? FloorId { get; set; }
        public int? BlockId { get; set; }
        public int? FacultyId { get; set; }
        public string FacultyName { get; set; }
        public string BlockName { get; set; }
        public string FloorName { get; set; }
        public List<RoomFacilityCatVM> FacilityCats { get; set; }
        public List<RoomFacilityVM> Facilitys { get; set; }
    }
}
