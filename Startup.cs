using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.Net.Http;
using LectureRoomMgt.CustomClaims;
using LectureRoomMgt.DAL;
using LectureRoomMgt.Models;
using LectureRoomMgt.Security;
using LectureRoomMgt.Models.Scheduler;
using Kendo.Mvc.UI;
using EmailService;
using Microsoft.Extensions.FileProviders;

namespace LectureRoomMgt
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            //Log.Logger = new LoggerConfiguration()
                //.ReadFrom.Configuration(configuration)
                //.CreateLogger();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            #region email
            var emailConfig = Configuration
                .GetSection("EmailConfiguration")
                .Get<EmailConfiguration>();
            services.AddSingleton(emailConfig);
            services.AddScoped<IEmailSender, EmailSender>();
            #endregion


            services.AddDbContext<WisdomAppDBContext>(
                        options => options.UseSqlServer(Configuration.GetConnectionString("WisdomConString")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                    .AddEntityFrameworkStores<WisdomAppDBContext>();
            //services.AddAuthentication()
            //    .AddGoogle(options =>
            //    {
            //        IConfigurationSection googleAuthNSection =
            //            Configuration.GetSection("Authentication:Google");

            //        options.ClientId = googleAuthNSection["ClientId"];
            //        options.ClientSecret = googleAuthNSection["ClientSecret"];
            //    });

            services.AddAuthentication()
                    .AddGoogle(options =>
                    {
                        options.ClientId = "1039689570852-8j88v9qo4gljql8tktrhpi8mt2t13gbu.apps.googleusercontent.com";
                        options.ClientSecret = "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";
                        options.SignInScheme = IdentityConstants.ExternalScheme;
                    });
            //.AddFacebook(options =>
            //{
            //    options.ClientId = "2706976336106668";
            //    options.ClientSecret = "d7af4a4ecadfb1e35ec2850d4cca8f32";
            //});

            services.AddScoped<ISchedulerEventService<TaskViewModel>, SchedulerTaskService>(); //Scheduler
            services.AddControllersWithViews();
            services.AddMvc();
            services.AddKendo();
            services.AddHttpClient();
            //upoading
            services.Configure<FormOptions>(x =>
            {
                x.ValueLengthLimit = int.MaxValue;
                x.MultipartBodyLengthLimit = int.MaxValue; // In case of multipart
            });
           
            services.AddControllers().AddJsonOptions(jsonOptions =>
            {
                jsonOptions.JsonSerializerOptions.PropertyNamingPolicy = null;
            })
            .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddAuthorization(options =>
            {
                #region Tabs
                options.AddPolicy("Administration",
                        policy => policy.RequireClaim("1"));
                options.AddPolicy("BasicData",
                        policy => policy.RequireClaim("2"));
                options.AddPolicy("Events",
                        policy => policy.RequireClaim("3"));
                options.AddPolicy("Courses",
                        policy => policy.RequireClaim("4"));
                options.AddPolicy("Lecturer",
                        policy => policy.RequireClaim("5"));
                options.AddPolicy("Staff",
                        policy => policy.RequireClaim("6"));
                options.AddPolicy("Reservation",
                        policy => policy.RequireClaim("7"));
                options.AddPolicy("Building",
                        policy => policy.RequireClaim("8"));
                options.AddPolicy("Room",
                        policy => policy.RequireClaim("9"));
                #endregion

                #region Basic Data

                options.AddPolicy("CreateBasicData",
                policy => policy.RequireClaim("11"));
                options.AddPolicy("ViewBasicData",
                        policy => policy.RequireClaim("12"));
                options.AddPolicy("ModifyBasicData",
                        policy => policy.RequireClaim("13"));
                options.AddPolicy("RemoveBasicData",
                        policy => policy.RequireClaim("14"));

                #endregion

                #region User
                options.AddPolicy("CreateUser",
                        policy => policy.RequireClaim("15"));
                options.AddPolicy("ViewUser",
                        policy => policy.RequireClaim("16"));
                options.AddPolicy("ModifyUser",
                        policy => policy.RequireClaim("17"));
                options.AddPolicy("RemoveUser",
                        policy => policy.RequireClaim("18"));

                options.AddPolicy("ViewUserClaim",
                        policy => policy.RequireClaim("19"));
                options.AddPolicy("CreateUserClaim",
                        policy => policy.RequireClaim("20"));


                #endregion

                #region Role
                options.AddPolicy("CreateRole",
                        policy => policy.RequireClaim("23"));
                options.AddPolicy("ViewRole",
                        policy => policy.RequireClaim("24"));
                options.AddPolicy("ModifyRole",
                        policy => policy.RequireClaim("25"));
                options.AddPolicy("RemoveRole",
                        policy => policy.RequireClaim("26"));


                options.AddPolicy("CreateRoleUser",
                        policy => policy.RequireClaim("27"));
                options.AddPolicy("ViewRoleUser",
                        policy => policy.RequireClaim("28"));

                options.AddPolicy("CreateRoleClaim",
                        policy => policy.RequireClaim("29"));
                options.AddPolicy("ViewRoleClaim",
                        policy => policy.RequireClaim("30"));

                #endregion

                #region University
                options.AddPolicy("CreateUniversity",
                        policy => policy.RequireClaim("31"));
                options.AddPolicy("ViewUniversity",
                        policy => policy.RequireClaim("32"));
                #endregion

                #region Login Profiles
                options.AddPolicy("CreateLoginProfiles",
                        policy => policy.RequireClaim("33"));
                options.AddPolicy("ModifyLoginProfiles",
                        policy => policy.RequireClaim("34"));
                options.AddPolicy("RemoveLoginProfiles",
                        policy => policy.RequireClaim("35"));
                options.AddPolicy("ViewLoginProfiles",
                        policy => policy.RequireClaim("36"));
                options.AddPolicy("DeactivateLoginProfiles",
                        policy => policy.RequireClaim("37"));
                options.AddPolicy("DissaproveLoginProfiles",
                        policy => policy.RequireClaim("38"));
                options.AddPolicy("ApproveLoginProfiles",
                        policy => policy.RequireClaim("39"));
                options.AddPolicy("RejectLoginProfiles",
                        policy => policy.RequireClaim("40"));

                #endregion

                #region Staff

                options.AddPolicy("CreateStaffGroup",
                        policy => policy.RequireClaim("51"));
                options.AddPolicy("ViewStaffGroup",
                        policy => policy.RequireClaim("52"));
                options.AddPolicy("ModifyStaffGroup",
                        policy => policy.RequireClaim("53"));
                options.AddPolicy("RemoveStaffGroup",
                        policy => policy.RequireClaim("54"));


                options.AddPolicy("CreateStaff",
                        policy => policy.RequireClaim("55"));
                options.AddPolicy("ViewStaff",
                        policy => policy.RequireClaim("56"));
                options.AddPolicy("ModifyStaff",
                        policy => policy.RequireClaim("57"));
                options.AddPolicy("RemoveStaff",
                        policy => policy.RequireClaim("58"));


                options.AddPolicy("ManageStaffAssign",
                        policy => policy.RequireClaim("59"));
                options.AddPolicy("ViewStaffAssign",
                        policy => policy.RequireClaim("60"));

                #endregion

                #region Event

                options.AddPolicy("CreateEvent",
                        policy => policy.RequireClaim("62"));
                options.AddPolicy("ViewEvent",
                        policy => policy.RequireClaim("63"));
                options.AddPolicy("ModifyEvent",
                        policy => policy.RequireClaim("64"));
                options.AddPolicy("RemoveEvent",
                        policy => policy.RequireClaim("65"));


                options.AddPolicy("CreateUniversityEvent",
                        policy => policy.RequireClaim("66"));
                options.AddPolicy("ViewUniversityEvent",
                        policy => policy.RequireClaim("67"));
                options.AddPolicy("ModifyUniversityEvent",
                        policy => policy.RequireClaim("68"));
                options.AddPolicy("RemoveUniversityEvent",
                        policy => policy.RequireClaim("69"));
                #endregion

                #region Calender
                options.AddPolicy("ViewCalender",
                        policy => policy.RequireClaim("70"));
                #endregion

                #region Lecturer
                options.AddPolicy("CreateLecturer",
                    policy => policy.RequireClaim("79"));
                options.AddPolicy("ViewLecturer",
                        policy => policy.RequireClaim("80"));
                options.AddPolicy("ModifyLecturer",
                        policy => policy.RequireClaim("81"));
                options.AddPolicy("RemoveLecturer",
                        policy => policy.RequireClaim("82"));

                options.AddPolicy("ViewAssignLecturer",
                        policy => policy.RequireClaim("83"));


                options.AddPolicy("RegisterCourse",
                        policy => policy.RequireClaim("21"));
                options.AddPolicy("RoomBooking",
                        policy => policy.RequireClaim("41"));
                options.AddPolicy("ViewReservationInfo",
                        policy => policy.RequireClaim("42"));
                options.AddPolicy("RegisterFacsBlcoks",
                        policy => policy.RequireClaim("43"));
                options.AddPolicy("RegisterBlcoks",
                        policy => policy.RequireClaim("44"));
                options.AddPolicy("RegisterFloors",
                        policy => policy.RequireClaim("45"));
                options.AddPolicy("RoomTypes",
                        policy => policy.RequireClaim("22"));
                options.AddPolicy("FacultyCategories",
                        policy => policy.RequireClaim("46"));
                options.AddPolicy("RoomIndex",
                        policy => policy.RequireClaim("47"));
                options.AddPolicy("BookingOverview",
                        policy => policy.RequireClaim("48"));

                #endregion


                options.AddPolicy("LecturersOnly",
                       policy => policy.Requirements.Add(new UserType("L")));

                options.AddPolicy("StaffOnly",
                       policy => policy.Requirements.Add(new UserType("I")));

                options.AddPolicy("StaffAssistOnly",
                       policy => policy.Requirements.Add(new UserType("A")));

                options.AddPolicy("StudentOnly",
                       policy => policy.Requirements.Add(new UserType("S")));


            });


            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(60);
            });


            services.AddSingleton<DataProtectionPurposeStrings>();
            services.AddSingleton<IAuthorizationHandler, UserTypeHandler>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseSession();
            app.UseHttpsRedirection();
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Account}/{action=Index}/{id?}");
            });
        }
    }

}
