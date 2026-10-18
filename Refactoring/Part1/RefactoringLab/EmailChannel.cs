using System;
using System.Collections.Generic;
using System.Text;

namespace RefactoringLab
{
    public class EmailChannel : INotificationChannel
    {
        public string Name => "email";
        public void Deliver(string to, string label, string message) =>
            Console.WriteLine($"[{label}] {to}: {message}");
    }
}
