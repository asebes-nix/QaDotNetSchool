namespace Nix.Oop.Final;

public class SalesPerson(string name, int salary, int percent) : Employee(name, salary)
{
    public override void SetBonus(int bonus)
    {
        if (percent > 200)
            base.SetBonus(bonus * 3);
        else if (percent > 100)
            base.SetBonus(bonus * 2);
        else
            base.SetBonus(bonus);
    }
}