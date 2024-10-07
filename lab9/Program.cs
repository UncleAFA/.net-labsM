using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

class Customer
{
    public string Name { get; set; }
    public string Address { get; set; }
    public double Discount { get; set; }
}

class Product
{
    public string Name { get; set; }
    public decimal Price { get; set; }
}

class ProductDatabase
{
    public Dictionary<string, Product> Products { get; set; } = new Dictionary<string, Product>();

    public void Serialize(string fileName)
    {
        var json = JsonConvert.SerializeObject(this);
        File.WriteAllText(fileName, json);
    }

    public static ProductDatabase Deserialize(string fileName)
    {
        var json = File.ReadAllText(fileName);
        return JsonConvert.DeserializeObject<ProductDatabase>(json);
    }
}

class OrderLine
{
    public int Quantity { get; set; }
    public Product Product { get; set; }
}

class Order
{
    public int OrderNumber { get; set; }
    public Customer Customer { get; set; }
    public decimal Discount { get; set; }
    public decimal TotalCost { get; set; }
    public List<OrderLine> OrderLines { get; set; } = new List<OrderLine>();

    public void CalculateTotalCost()
    {
        decimal total = 0;
        foreach (var line in OrderLines)
        {
            total += line.Product.Price * line.Quantity;
        }
        TotalCost = total * (1 - (decimal)Customer.Discount);
    }

    public void SaveToFile(string fileName)
    {
        var json = JsonConvert.SerializeObject(this);
        File.WriteAllText(fileName, json);
    }
}

class Program
{
    static void Main()
    {
        // Создание и заполнение базы данных товаров
        var productDatabase = new ProductDatabase();
        productDatabase.Products.Add("001", new Product { Name = "Product1", Price = 100 });
        productDatabase.Products.Add("002", new Product { Name = "Product2", Price = 200 });
        productDatabase.Serialize("products.json");

        // Ввод данных покупателя
        Console.WriteLine("Введите имя покупателя:");
        string customerName = Console.ReadLine();
        Console.WriteLine("Введите адрес покупателя:");
        string customerAddress = Console.ReadLine();
        Console.WriteLine("Введите скидку покупателя:");
        double customerDiscount = double.Parse(Console.ReadLine());

        var customer = new Customer
        {
            Name = customerName,
            Address = customerAddress,
            Discount = customerDiscount
        };

        // Создание заказа
        var order = new Order
        {
            OrderNumber = 1,
            Customer = customer,
            Discount = (decimal)customer.Discount
        };

        // Формирование строк заказа
        while (true)
        {
            Console.WriteLine("Введите код товара (или 'exit' для завершения):");
            string productCode = Console.ReadLine();
            if (productCode.ToLower() == "exit") break;

            if (productDatabase.Products.TryGetValue(productCode, out Product product))
            {
                Console.WriteLine("Введите количество:");
                int quantity = int.Parse(Console.ReadLine());

                order.OrderLines.Add(new OrderLine
                {
                    Product = product,
                    Quantity = quantity
                });
            }
            else
            {
                Console.WriteLine("Товар не найден.");
            }
        }

        // Расчет общей стоимости и сохранение заказа
        order.CalculateTotalCost();
        order.SaveToFile("order.json");

        Console.WriteLine("Заказ сохранен в файл 'order.json'.");
    }
}
//1. Классы:Созданы классы `Customer`, `Product`, `ProductDatabase`, `OrderLine`, и `Order` для хранения соответствующей информации.
//2. Сериализация/Десериализация:**Используется библиотека Newtonsoft.Json для сериализации и десериализации объектов.
//3. Логика программы:
//-Создается база данных товаров и сохраняется в файл.
//- Вводятся данные покупателя и создается объект `Customer`.
//- Создается заказ и добавляются строки заказа с товарами и их количеством.
//- Общая стоимость заказа рассчитывается с учетом скидки покупателя.
//- Заказ сохраняется в файл.