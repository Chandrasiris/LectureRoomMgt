using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LectureRoomMgt.Models
{
    public class MasterUser
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 1)]
        public int Id { get; set; }

        [Key]
        [StringLength(50)]
        [Required]
        [Display(Name = "NIC No")]
        [Column(Order = 2)]
        public string NIC { get; set; }

        [StringLength(50)]
        [Required]
        [Display(Name = "Employee No")]
        public string EmployeeNo { get; set; }

        public bool UserRegistered { get; set; }

    }
}
