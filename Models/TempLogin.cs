using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LectureRoomMgt.Models.Lecturers;

namespace LectureRoomMgt.Models
{
    public class TempLogin
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 1)]
        public int Id { get; set; }

        [Key]
        [Required]
        [Display(Name = "Access Code")]
        public string AccessCode { get; set; }

        [NotMapped]
        public string EncryptAccessCode { get; set; }

        [EmailAddress(ErrorMessage = "Invalid email address")]
        [StringLength(100)]
        [Required]
        public string Email { get; set; }

        [Display(Name = "NIC")]
        [StringLength(12, MinimumLength = 10, ErrorMessage = "This field must be 10 charaters or 12 charaters")]
        [RegularExpression("^[0-9vVxX]*$", ErrorMessage = "This field must contain only numbers plus the letters 'v' or 'x'")]
        public string NIC { get; set; }

        [Required]
        [StringLength(5)]
        [Display(Name = "User Type")]
        public string UserType { get; set; }

        [Display(Name = "Telephone")]
        [MaxLength(10, ErrorMessage = "This field must have only 10 numbers")]
        [MinLength(10, ErrorMessage = "This field must have 10 numbers")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "This field must contain only numbers")]
        public string Tel { get; set; }

        [Display(Name = "Registered State")]
        public string RegisteredState { get; set; }

        [StringLength(256)]
        public string User { get; set; }

        [Display(Name = "Account Created")]
        public bool IsExternal { get; set; }

        [NotMapped]
        public bool IsSelectedRegistered { get; set; }

        [NotMapped]
        public bool IsSelectedPending { get; set; }

        [NotMapped]
        public bool IsSelectedApproved { get; set; }

        [Display(Name = "Requested Date")]
        public DateTime? RequestedDate { get; set; }

        [Display(Name = "Registered Date")]
        public DateTime? RegisteredDate { get; set; }

        [Display(Name = "Deactivated Date")]
        public DateTime? DeactivatedDate { get; set; }

        [Display(Name = "Approved Date")]
        public DateTime? ApproveddDate { get; set; }

        [StringLength(256)]
        public string Name { get; set; }

        [StringLength(256)]
        [Display(Name = "Registration Number")]
        public string AdmissionNo { get; set; }


        public string ResetToken { get; set; }


        [NotMapped]
        [StringLength(256)]
        [Display(Name = "Name")]
        public string MName { get; set; }

        [NotMapped]
        [Display(Name = "Telephone")]
        [MaxLength(10, ErrorMessage = "This field must have only 10 numbers")]
        [MinLength(10, ErrorMessage = "This field must have 10 numbers")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "This field must contain only numbers")]
        public string MTel { get; set; }

        [NotMapped]
        [Display(Name = "NIC"), MaxLength(12)]
        public string MNIC { get; set; }

        [NotMapped]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        [StringLength(100)]
        [Display(Name = "Email")]
        public string MEmail { get; set; }

        [NotMapped]
        [Required]
        [StringLength(5)]
        [Display(Name = "User Type")]
        public string MUserType { get; set; }

        [NotMapped]
        [StringLength(256)]
        [Display(Name = "Registration Number")]
        public string MAdmissionNo { get; set; }

        public Lecturer Lecturer { get; set; }

        [NotMapped]
        public string StringDate { get; set; }
    }
}
