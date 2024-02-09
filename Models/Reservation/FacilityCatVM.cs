﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LectureRoomMgt.Models.Reservation
{
    public class FacilityCatVM
    {
        public int Id { get; set; }
        [StringLength(100)] public string Category { get; set; }
    }
}
