using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSharp___WebBlog.ViewModels
{
    // Used to programmatically configure the SMTP server
    public class MailSettings
    {
        // Purpose: To configure and use an SMTP server from external service (i.e. Google)
        public string Mail { get; set; }

        // Allows you to rename the sender's display in the email
        public string DisplayName { get; set; }

        public string Password { get; set; }

        // SMTP Host
        public string Host { get; set; }

        public int Port { get; set; }
    }
}