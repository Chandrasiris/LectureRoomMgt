using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LectureRoomMgt.Models.Events
{
    public class UniversityEvent
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        [ForeignKey("MasterEvent")]
        [Display(Name = "Event")]
        [Required]
        [StringLength(10)]
        [RegularExpression(@"^[A-Za-z0-9]*$", ErrorMessage = "Only letters and number with no spaces")]
        public string EventId { get; set; }

        [NotMapped]
        public string EncryptId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        [NotMapped]
        [Display(Name = "Date Range")]
        public string DateRange { get; set; }


        [Display(Name = "Holiday")]
        public bool IsHoliday { get; set; }

        public string Comment { get; set; }




        [NotMapped]
        [StringLength(100)]
        [Display(Name = "Name")]
        public string EventName { get; set; }

        [NotMapped]
        [Required]
        [StringLength(100)]
        [Display(Name = "Name")]
        public string MEventName { get; set; }

        [NotMapped]
        [Display(Name = "Holiday")]
        public bool MIsHoliday { get; set; }

        [NotMapped]
        [Display(Name = "Date Range")]
        public string MDateRange { get; set; }

        [NotMapped]
        [Display(Name = "Comment")]
        public string MComment { get; set; }

        [NotMapped]
        public string StringStartDate { get; set; }

        [NotMapped]
        public string StringEndDate { get; set; }



        public MasterEvent MasterEvent { get; set; }

    }
}
