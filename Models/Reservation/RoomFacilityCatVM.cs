using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LectureRoomMgt.Models.Reservation
{
    public class RoomFacilityCatVM
    {       
        public int CatId { get; set; }        
        public string Category { get; set; }
    }
}
