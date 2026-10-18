using System;
using System.Collections.Generic;
using System.Text;

namespace RefactoringLab
{
    public class FedExCarrier : IShippingCarrier
    {
        public string Name => "FedEx";
        public decimal CalculateCost(decimal weightKg) => weightKg * 15m;
    }
}
