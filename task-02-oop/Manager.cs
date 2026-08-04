namespace Nix.Oop.Final;

public class  Manager(string name, int salary, int clientAmount) : Employee(name, salary)
{
    public override void SetBonus(int bonus)
    {
        if (clientAmount > 150)
            base.SetBonus(bonus + 1000);
        else if (clientAmount > 100)
            base.SetBonus(bonus + 500);
        else
            base.SetBonus(bonus);
    }
}