using LectureRoomMgt.Models.Lecturers;
using LectureRoomMgt.Models.Staff;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LectureRoomMgt.Models
{
    public class MasterTitle
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(15)]
        [RegularExpression(@"^[a-z A-Z.]+$", ErrorMessage = "Use only alphabet letters")]
        [Required]
        [Key]
        public string Title { get; set; }

        [NotMapped]
        public string EncryptTitleId { get; set; }

        public ICollection<Employee> Employees { get; set; }
        public ICollection<Lecturer> Lecturers { get; set; }


    }
}
