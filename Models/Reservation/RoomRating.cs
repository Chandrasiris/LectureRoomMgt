using LectureRoomMgt.Models.Lecturers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LectureRoomMgt.Models.Reservation
{
    public class RoomRating
    {
        public int Id { get; set; }
        public Room Room { get; set; }
        public int LecturerId { get; set; }
        public Lecturer Lecturers { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime RatedOn{ get; set; }

    }
}
