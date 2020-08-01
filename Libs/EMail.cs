using System;
using System.Net;
using System.Net.Mail;

namespace Libs
{
    public class EMail
    {
        public string FromAddress { get; set; }
        public string FromDescription { get; set; }
        public string UsrLogin { get; set; }
        public string UsrPwd { get; set; }
        public string Smtp { get; set; }
        public int Port { get; set; }
        public Boolean Ssl { get; set; }
        public Boolean Html { get; set; }

        public string To { get; set; }
        public string MailSubject { get; set; }
        public string MailBody { get; set; }

        public void Send()
        {

            SmtpClient oSmtp = new SmtpClient(Smtp);
            oSmtp.Port = Port;
            oSmtp.Credentials = new NetworkCredential(UsrLogin, UsrPwd);
            oSmtp.EnableSsl = Ssl;

            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(FromAddress, FromDescription);
            mailMessage.Subject = MailSubject;
            mailMessage.Body = MailBody;
            mailMessage.IsBodyHtml = Html;
            mailMessage.To.Add(To);

            try
            {
                oSmtp.Send(mailMessage);
                oSmtp.Dispose();
            } catch
            {
                oSmtp.Dispose();
                throw new Exception("El EMail no pudo ser Enviado");
            }
            

        }
    }
}
