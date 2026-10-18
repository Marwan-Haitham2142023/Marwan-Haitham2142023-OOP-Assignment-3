using System;
using System.Collections.Generic;
using System.Text;

namespace RefactoringLab
{
    public class AramexExpressCarrier : IShippingCarrier
    {
        public string Name => "AramexExpress";
        public decimal CalculateCost(decimal weightKg) => weightKg * 20m;
    }
}
