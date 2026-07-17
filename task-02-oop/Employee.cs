namespace Nix.Oop.Final;

public class Employee(string name, int salary)
{
    private int _bonus;

    public string Name => name;

    public int Salary
    {
        get => salary;
        set => salary = value;
    }

    public virtual void SetBonus(int bonus)
    {
        _bonus = bonus;
    }

    public int ToPay() => salary + _bonus;
}