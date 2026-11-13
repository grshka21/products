using System;

public class Product
{
    private int _stock;
    private int _minStock;
    private Supplier _supplier;
    private int _writtenOffTotal;

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

    public Supplier Supplier
    {
        get => _supplier;
        private set => _supplier = value;
    }

    public void AssignSupplier(Supplier supplier)
    {
        if (supplier == null)
            throw new ArgumentNullException(nameof(supplier), "Поставщик не может быть null.");

        Supplier = supplier;
    }

    public int WrittenOffTotal => _writtenOffTotal;

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

    public void WriteOff(int amount, string reason)
    {
        if (string.IsNullOrWhiteSpace(reason))
            throw new ArgumentException("Необходимо указать причину списания.", nameof(reason));

        RemoveStock(amount);

        _writtenOffTotal += amount;
        Console.WriteLine($"[Списание] Товар: {Name}, Кол-во: {amount}, Причина: {reason}");
    }
}
