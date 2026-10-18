using System;
using System.Collections.Generic;
using System.Text;

namespace RefactoringLab
{
    public class SmsChannel : INotificationChannel
    {
        public string Name => "sms";
        public void Deliver(string to, string label, string message) =>
            Console.WriteLine($"[{label}] {to}: {message}");
    }
}
