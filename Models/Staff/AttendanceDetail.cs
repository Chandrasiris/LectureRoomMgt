using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LectureRoomMgt.Models.Staff
{
    public class AttendanceDetail
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [ForeignKey("AttendanceMaster")]
        public int ProcessId { get; set; }


        public string UserId { get; set; }

        [DataType(DataType.Date), Column(TypeName = "date")]
        public DateTime AttendedDate { get; set; }

        [StringLength(8)]
        [Display(Name = "Time In")] 
        public string TimeIn { get; set; }

        [StringLength(8)]
        [Display(Name = "Time Out")]
        public string TimeOut { get; set; }

        public AttendanceMaster AttendanceMaster { get; set; }

    }
}
