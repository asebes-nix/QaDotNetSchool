namespace Nix.Oop.Final;

public class SalesPerson : Employee
{
    private int _percent;

    public SalesPerson(string name, int salary, int percent) : base(name, salary)
    {
        _percent = percent;
    }
    public override void SetBonus(int bonus)
    {
        if (_percent > 200)
            base.SetBonus(bonus * 3);
        else if (_percent > 100)
            base.SetBonus(bonus * 2);
        else
            base.SetBonus(bonus);
    }
}