using MailKit.Net.Smtp;
using MimeKit;

namespace BackEnd.Services
{
    public class EmailServices
    {


        private const string SmtpHost = "mail.mailtest.radixweb.net"; // e.g., smtp.gmail.com
        private const int SmtpPort = 465; // e.g., 587 for Gmail
        private const string SmtpUsername = "testdotnet@mailtest.radixweb.net";
        private const string SmtpPassword = "Radix@web#8";
      public static   void sendEmailUserCre(string email,string Ebody,string Esub)
        {

            string body = Ebody;
            string subject = Esub;
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Devotee Management ", SmtpUsername));
            message.To.Add(new MailboxAddress("", email));
            message.Subject = subject;

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = body;

            message.Body = bodyBuilder.ToMessageBody();

            using (var client = new SmtpClient())
            {
                client.Connect(SmtpHost, SmtpPort);
                client.Authenticate(SmtpUsername, SmtpPassword);
                client.Send(message);
                client.Disconnect(true);
            }


        }
    }
}
