using System;
using System.Collections.Generic;
using System.Text;

namespace RefactoringLab
{
    public class PushChannel : INotificationChannel
    {
        public string Name => "push";
        public void Deliver(string to, string label, string message) =>
            Console.WriteLine($"[{label}] {to}: {message}");
    }
}
