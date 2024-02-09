using LectureRoomMgt.Models.Staff;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LectureRoomMgt.Models
{
    public class MasterDesignation
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(50)]
        [Required]
        [Key]
        public string Designation { get; set; }


        [NotMapped]
        public string EncryptDesignationId { get; set; }


        public ICollection<Employee> Employees { get; set; }

    }

}
