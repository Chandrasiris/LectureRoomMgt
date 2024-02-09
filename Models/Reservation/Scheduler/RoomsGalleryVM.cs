using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LectureRoomMgt.Models.Reservation.Scheduler
{
    public class RoomsGalleryVM
    {
        public string RoomName { get; set; }
        public int RoomId { get; set; }
        public string RoomType { get; set; }
        public string Grade { get; set; }
        public int Capacity { get; set; }
        public string Status { get; set; }
        public string Comment { get; set; }
        public string DefaultImage { get; set; }
        public List<string> Images { get; set; }
    }
}
