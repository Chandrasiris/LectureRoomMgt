using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LectureRoomMgt.Models.ViewModels
{
    public class RoleClaimsViewModel
    {
        public RoleClaimsViewModel()
        {
            Claims = new List<ClaimViewModel>();
        }

        public string RoleId { get; set; }
        public List<ClaimViewModel> Claims { get; set; }
    }
}
