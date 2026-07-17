namespace Nix.Oop.Final;

public class  Manager(string name, int salary, int clientAmount) : Employee(name, salary)
{
    private readonly int _quantity = clientAmount;

    public override void SetBonus(int bonus)
    {
        if (_quantity > 150)
            base.SetBonus(bonus + 1000);
        else if (_quantity > 100)
            base.SetBonus(bonus + 500);
        else
            base.SetBonus(bonus);
    }
}