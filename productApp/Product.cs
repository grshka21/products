using System;

public class Product
{
    private int _stock;
    private int _minStock;

    public string Name { get; }

    public int Stock
    {
        get => _stock;
        private set => _stock = value;
    }

    public int MinStock
    {
        get => _minStock;
        private set
        {
            if (value < 0 || value > 100_000)
                throw new ArgumentOutOfRangeException(nameof(value), "Минимальный остаток должен быть от 0 до 100 000.");
            _minStock = value;
        }
    }

    public bool IsBelowMinStock => Stock < MinStock;

    public void SetMinStock(int value)
    {
        MinStock = value;
    }

    public Product(string name, int initialStock, int minStock = 0)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Название товара не может быть пустым.", nameof(name));
        if (initialStock < 0)
            throw new ArgumentOutOfRangeException(nameof(initialStock), "Начальный остаток не может быть отрицательным.");

        Name = name;
        Stock = initialStock;
        MinStock = minStock;
    }

    public void RemoveStock(int amount)
    {
        if (amount <= 0)
            throw new ArgumentOutOfRangeException(nameof(amount), "Количество должно быть больше нуля.");
        if (amount > Stock)
            throw new InvalidOperationException("Недостаточно товара на складе.");

        Stock -= amount;
    }
}
