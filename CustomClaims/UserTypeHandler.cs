using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using LectureRoomMgt.DAL;

namespace LectureRoomMgt.CustomClaims
{
    public class UserTypeHandler : AuthorizationHandler<UserType>
    {
        public WisdomAppDBContext DbContext { get; }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, UserType requirement)
        {
            if (requirement.TypeUser == "L")
            {
                if (!context.User.HasClaim(c => c.Type == "Lecturer"))
                {
                    return Task.CompletedTask;
                }
                context.Succeed(requirement);
            }
            else if (requirement.TypeUser == "I")
            {
                if (!context.User.HasClaim(c => c.Type == "Staff"))
                {
                    return Task.CompletedTask;
                }
                context.Succeed(requirement);
            }
            else if (requirement.TypeUser == "S")
            {
                if (!context.User.HasClaim(c => c.Type == "Student"))
                {
                    return Task.CompletedTask;
                }
                context.Succeed(requirement);
            }
            else if (requirement.TypeUser == "A")
            {
                if (!context.User.HasClaim(c => c.Type == "StaffAssist"))
                {
                    return Task.CompletedTask;
                }
                context.Succeed(requirement);
            }


            return Task.CompletedTask;
        }

    }
}
