using System.ComponentModel.DataAnnotations;

namespace LectureRoomMgt.Models.ViewModels
{
    public class UsersRolesViewModel
    {
        [StringLength(450)]
        public string UserId { get; set; }
        public string EncryptUserId { get; set; }

        [StringLength(50)]
        public string Username { get; set; }

        [StringLength(450)]
        public string RoleId { get; set; }

        [StringLength(50)]
        [Display(Name = "Role name")]
        public string Rolename { get; set; }

        public bool IsSelected { get; set; }


    }
}
