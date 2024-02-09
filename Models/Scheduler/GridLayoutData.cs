using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LectureRoomMgt.Models.Scheduler
{
    public class GridLayoutData
    {
        public DateTime SelectedDate { get; set; }
        public List<MyReservations> Bookings { get; set; }
        //public List<GridLayoutArticle> RecommendedArticles { get; set; }
        //public List<string> Tags
        //{
        //    get; set;
        //}
    }
}
