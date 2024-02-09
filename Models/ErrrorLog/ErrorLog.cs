using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LectureRoomMgt.Models.ErrrorLog
{
    public class ErrorLog
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int LogId { get; set; }

        [StringLength(256)]
        public string ControllerName { get; set; }

        [StringLength(256)]
        public string ActionName { get; set; }

        public string Error { get; set; }

        public DateTime DateLogin { get; set; }

        [StringLength(256)]
        public string User { get; set; }
    }
}
