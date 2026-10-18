using System;
using System.Collections.Generic;
using System.Text;

namespace RefactoringLab
{
    public class SmtpEmailSender : IEmailSender
    {
        public void Send(string to, string body) =>
            Console.WriteLine($"[SMTP] to={to} body={body}");
    }
}
