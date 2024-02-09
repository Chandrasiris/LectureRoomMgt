using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LectureRoomMgt.Models
{
    public class UserLoginLog
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [StringLength(256)]
        public string User { get; set; }

        public DateTime DateLogin { get; set; }

    }
}
