using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        var drill = new Product("Дрель ударная", initialStock: 7, minStock: 5);
        var hammer = new Product("Молоток", initialStock: 12, minStock: 15);
        var saw = new Product("Пила дисковая", initialStock: 4, minStock: 4);

        drill.SetMinStock(20);

        var products = new List<Product> { drill, hammer, saw };

        Console.WriteLine("=== Позиции ниже минимального остатка ===");
        foreach (var item in products.Where(p => p.IsBelowMinStock))
        {
            Console.WriteLine($"- {item.Name}: остаток {item.Stock} (мин. {item.MinStock})");
        }

        var supplier1 = new Supplier("ООО СтройСнаб", "+7 999 123-45-67", "7701234567");
        var supplier2 = new Supplier("ИП Иванов", "8-800-555-35-35", "770123456789");

        drill.AssignSupplier(supplier1);
        hammer.AssignSupplier(supplier1);
        saw.AssignSupplier(supplier2);

        Console.WriteLine("\n=== Информация о поставщиках ===");
        foreach (var item in products)
        {
            Console.WriteLine($"{item.Name} -> Поставщик: {item.Supplier}");
        }

        Console.WriteLine("\n=== Операции списания ===");
        drill.WriteOff(2, "повреждение при транспортировке");
        Console.WriteLine($"Остаток '{drill.Name}': {drill.Stock}, Всего списано: {drill.WrittenOffTotal}");
    }
}
