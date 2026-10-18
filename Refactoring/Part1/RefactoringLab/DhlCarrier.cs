using System;
using System.Collections.Generic;
using System.Text;

namespace RefactoringLab
{
    public class DhlCarrier : IShippingCarrier
    {
        public string Name => "DHL";
        public decimal CalculateCost(decimal weightKg) => weightKg * 18m;
    }
}
