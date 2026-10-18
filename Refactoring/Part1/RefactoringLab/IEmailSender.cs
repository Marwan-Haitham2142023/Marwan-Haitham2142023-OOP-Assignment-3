using System;
using System.Collections.Generic;
using System.Text;

namespace RefactoringLab
{
    public interface IEmailSender
    {
        void Send(string to, string body);
    }
}
