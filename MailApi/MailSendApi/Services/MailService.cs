using MailSendApi.Models;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;
using System.Threading;
using System.Threading.Tasks;


namespace MailSendApi.Services
{
    public interface IMailService
    {
        Task SendEmailAsync(MailRequest mailRequest);
    }
    public class MailService : IMailService
    {
        private readonly MailSettings _mailSettings;
        public MailService(IOptions<MailSettings> mailSettings)
        {
            _mailSettings = mailSettings.Value;
        }

        public async Task SendEmailAsync(MailRequest mailRequest)
        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(mailRequest.From);

            mail.To.Add(mailRequest.ToEmail);
            mail.Subject = mailRequest.Subject;
            mail.Body = mailRequest.Body;
            mail.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient(_mailSettings.Host, _mailSettings.Port);
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(_mailSettings.Mail, _mailSettings.Password);
            smtp.EnableSsl = true;
            Thread T1 = new Thread(delegate ()
            {
                smtp.Send(mail);
            });

            T1.Start();
        }
    }
}
