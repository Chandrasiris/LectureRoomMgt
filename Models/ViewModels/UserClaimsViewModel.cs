using System.Collections.Generic;

namespace LectureRoomMgt.Models.ViewModels
{
    public class UserClaimsViewModel
    {
        public UserClaimsViewModel()
        {
            Claims = new List<ClaimViewModel>();
        }

        public string UserId { get; set; }
        public List<ClaimViewModel> Claims { get; set; }
    }
}
