namespace gb;

/// <summary>
/// Обычный товар
/// </summary>
internal abstract class Product 
{
    internal string Name { get; set; }
    internal string Description { get; set; }

    internal abstract long Price { get; set; }
    internal abstract List<long>? PriceHistory { get; private protected set; }
    internal abstract double GetAveragePrice();
}