using System.Net.Mail;
using System.Net.Security;
using System.Net;
using System.Security.Cryptography.X509Certificates;

namespace InvernalabProject.Server.Models
{
    public class CompanyEmail
    {
        public void SendEmail(string toEmail, string welcomeMessage, string assignedPassword)
        {
            MailMessage email = new MailMessage();
            email.From = new MailAddress("invernalabcompany@gmail.com");
            email.To.Add(toEmail);
            email.Subject = "¡Bienvenido a Invernalab!";

            email.Body = $"{welcomeMessage}\n\nTu usuario es: {toEmail}\n\nTu clave de acceso: {assignedPassword}";

            using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
            {
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("invernalabcompany@gmail.com", "kwblcnjvphytrrcf");
                smtp.EnableSsl = true;
                ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };

                try
                {
                    smtp.Send(email);
                    Console.WriteLine("Correo electrónico enviado con éxito.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al enviar el correo electrónico: {ex.Message}");
                }
            }
        }
    }
}
