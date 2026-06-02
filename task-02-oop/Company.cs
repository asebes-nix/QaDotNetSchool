namespace Nix.Oop.Final;

public class Company
{
    private Employee[] _employees;

    public Company(Employee[] employees)
    {
        _employees = employees;
    }

    public void GiveEverybodyBonus(int companyBonus)
    {
        foreach (var employee in _employees)
        {
            employee.SetBonus(companyBonus);
        }
    }
    public int TotalToPay()
    {
        int total = 0;
        foreach (var employee in _employees)
        {
            total += employee.ToPay();
        }
        return total;
    }
    public void GetNameSalary()
    {
        foreach (var employee in _employees)
        {
            Console.WriteLine($"Name: {employee.Name}, Salary: {employee.ToPay()}");
        }
    }
}

