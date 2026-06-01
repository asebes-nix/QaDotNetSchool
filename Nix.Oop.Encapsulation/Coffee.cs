namespace Nix.Oop.Encapsulation;

public class Coffee
{
    private string _name;
    private int _price;

    public Coffee(string name, int price)
    {
        _name = name;
        _price = price;
    }

    public string Name
    {
        get { return _name; }
        set
        {
            if (!string.IsNullOrWhiteSpace(value))
                _name = value;
        }
    }

    public int Price
    {
        get { return _price; }
        set
        {
            if (value > 0)
                _price = value;
        }
    }

    private void DisplayInfo()
    {
        Console.WriteLine($"Coffee Name: {_name}, Price: {_price}");
    }

    public void PrintInfo()
    {
        DisplayInfo();
        Console.WriteLine("Coffee: because adulting is hard.");
    }
}