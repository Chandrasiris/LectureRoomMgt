using MailKit.Net.Smtp;
using MimeKit;
using LectureRoomMgt.Models;

namespace LectureRoomMgt.ClassFiles
{
    public static class EmailUtil
    {
        public static class WelcomeEmail
        {
            public static string GetFile()
            {
                return $@"EmailTemplate/Index.html";
            }

            public static void CreateEmail(MasterCompany company, string fileString, string accessCode, string reciever)
            {
                fileString = fileString.Replace("[HeaderText1]", "Please use the below access code")
                                       .Replace("[HeaderText2]", "to create an account.")
                                       .Replace("[AccessCode]", accessCode)
                                       .Replace("[CompanyName]", company.CompanyName)
                                       .Replace("[CompanyEmail]", company.CompanyEmail)
                                       .Replace("[FacebookAccount]", company.Facebook)
                                       .Replace("[TwitterAccount]", company.Twitter)
                                       .Replace("[LinkedInAccount]", company.LinkedIn)
                                       .Replace("[InstagramAccount]", company.Instagram)
                                       .Replace("[YouTubeAccount]", company.Youtube)
                                       .Replace("[FDisplayState]", company.Facebook != null ? "normal" : "none")
                                       .Replace("[TDisplayState]", company.Twitter != null ? "normal" : "none")
                                       .Replace("[IDisplayState]", company.Instagram != null ? "normal" : "none")
                                       .Replace("[LDisplayState]", company.LinkedIn != null ? "normal" : "none")
                                       .Replace("[YDisplayState]", company.Youtube != null ? "normal" : "none");

                var message = new MimeMessage();

                message.From.Add(new MailboxAddress(company.CompanyName, company.Email));
                message.To.Add(new MailboxAddress("User", reciever));
                message.Subject = "Access Code for Registration";

                var builder = new BodyBuilder();
                builder.HtmlBody = fileString;
                message.Body = builder.ToMessageBody();

                using (var client1 = new SmtpClient())
                {
                    client1.Connect("smtp.gmail.com", 587, false);
                    client1.Authenticate(company.Email, CommonMethods.DecryptText(company.EmailPassword));
                    client1.Send(message);

                    client1.Disconnect(true);
                }

            }
        }

        public static class ResetEmail
        {
            public static string GetFile()
            {
                return $@"EmailTemplate/Index.html";
            }

            public static void CreateEmail(MasterCompany company, string fileString, string accessCode, string reciever)
            {
                fileString = fileString.Replace("[HeaderText1]", "Please use the below code")
                                       .Replace("[HeaderText2]", "to reset your account.")
                                       .Replace("[AccessCode]", accessCode)
                                       .Replace("[CompanyName]", company.CompanyName)
                                       .Replace("[CompanyEmail]", company.CompanyEmail)
                                       .Replace("[FacebookAccount]", company.Facebook)
                                       .Replace("[TwitterAccount]", company.Twitter)
                                       .Replace("[LinkedInAccount]", company.LinkedIn)
                                       .Replace("[InstagramAccount]", company.Instagram)
                                       .Replace("[YouTubeAccount]", company.Youtube)
                                       .Replace("[FDisplayState]", company.Facebook != null ? "normal" : "none")
                                       .Replace("[TDisplayState]", company.Twitter != null ? "normal" : "none")
                                       .Replace("[IDisplayState]", company.Instagram != null ? "normal" : "none")
                                       .Replace("[LDisplayState]", company.LinkedIn != null ? "normal" : "none")
                                       .Replace("[YDisplayState]", company.Youtube != null ? "normal" : "none");

                var message = new MimeMessage();

                message.From.Add(new MailboxAddress(company.CompanyName, company.Email));
                message.To.Add(new MailboxAddress("User", reciever));
                message.Subject = "Reset Token";

                var builder = new BodyBuilder();
                builder.HtmlBody = fileString;
                message.Body = builder.ToMessageBody();

                using (var client1 = new SmtpClient())
                {
                    client1.Connect("smtp.gmail.com", 587, false);
                    client1.Authenticate(company.Email, CommonMethods.DecryptText(company.EmailPassword));
                    client1.Send(message);

                    client1.Disconnect(true);
                }

            }
        }

    }
}
