using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LectureRoomMgt.Models.Events
{
    public class MasterEvent
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        [Key]
        [StringLength(10)]
        [RegularExpression(@"^[A-Za-z0-9]*$", ErrorMessage = "Only letters and number with no spaces")]
        [Display(Name = "Event Id")]
        [Required]
        public string EventId { get; set; }

        [NotMapped]
        public string EncryptEventId { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Name")]
        public string EventName { get; set; }


        [NotMapped]
        [Required]
        [StringLength(100)]
        [Display(Name = "Name")]
        public string MEventName { get; set; }


        public ICollection<UniversityEvent> UniversityEvents { get; set; }
    }
}
