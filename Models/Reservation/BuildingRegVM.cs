using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LectureRoomMgt.Models.Reservation
{
    public class BuildingRegVM
    {
        [Required]
        [StringLength(15)] public string Code { get; set; }

        [Display(Name = "Faculty Name")]
        [Required]
        [StringLength(100)] public string FacultyName { get; set; }

        [Display(Name = "Head of Faculty")]
        [Required]
        [StringLength(100)] public string Head { get; set; }
        public List<FacultyContact> FacultyContacts { get; set; }

        [Display(Name = "Block Letter")]
        [Required]
        public string BlockLetter { get; set; }

        [Display(Name = "Start Number")]
        [Required]
        public string StartNumber { get; set; }

        [Display(Name = "No Of Blocks")]
        public int NoOfBlocks { get; set; }
        [StringLength(15)] public string Type { get; set; }

        [Display(Name = "Contact Person")]
        [StringLength(100)] public string ContactPerson { get; set; }

        [Display(Name = "Contact Description")]
        [StringLength(100)] public string ContactDes { get; set; }

        public List<Block> Blocks { get; set; }
    }
}
