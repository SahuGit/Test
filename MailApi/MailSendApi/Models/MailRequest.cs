using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MailSendApi.Models
{
    public class MailRequest
    {
        public string ToEmail { get; set; }
        public String Subject { get; set; }
        public String Body { get; set; }
        public string From { get; set; }
    }
}
