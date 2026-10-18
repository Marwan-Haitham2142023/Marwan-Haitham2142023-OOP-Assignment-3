using RefactoringLab.Part02.Enrollment;
using System;
using System.Collections.Generic;
using System.Text;

namespace Enrollement_Task
{
    public class EnrollmentFacade
    {
        private readonly PaymentGateway _gateway = new();
        private readonly SeatInventory _inventory = new();
        private readonly InvoiceGenerator _invoices = new();
        private readonly EmailService _email = new();

        public void Enroll(string studentId, string courseId, decimal amount)
        {
            _gateway.Charge(studentId, amount);
            _inventory.Reserve(courseId, studentId);
            var invoiceId = _invoices.Create(studentId, amount);
            _email.Send(studentId, "Enrollment Confirmed", $"Invoice {invoiceId}");
        }
    }
}
