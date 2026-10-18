using System;
using System.Collections.Generic;
using System.Text;

namespace RefactoringLab
{
    public class AramexCarrier : IShippingCarrier
    {
        public string Name => "Aramex";
        public decimal CalculateCost(decimal weightKg) => weightKg * 12m;
    }
}
