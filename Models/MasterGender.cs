using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using LectureRoomMgt.Models.Staff;
using LectureRoomMgt.Models.Lecturers;

namespace LectureRoomMgt.Models
{
    public class MasterGender
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(15)]
        [Required]
        [Key]
        public string Gender { get; set; }

        [NotMapped]
        public string EncryptGenderId { get; set; }

        public ICollection<Employee> Employees { get; set; }
        public ICollection<Lecturer> Lecturers { get; set; }
    }
}
