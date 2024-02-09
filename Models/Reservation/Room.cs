using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LectureRoomMgt.Models.Reservation
{
    public class Room
    {
        public int Id { get; set; }
        [StringLength(100)] public string RoomName{ get; set; }//Room Name is  RoomCode
        public int? RoomTypeId { get; set; }//Leture Room, Conference Room,
        [StringLength(100)] public string Grade { get; set; } //
        public int  Capacity { get; set; } //seats
        [StringLength(100)] public string Status { get; set; } //A, N, R 
        [StringLength(200)] public string Comment { get; set; }       
        public RoomType RoomType { get; set; }
        public int? FloorId { get; set; }
        public virtual Floor    Floor { get; set; }
        public ICollection<RoomFacility> RoomFacilities { get; set; }
        public ICollection<RoomImage> RoomImages { get; set; }
        public ICollection<RoomImageDefault> RoomImageDefaults { get; set; }
        //   public ICollection<RoomRating> RoomRatings { get; set; }
        public ICollection<RoomReservation> RoomReservations { get; set; }
        public ICollection <FeedBackRoom> FeedBackRooms{ get; set; }
    }
}
