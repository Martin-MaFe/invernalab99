using InvernalabProject.Shared.Entities;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace InvernalabProject.Server.Models
{
    public class RecoverPasswordM
    {
        private InvernalabContext context;
        public RecoverPasswordM(InvernalabContext _context)
        {
            context = _context;
        }

        public Boolean SendEmailPassword(string mail)
        {
            Usuario user = context.Usuarios.FirstOrDefault(u => u.Email == mail.Replace(" ",""));
            if (user == null)
            {             
                return false;
            }
            else if (createEmail(user))
            {
                return true;
            }
            else
            {
                return false;   
            }
            
        }

        public Boolean createEmail(Usuario user)
        {
            try
            {
                MailMessage objEmail = new MailMessage();
                objEmail.From = new MailAddress("invernalabcompany@gmail.com", "Sistema INVERNALAB", System.Text.Encoding.UTF8);
                objEmail.To.Add(user.Email);
                objEmail.Subject = "Recuperar contraseña Invernalab";
                objEmail.Body = "Señor " + user.Nombre + "," + "Estas son sus credenciales de acceso a Invernalab" + "<br/>" +
                    "Usuario: " + user.Email + "<br/>"+
                    "Contraseña: " + user.Contraseña;

                objEmail.IsBodyHtml = true;
                objEmail.Priority = MailPriority.Normal;
                SendEmail(objEmail);
                return true;
            }
            catch (SmtpException ex)
            {
                Console.WriteLine("Error al Enviar el correo, " + ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al crear correo, " + ex.Message);
                return false;
            }
        }

        public void SendEmail(MailMessage email)
        {
            SmtpClient smtp = new SmtpClient();
            smtp.UseDefaultCredentials = false;
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.Credentials = new System.Net.NetworkCredential("invernalabcompany@gmail.com", "kwblcnjvphytrrcf");
            ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
            smtp.EnableSsl = true;
            smtp.Send(email);
        }
    }
}
