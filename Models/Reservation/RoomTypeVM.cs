﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LectureRoomMgt.Models.Reservation
{
    public class RoomTypeVM
    {
        public int Id { get; set; }
        [StringLength(100)] public string Type { get; set; }//Leture hall, Conf hall, Lab      
        public string Comment { get; set; }
        [StringLength(100)] public string Status { get; set; }
        public ICollection<Room> Rooms { get; set; }
    }
}
