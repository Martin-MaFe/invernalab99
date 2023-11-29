using InvernalabProject.Shared.Entities;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace InvernalabProject.Server.Models
{
    public class SendContactMail
    {
        public Boolean CreateEmailInvernalabM(UserFormContactE user)
        {       
            try
            {
                MailMessage objEmail = new MailMessage();
                objEmail.From = new MailAddress("invernalabcompany@gmail.com", "Sistema INVERNALAB", System.Text.Encoding.UTF8);
                objEmail.To.Add("invernalabcompany@gmail.com");
                objEmail.Subject = user.Subject;
                objEmail.Body = "La empresa: " + user.CompanyName + " con nit " + user.Nit +
                    " a traves de su representante " + user.RepresentativeName +
                    " envia la siguiente peticion: " + "<br/>" + user.Message + "<br/>" +
                    " Datos de contacto: " + "<br/>" +
                    "Telefono: " + user.Telephone + "<br/>" +
                    "Email: " + user.Email.Replace(" ","") + "<br/>";
                objEmail.IsBodyHtml = true;
                objEmail.Priority = MailPriority.Normal;

                SendEmail(objEmail);
                return true;

            }
            catch (SmtpException smtpEx)
            {
                Console.WriteLine("Error al enviar correo, " + smtpEx.Message);
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al crear correo, " + ex.Message);
                return false;
            }
        }  
        public Boolean CreateEmailResponseM(UserFormContactE user)
        {
            try
            {
                MailMessage objEmail = new MailMessage();
                objEmail.From = new MailAddress("invernalabcompany@gmail.com", "Sistema INVERNALAB", System.Text.Encoding.UTF8);
                objEmail.To.Add(user.Email.Replace(" ",""));
                objEmail.Subject = "Respuesta de INVERNALAB a su solicitud";
                objEmail.Body = "Señor " + user.RepresentativeName + "," + "<br/>" +
                    "Hemos recibido su solicitud en nuestra plataforma, nos comunicaremos con usted lo mas pronto posible.";
                objEmail.IsBodyHtml = true;
                objEmail.Priority = MailPriority.Normal;                
                SendEmail(objEmail);
                return true;
            }
            catch (SmtpException smtpEx)
            {
                Console.WriteLine("Error al enviar correo, " + smtpEx.Message);
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
