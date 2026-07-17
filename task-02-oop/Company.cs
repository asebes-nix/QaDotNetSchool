namespace Nix.Oop.Final;

public class Company(Employee[] employees)
{
    private readonly Employee[] _employees = employees;

    public void GiveEverybodyBonus(int companyBonus)
    {
        foreach (var employee in _employees)
        {
            employee.SetBonus(companyBonus);
        }
    }

    public int TotalToPay()
    {
        return _employees.Sum(e => e.ToPay());
    }

    public void GetNameSalary()
    {
        foreach (var employee in _employees)
        {
            Console.WriteLine($"Name: {employee.Name}, Salary: {employee.ToPay()}");
        }
    }
}

