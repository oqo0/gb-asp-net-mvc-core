namespace gb;

class Program
{
    public static void Main()
    {
        // Придумайте небольшое приложение консольного типа, который берет различные Json структуры
        // (предположительно из разных веб сервисов), олицетворяюющие товар в магазинах.
        // Структуры не похожи друг на друга, но вам нужно их учесть, сделать универсально. Структуры
        // на ваше усмотрение.

        // Предположим, что есть 2 разных товара из разных магазинов:
        var appleItem = new Item(900, "Яблоко");
        var phoneProduct = new ExtendedProduct(20000, "IPhone");

        // Пусть нам нужно положить оба товара в один массив и иметь возможность ипользовать оба товара
        // для проверки истории изменения цены. Для этого можно использовать паттерн "Адаптер".
        var appleProduct = new ItemAdapter(appleItem);

        phoneProduct.Price = 22000;
        
        var productsList = new List<Product>
        {
            phoneProduct,
            appleProduct
        };

        foreach (Product product in productsList)
        {
            Console.WriteLine($"Товар: {product.Name} | Цена: {product.Price}$ | Средняя цена: {product.GetAveragePrice()}$");
        }
    }
}