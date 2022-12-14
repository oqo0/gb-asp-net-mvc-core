using System.Text.RegularExpressions;

namespace gb;

internal class ItemAdapter : Product
{
    private readonly Item _item;

    internal override List<long>? PriceHistory
    {
        get
        {
            var fixedPriceList = new long[1] { _item.Price };
            return fixedPriceList.ToList();
        }
        private protected set
        {
            return;
        }
    }

    internal override long Price
    {
        get => _item.Price;
        set { return; }
    }

    internal ItemAdapter(Item item)
    {
        this._item = item;
        Name = item.Name;
        Price = item.Price;
    }

    /// <summary>
    /// Item имеет неизменяемую цену, поэтому средняя цена не будет изменяться.
    /// </summary>
    internal override double GetAveragePrice() => _item.Price;
}