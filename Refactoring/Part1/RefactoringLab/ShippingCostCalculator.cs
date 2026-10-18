namespace RefactoringLab;

public class ShippingCostCalculator
{
    private readonly IShippingCarrier[] _carriers;

    public ShippingCostCalculator(IShippingCarrier[] carriers)
    {
        _carriers = carriers;
    }

    public decimal Calculate(string carrier, decimal weightKg)
    {
        foreach (var c in _carriers)
        {
            if (c.Name == carrier)
                return c.CalculateCost(weightKg);
        }
        throw new ArgumentException($"Unknown carrier: {carrier}");
    }
}
