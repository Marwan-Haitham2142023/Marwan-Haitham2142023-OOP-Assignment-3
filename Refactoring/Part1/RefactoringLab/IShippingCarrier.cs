using System;
using System.Collections.Generic;
using System.Text;

namespace RefactoringLab
{
    public interface IShippingCarrier
    {
        string Name { get; }
        decimal CalculateCost(decimal weightKg);
    }

}
