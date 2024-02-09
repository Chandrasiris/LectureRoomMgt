using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LectureRoomMgt.Models.Claims
{
    public class ClaimGroup
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Key]
        [Required]
        public string GroupId { get; set; }


        [StringLength(50)]
        [Required]
        public string Name { get; set; }

        public ICollection<ClaimAction> ClaimActions { get; set; }

    }
}
