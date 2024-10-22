using Asmaa.DAL.Model;
using System.Net;
using System.Net.Mail;

namespace Asmaa.Pl.Helper
{
    public class EmailHealper
    {
        public static void SendEmail(Email email)
        {
            try
            {
                var client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true;//ما حكى فايدتها
                client.Credentials = new NetworkCredential("asma.esam.20122@gmail.com", "dtaj trzj azvk fqaz");
                client.Send("asma.esam.20122@gmail.com", email.Reciver, email.Subject, email.Body);
/*                
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential("tariqshreen00@gmail.com", "rphu xuiv pzqt rvvv");
                client.Send("tariqshreem00@gmail.com", email.Recivers, email.Subject, email.Body);*/
            }
            catch (Exception ex)
            {
                // هنا يمكن تسجيل الخطأ أو عرضه على الشاشة لتتبعه
                Console.WriteLine("Failed to send email: " + ex.Message);
            }
        }
    }
}
