using Microsoft.AspNetCore.Authentication;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LectureRoomMgt.Models.ViewModels
{
    public class UserViewModel
    {
        [StringLength(450)]
        public string UserId { get; set; }

        public string EncryptUserId { get; set; }

        [StringLength(50)]
        [Required]
        [RegularExpression(@"^[A-Za-z0-9]*$", ErrorMessage = "Only letters and number with no spaces")]
        public string Username { get; set; }

        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }

        [Display(Name = "Confirm password")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Passwords do not match")]
        public string ConfirmPassword { get; set; }

        [EmailAddress(ErrorMessage = "Invalid email address")]
        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(50)]
        [Required]
        [Display(Name = "Access Code")]
        public string AccessCode { get; set; }

        [Required]
        [StringLength(5)]
        [Display(Name = "User Type")]
        public string UserType { get; set; }

        [StringLength(50)]
        [Required]
        [Display(Name = "Username")]
        public string MUsername { get; set; }

        [DataType(DataType.Password)]
        [Required]
        [Display(Name = "Password")]
        public string MPassword { get; set; }

        [Display(Name = "Confirm password")]
        [DataType(DataType.Password)]
        [Compare("MPassword", ErrorMessage = "Passwords do not match")]
        public string MConfirmPassword { get; set; }

        [Required]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        [StringLength(100)]
        public string PEmail { get; set; }

        [StringLength(50)]
        [Required]
        [Display(Name = "Reset Token")]
        public string ResetToken { get; set; }

        [DataType(DataType.Password)]
        [Required]
        [Display(Name = "New Password")]
        public string NewPassword { get; set; }

        [Display(Name = "Confirm password")]
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "Passwords do not match")]
        public string ConfirmNewPassword { get; set; }

        public string ForgotPwType { get; set; }

        [Display(Name = "Name")]
        public string FName { get; set; }

        [Display(Name = "Telephone")]
        public string Tel { get; set; }

        [Required]
        [Display(Name = "Registration No")]
        public string RegNo { get; set; }


        public string ReturnUrl { get; set; }
        public string Provider { get; set; }

    }
}
