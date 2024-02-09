using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LectureRoomMgt.Models
{
    public class MasterCompany
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 1)]
        public int ID { get; set; }

        [Required]
        [Key]
        [Display(Name = "University Id")]
        [StringLength(10)]
        [RegularExpression(@"^[A-Za-z0-9]*$", ErrorMessage = "Only letters and number with no spaces")]
        public string CompID { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Name")]
        public string CompanyName { get; set; }

        [Required]
        [StringLength(10)]
        [Display(Name = "Short Name")]
        public string ShortName { get; set; }

        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [StringLength(100)]
        [Display(Name = "University Email")]
        [Required]
        public string CompanyEmail { get; set; }

        [Display(Name = "Twitter")]
        public string Twitter { get; set; }

        [Display(Name = "Facebook")]
        public string Facebook { get; set; }

        [Display(Name = "LinkedIn")]
        public string LinkedIn { get; set; }

        [Display(Name = "Instagram")]
        public string Instagram { get; set; }

        [Display(Name = "Youtube")]
        public string Youtube { get; set; }



        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [StringLength(100)]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Email Password")]
        public string EmailPassword { get; set; }


        [NotMapped]
        public string MEmailPassword { get; set; }

        [Required]
        [Display(Name = "Adress")]
        public string Address { get; set; }

        [Required]
        [MaxLength(10)]
        [MinLength(10)]
        [Display(Name = "Telephone")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "This field must contain only numbers")]
        public string Telephone { get; set; }

        [Display(Name = "Work")]
        [MaxLength(10)]
        [MinLength(10)]
        [RegularExpression("^[0-9]*$", ErrorMessage = "This field must contain only numbers")]
        public string WorkTelephone { get; set; }

        public string Comment { get; set; }

        public string ProfileImgPath { get; set; }

        [NotMapped]
        public IFormFile UniversityImageFile { get; set; }


        [NotMapped]
        public bool IsImageChange { get; set; }

        [NotMapped]
        public bool IsImageDeleted { get; set; }

        [NotMapped]
        public string TempEmailPassword { get; set; }


    }
}
