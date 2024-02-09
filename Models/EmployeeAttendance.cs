using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LectureRoomMgt.Models
{
    public class EmployeeAttendance
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        public string Username { get; set; }

        [Display(Name = "Finger Print")]
        public DateTime PressedDateTime { get; set; }

        public bool ShiftIn { get; set; }

        public bool ShiftOut { get; set; }


        [NotMapped]
        [Display(Name = "Date")]
        public string DateMarked { get; set; }

        [NotMapped]
        [Display(Name = "Day")]
        public string DayName { get; set; }

        [NotMapped]
        [Display(Name = "Time in")]
        public string TimeIn { get; set; }

        [NotMapped]
        [Display(Name = "Time out")]
        public string TimeOut { get; set; }

        [NotMapped]
        [Display(Name = "Hours")]
        public Double HoursWorked { get; set; }

        [NotMapped]
        public string Remark { get; set; }


    }
}
