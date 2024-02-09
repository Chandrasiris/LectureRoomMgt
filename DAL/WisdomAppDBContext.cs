using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using LectureRoomMgt.Models;
using LectureRoomMgt.Models.Events;
using LectureRoomMgt.Models.Staff;
using LectureRoomMgt.Models.Lecturers;
using LectureRoomMgt.Models.Claims;
using LectureRoomMgt.Models.Reservation;
using LectureRoomMgt.Models.Courses;
using LectureRoomMgt.Models.ErrrorLog;

namespace LectureRoomMgt.DAL
{
    public class WisdomAppDBContext : IdentityDbContext<ApplicationUser>
    {
        public WisdomAppDBContext(DbContextOptions<WisdomAppDBContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            #region Restric Delete Constraint

            builder.Entity<TempLogin>().HasOne(w => w.Lecturer).WithOne(t => t.TempLogin).OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Employee>().HasOne(w => w.MasterTitle).WithMany(x => x.Employees).OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Employee>().HasOne(w => w.MasterGender).WithMany(x => x.Employees).OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Employee>().HasOne(w => w.MasterDesignation).WithMany(x => x.Employees).OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Lecturer>().HasOne(w => w.MasterTitle).WithMany(x => x.Lecturers).OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Lecturer>().HasOne(w => w.MasterGender).WithMany(x => x.Lecturers).OnDelete(DeleteBehavior.Restrict);

            #endregion

            #region Unique Constraint
            builder.Entity<Lecturer>().HasIndex(t => t.LecturerId).IsUnique();

            builder.Entity<UniversityEvent>().HasIndex(o => new { o.EventId, o.StartDate, o.EndDate }).IsUnique();

            builder.Entity<AttendanceMaster>().HasIndex(o => new { o.ProcessedDate }).IsUnique();

            builder.Entity<Faculty>().HasIndex(u => new { u.FacultyName, u.Code }).IsUnique();
            builder.Entity<Block>().HasIndex(u => new { u.BlockName, u.FacultyId }).IsUnique();
            builder.Entity<Floor>().HasIndex(p => new { p.FloorName, p.BlockId }).IsUnique(true);
            builder.Entity<Room>().HasIndex(p => new { p.RoomName, p.FloorId }).IsUnique(true);
            builder.Entity<LecturerCourse>().HasKey(bc => new { bc.LecturerId, bc.CourseId });
            builder.Entity<LecturerCourse>().HasOne(bc => bc.Course).WithMany(b => b.LecturerCourses).HasForeignKey(bc => bc.CourseId);
            builder.Entity<LecturerCourse>().HasOne(bc => bc.Lecturer).WithMany(c => c.LecturerCourses).HasForeignKey(bc => bc.LecturerId);
            #endregion

        }

        public virtual DbSet<TempLogin> TempLogins { get; set; }
        public virtual DbSet<RoomImageDefault> RoomImageDefaults { get; set; }
        public virtual DbSet<MasterCompany> MasterCompanies { get; set; }
        public virtual DbSet<FeedBackGeneral> FeedBackGenerals { get; set; }
        public virtual DbSet<FeedBackRoom> FeedBackRooms { get; set; }

        #region Claims
        public DbSet<ClaimGroup> ClaimGroups { get; set; }
        public DbSet<ClaimAction> ClaimActions { get; set; }

        #endregion

        #region Lecturers
        public DbSet<Lecturer> Lecturers { get; set; }

        #endregion

        #region Staff
        public DbSet<Employee> Employees { get; set; }
        public DbSet<AttendanceMaster> AttendanceMasters { get; set; }
        public DbSet<AttendanceDetail> AttendanceDetails { get; set; }

        #endregion

        #region Events
        public virtual DbSet<UniversityEvent> UniversityEvents { get; set; }
        public virtual DbSet<MasterEvent> MasterEvents { get; set; }

        #endregion

        #region Basic Data
        public DbSet<MasterTitle> MasterTitles { get; set; }
        public DbSet<MasterGender> MasterGenders { get; set; }
        public DbSet<MasterDesignation> MasterDesignations { get; set; }
        public DbSet<CommunicationType> CommunicationTypes { get; set; }
        #endregion

        #region Reservation
        public DbSet<LecturerFaculty> LecturerFaculties { get; set; }
        public DbSet<StatusOptions> StatusOptions { get; set; }
        public DbSet<FacultyContact> FacultyContacts { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Block> Blocks { get; set; }
        public DbSet<Floor> Floors { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<RoomRating> RoomRatings { get; set; }
        public DbSet<RoomImage> RoomImages { get; set; }
        public DbSet<FacilityCategory> FacilityCategories { get; set; }
        public DbSet<FacilityCommon> FacilitiesCommon { get; set; }
        public DbSet<RoomFacility> RoomFacilities { get; set; }
        public DbSet<RoomReservation> RoomReservations { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<LecturerCourse> LecturerCourses { get; set; }
        public DbSet<Taask> Tasks { get; set; }
        #endregion

        public DbSet<ErrorLog> ErrorLogs { get; set; }
        public DbSet<Sequence> Sequences { get; set; }
        public DbSet<UserLoginLog> UserLoginLogs { get; set; }
        public object RoomReservation { get; internal set; }

    }
}
