using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace LectureRoomMgt.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Company { get; set; }
        public string UserType { get; set; }
        [MaxLength(12)] public string eWisdomId { get; set; }
    }
}
