using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LectureRoomMgt.Models.Staff
{
    public class AttendanceMaster
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ProcessId { get; set; }

        public string FileName { get; set; }

        [DataType(DataType.Date), Column(TypeName = "date")]
        public DateTime ProcessedDate { get; set; }

        public string ProcessedBy { get; set; }

        [NotMapped]
        public IFormFile AttendanceFile { get; set; }

        [Required]
        [NotMapped]
        [Display(Name = "Processing Date"), DataType(DataType.Date), Column(TypeName = "date")]
        public DateTime ProcessingDate { get; set; }

        public ICollection<AttendanceDetail> AttendanceDetails { get; set; }
    }
}
