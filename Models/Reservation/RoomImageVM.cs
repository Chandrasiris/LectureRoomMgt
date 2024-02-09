using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LectureRoomMgt.Models.Reservation
{
    public class RoomImageVM
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public int Ext { get; set; }
        public string RoomName { get; set; }
        public RoomImage RoomImage { get; set; }
        public List<RoomImage> RoomImageList { get; set; }
    }
}
