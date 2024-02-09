using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LectureRoomMgt.Models.Staff
{
    public class Employee
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 1)]
        public int Id { get; set; }

        [Key]
        [Display(Name = "Staff Id")]
        [StringLength(10)]
        [RegularExpression(@"^[A-Za-z0-9]*$", ErrorMessage = "Only letters and number with no spaces")]
        public string EmpId { get; set; }

        [NotMapped]
        public string EncryptEmpId { get; set; }

        [Required]
        [StringLength(15)]
        [ForeignKey("MasterTitle")]
        public string Title { get; set; }

        [Required]
        [RegularExpression(@"^[a-z A-Z]+$", ErrorMessage = "Use only alphabet letters")]
        [Display(Name = "Full Name")]
        public string FName { get; set; }

        [Required]
        [RegularExpression(@"^[a-z A-Z.]+$", ErrorMessage = "Use only alphabet letters")]
        [Display(Name = "Name with Initials")] 
        public string SName { get; set; }

        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [ForeignKey("MasterGender")]
        [Required]
        [StringLength(15)]
        public string Gender { get; set; }

        [ForeignKey("MasterDesignation")]
        [Required]
        [StringLength(50)]
        public string Designation { get; set; }

        [Required]
        [MaxLength(10, ErrorMessage = "This field must have only 10 numbers")]
        [MinLength(10, ErrorMessage = "This field must have 10 numbers")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "This field must contain only numbers")]
        public string Mobile { get; set; }

        [Display(Name = "Telephone")]
        [MaxLength(10, ErrorMessage = "This field must have only 10 numbers")]
        [MinLength(10, ErrorMessage = "This field must have 10 numbers")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "This field must contain only numbers")]
        public string HomeTel { get; set; }

        [Display(Name = "Office")]
        [MaxLength(10, ErrorMessage = "This field must have only 10 numbers")]
        [MinLength(10, ErrorMessage = "This field must have 10 numbers")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "This field must contain only numbers")]
        public string OfficeTel { get; set; }

        [Required]
        [DataType(DataType.Date), Column(TypeName = "date")]
        [Display(Name = "Date of Birth")]
        public DateTime Dob { get; set; }

        [Required]
        [DataType(DataType.Date), Column(TypeName = "date")]
        [Display(Name = "Joined Date")]
        public DateTime JoinedDate { get; set; }


        [StringLength(256)]
        public string Username { get; set; }

        [ForeignKey("TempLogin")]
        public string AccessCode { get; set; }

        public DateTime SysDate { get; set; }

        public string ProfileImgPath { get; set; }

        public string Comment { get; set; }


        [NotMapped]
        public IFormFile EmployeeImageFile { get; set; }

        [NotMapped]
        public bool IsImageChange { get; set; }

        [NotMapped]
        public bool IsImageDeleted { get; set; }




        public TempLogin TempLogin { get; set; }

        public MasterTitle MasterTitle { get; set; }
        public MasterGender MasterGender { get; set; }
        public MasterDesignation MasterDesignation { get; set; }



        #region Modal

        [NotMapped]
        [Display(Name = "Staff Id")]
        [Required]
        public string MEmpId { get; set; }

        [NotMapped]
        [Required]
        [StringLength(10)]
        [Display(Name = "Title")]
        public string MTitle { get; set; }

        [NotMapped]
        [Required]
        [RegularExpression(@"^[a-z A-Z]+$", ErrorMessage = "Use only alphabet letters")]
        [Display(Name = "Full Name")]
        public string MFName { get; set; }

        [NotMapped]
        [Required]
        [RegularExpression(@"^[a-z A-Z.]+$", ErrorMessage = "Use only alphabet letters")]
        [Display(Name = "Name with Initials")]
        public string MSName { get; set; }


        [Display(Name = "Email")]
        [NotMapped]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string MEmail { get; set; }

        [Display(Name = "Gender")]
        [NotMapped]
        [Required]
        [StringLength(10)]
        public string MGender { get; set; }



        [Display(Name = "Designation")]
        [NotMapped]
        [Required]
        [StringLength(100)]
        public string MDesignation { get; set; }



        [Display(Name = "Mobile")]
        [NotMapped]
        [Required]
        [MaxLength(10, ErrorMessage = "This field must have only 10 numbers")]
        [MinLength(10, ErrorMessage = "This field must have 10 numbers")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "This field must contain only numbers")]
        public string MMobile { get; set; }

        [NotMapped]
        [Display(Name = "Telephone")]
        [MaxLength(10, ErrorMessage = "This field must have only 10 numbers")]
        [MinLength(10, ErrorMessage = "This field must have 10 numbers")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "This field must contain only numbers")]
        public string MHomeTel { get; set; }

        [NotMapped]
        [Display(Name = "Office")]
        [MaxLength(10, ErrorMessage = "This field must have only 10 numbers")]
        [MinLength(10, ErrorMessage = "This field must have 10 numbers")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "This field must contain only numbers")]
        public string MOfficeTel { get; set; }

        [NotMapped]
        [DataType(DataType.Date), Column(TypeName = "date")]
        [Display(Name = "Date of Birth")]
        public DateTime? MDob { get; set; }

        [NotMapped]
        [Required]
        [DataType(DataType.Date), Column(TypeName = "date")]
        [Display(Name = "Joined Date")]
        public DateTime MJoinedDate { get; set; }


        [NotMapped]
        [StringLength(256)]
        public string MUsername { get; set; }

        [NotMapped]
        public string MProfileImgPath { get; set; }

        [Display(Name = "Comment")]
        [NotMapped]
        public string MComment { get; set; }


        [NotMapped]
        public IFormFile MEmployeeImageFile { get; set; }

        [NotMapped]
        public bool MIsImageChange { get; set; }

        [NotMapped]
        public bool MIsImageDeleted { get; set; }


        #endregion


    }
}
