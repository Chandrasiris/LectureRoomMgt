using LectureRoomMgt.Models.Staff;

namespace LectureRoomMgt.Models
{
    public class BasicDataViewModel
    {
        public MasterTitle MasterTitle { get; set; }
        public MasterGender MasterGender { get; set; }
        public MasterDesignation MasterDesignation { get; set; }
        public CommunicationType CommunicationType { get; set; }
    }
}
