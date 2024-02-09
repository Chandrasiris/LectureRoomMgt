using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LectureRoomMgt.Models.ViewModels
{
    public class RolesViewModel
    {
        [StringLength(450)]
        public string RoleId { get; set; }

        public string EncryptRoleId { get; set; }

        [StringLength(50)]
        [Required]
        [Display(Name = "Role name")]
        public string Rolename { get; set; }

        [StringLength(50)]
        [Required]
        [Display(Name = "Role name")]
        [NotMapped]
        public string MRolename { get; set; }
    }
}
