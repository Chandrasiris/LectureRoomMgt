using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LectureRoomMgt.Models.Claims
{
    public class ClaimAction
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Key]
        public string ClaimId { get; set; }

        [Required]
        public string ClaimType { get; set; }

        [Required]
        public string ClaimValue { get; set; }

        [ForeignKey("ClaimGroup")]
        public string GroupId { get; set; }


        public ClaimGroup ClaimGroup { get; set; }

    }
}
