using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LectureRoomMgt.Models
{
    public class Sequence
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string varcharSeqName { get; set; }

        [Column(TypeName = "decimal(18,0)")]
        public Nullable<decimal> numMinVal { get; set; }

        [Column(TypeName = "decimal(18,0)")]
        public Nullable<decimal> numMaxVal { get; set; }

        [Column(TypeName = "decimal(18,0)")]
        public Nullable<decimal> numIncBy { get; set; }

        [Column(TypeName = "decimal(18,0)")]
        public Nullable<decimal> numCurVal { get; set; }

        [StringLength(5)]
        public string varcharPreFix { get; set; }

        [StringLength(1)]
        public string varcharPrefixStatus { get; set; }

        [Column(TypeName = "decimal(18,0)")]
        public Nullable<decimal> NumOfCharacters { get; set; }
    }
}
