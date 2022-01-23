using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MimeKit;
using Pickup.Application.Configurations;
using Pickup.Application.Interfaces.Services;
using Pickup.Application.Requests.Mail;
using System.IO;
using System.Threading.Tasks;

namespace Pickup.Infrastructure.Shared.Services
{
    public class SMTPMailService : IMailService
    {
        public MailConfiguration _config { get; }
        public ILogger<SMTPMailService> _logger { get; }

        public SMTPMailService(IOptions<MailConfiguration> config, ILogger<SMTPMailService> logger)
        {
            _config = config.Value;
            _logger = logger;
        }

        public async Task SendAsync(MailRequest request)
        {
            try
            {
                var email = new MimeMessage();
                email.Sender = MailboxAddress.Parse(request.From ?? _config.From);

                email.To.Add(MailboxAddress.Parse(request.To));
                email.Subject = request.Subject;
                var builder = new BodyBuilder();
                builder.HtmlBody = request.Body;
                if (request.Attachments != null)
                {
                    byte[] fileBytes;
                    foreach (var file in request.Attachments)
                    {
                        if (file.Length > 0)
                        {
                            using var ms = new MemoryStream();
                            file.CopyTo(ms);
                            fileBytes = ms.ToArray();

                            builder.Attachments.Add(file.FileName, fileBytes, ContentType.Parse(file.ContentType));
                        }
                    }
                }
                email.Body = builder.ToMessageBody();
                email.From.Add(new MailboxAddress(_config.DisplayName, _config.From));
                using var smtp = new SmtpClient();
                smtp.Connect(_config.Host, _config.Port, SecureSocketOptions.StartTls);
                smtp.Authenticate(_config.UserName, _config.Password);
                await smtp.SendAsync(email);
                smtp.Disconnect(true);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message, ex);
            }
        }
    }
}