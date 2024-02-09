using LectureRoomMgt.Models.Courses;
using LectureRoomMgt.Models.Reservation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LectureRoomMgt.Models.Lecturers
{
    public class Lecturer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Key, Display(Name = "Lecturer Id")]
        [StringLength(10)]
        [RegularExpression(@"^[A-Za-z0-9]*$", ErrorMessage = "Only letters and number with no spaces")]
        public string LecturerId { get; set; }

        [NotMapped]
        public string EncryptLecturerId { get; set; }

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

        [DataType(DataType.Date), Column(TypeName = "date")]
        [Display(Name = "Date of Birth")]
        public DateTime? Dob { get; set; }

        [Required]
        [DataType(DataType.Date), Column(TypeName = "date")]
        [Display(Name = "Joined Date")]
        public DateTime JoinedDate { get; set; }


        public string ProfileImgPath { get; set; }


        public DateTime SysDate { get; set; }

        [StringLength(1)]
        public string LecturerStatus { get; set; }

        [StringLength(1)]
        public string ProfileStatus { get; set; }



        [StringLength(256)]
        public string Username { get; set; }


        [ForeignKey("TempLogin")]
        public string AccessCode { get; set; }

        [Display(Name = "Qualifications"), MaxLength(500)] public string Qualifications { get; set; }
        public ICollection< Course > Course { get; set; }

        [NotMapped]
        public IFormFile LecturerImageFile { get; set; }

        [NotMapped]
        public bool IsImageChange { get; set; }

        [NotMapped]
        public bool IsImageDeleted { get; set; }

        public TempLogin TempLogin { get; set; }

        public MasterTitle MasterTitle { get; set; }
        public MasterGender MasterGender { get; set; }
        public ICollection<LecturerCourse> LecturerCourses { get; set; }
        public ICollection<LecturerFaculty> lecturerFaculties { get; set; }


    }
}
