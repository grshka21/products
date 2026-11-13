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
    }
}
