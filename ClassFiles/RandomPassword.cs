using System;
using System.Linq;
using System.Text;

namespace LectureRoomMgt.ClassFiles
{
    public class RandomPassword
    {
        public static string CreatePassword(int length)
        {
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < length--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }

            if (!res.ToString().Any(char.IsDigit))
            {
                return res.ToString().Substring(0, 4) + 1;
            }
            else
            {
                return res.ToString();
            }
        }
    }
}
