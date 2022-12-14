using System.Numerics;

namespace gb;

/// <summary>
/// Товар, структура которого отличается от Product
/// </summary>
internal class Item
{
    private int _id;
    
    internal int ID { get; }
    internal long Price { get; }
    internal string Name { get; set; }

    internal Item(long price, string name)
    {
        ID = _id++;
        Price = price;
        Name = name;
    }
}