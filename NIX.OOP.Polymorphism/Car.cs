namespace Nix.Oop.Polymorphism;

public class Car
{
    protected int quantity;
    protected int warranty;

    public virtual void GetQuantity()
    {
    Console.WriteLine($"{quantity} cars ready for operation");
    }

    public virtual void GetFullInfo()
    {
        Console.WriteLine($"{quantity} cars ready for operation and {warranty} years warranty");
    }

    public void SetWarranty(int warranty)
    {
        this.warranty = warranty;
    }

    public void SetQuantity(int quantity)
    {
        this.quantity = quantity;
    }
}
