namespace Nix.Oop.Final;

public class Employee
{
    private string _name;
    private int _salary;
    private int _bonus;

    public string Name { get => _name; }

    public int Salary
    {
        get => _salary;
        set => _salary = value;
    }

    public Employee(string name, int salary)
    {
        _name = name;
        _salary = salary;
    }
    public virtual void SetBonus(int bonus)
    {
        _bonus = bonus;
    }

    public int ToPay() => _salary + _bonus;
}