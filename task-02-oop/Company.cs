namespace Nix.Oop.Final;

public class Company(Employee[] employees)
{
    public void GiveEverybodyBonus(int companyBonus)
    {
        foreach (var employee in employees)
        {
            employee.SetBonus(companyBonus);
        }
    }

    public int TotalToPay()
    {
        return employees.Sum(e => e.ToPay());
    }

    public void GetNameSalary()
    {
        foreach (var employee in employees)
        {
            Console.WriteLine($"Name: {employee.Name}, Salary: {employee.ToPay()}");
        }
    }
}

