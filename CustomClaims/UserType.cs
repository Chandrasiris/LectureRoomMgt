using Microsoft.AspNetCore.Authorization;

namespace LectureRoomMgt.CustomClaims
{
    public class UserType : IAuthorizationRequirement
    {
        public UserType(string typeUser)
        {
            TypeUser = typeUser;
        }

        public string TypeUser { get; set; }
    }
}
