using System;
using System.Linq;

public class Supplier
{
    private string _name;
    private string _phone;
    private string _inn;

    public string Name
    {
        get => _name;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Имя поставщика не может быть пустым.", nameof(value));
            _name = value;
        }
    }

    public string Phone
    {
        get => _phone;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Телефон не может быть пустым.", nameof(value));

            if (!value.All(c => char.IsDigit(c) || c == '+' || c == '-' || c == ' '))
                throw new ArgumentException("Телефон может содержать только цифры, '+', '-' и пробелы.", nameof(value));

            _phone = value;
        }
    }

    public string Inn
    {
        get => _inn;
        private set
        {
            if (string.IsNullOrWhiteSpace(value) || (value.Length != 10 && value.Length != 12) || !value.All(char.IsDigit))
                throw new ArgumentException("ИНН должен состоять ровно из 10 или 12 цифр.", nameof(value));

            _inn = value;
        }
    }

    public Supplier(string name, string phone, string inn)
    {
        Name = name;
        Phone = phone;
        Inn = inn;
    }

    public override string ToString() => $"{Name} (ИНН: {Inn}, Тел: {Phone})";
}