using System;
using System.Collections.Generic;
using System.Text;

namespace RefactoringLab
{
    public interface INotificationChannel
    {
        string Name { get; }
        void Deliver(string to, string label, string message);
    }
}
