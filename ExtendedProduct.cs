namespace gb;

/// <summary>
/// Товар с дополнительным функционалом
/// </summary>
internal class ExtendedProduct : Product
{
    private long _price;

    internal override List<long>? PriceHistory { get; private protected set; }
    internal override long Price
    {
        get => _price;
        set
        {
            PriceHistory ??= new List<long>();
            
            PriceHistory.Add(value);
            _price = value;
        }
    }

    internal ExtendedProduct(long price, string name, string description = "No description")
    {
        Price = price;
        Name = name;
        Description = description;
    }
    
    /// <summary>
    /// Считает среднюю цену продукта из истории изменения цены
    /// </summary>
    /// <returns>Средняя стоимость товара</returns>
    internal override double GetAveragePrice()
    {
        if (PriceHistory == null)
        {
            return 0;
        }
        
        return PriceHistory.Average();
    }
}
