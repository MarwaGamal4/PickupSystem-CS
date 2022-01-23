
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Pickup.Application.Requests.Mail
{
    public class MailRequest
    {
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string From { get; set; }
        public IList<IFormFile> Attachments { get; set; } = null;
    }
}