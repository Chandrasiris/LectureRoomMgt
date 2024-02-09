using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LectureRoomMgt.Models
{
    public class CommunicationType
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Communication Type")]
        [StringLength(100)]
        [Required]
        [Key]
        public string ComType { get; set; }


        [NotMapped]
        public string EncryptComType { get; set; }
    }
}
