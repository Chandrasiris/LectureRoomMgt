using System;
using System.Text;

namespace LectureRoomMgt.ClassFiles
{
    public static class CommonMethods
    {
        public static string additionalKey = "@#$SD4SH56&&*";

        public static string EncryptText(string txt)
        {
            if (string.IsNullOrEmpty(txt))
            {
                return "";
            }

            txt += additionalKey;
            var txtBytes = Encoding.UTF8.GetBytes(txt);

            return Convert.ToBase64String(txtBytes);
        }

        public static string DecryptText(string txt)
        {
            if (string.IsNullOrEmpty(txt))
            {
                return "";
            }

            var base64Txt = Convert.FromBase64String(txt);
            var result = Encoding.UTF8.GetString(base64Txt);
            result = result.Substring(0, result.Length - additionalKey.Length);

            return result;
        }
    }
}
