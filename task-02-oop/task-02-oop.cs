using System;



// Setup a diverse staff list to test different logic paths and edge cases
Employee[] staff = new Employee[]
{
    new SalesPerson("Smith", 2000, 150),    // Over 100% (2x bonus)
    new Manager("Johnson", 3000, 120),      // Over 100 clients (+500 bonus)
    new Employee("Brown", 1500),            // Standard Employee
    new SalesPerson("Elon Ma", 1, 3000),    // Extreme Case: 3000% fulfillment (3x bonus)
    new Manager("Lazy Larry", 5000, 0),     // Edge Case: 0 clients
    new Employee("Casper", 0),               // Edge Case: 0 Salary
    new Employee("!@#$%^&*()", 9999)         // Edge Case: Special Character Name
};

Company myCompany = new Company(staff);

// Simulation: Standard Company Bonus
Console.WriteLine("--- Payroll Report: Standard Bonus ($500) ---");
myCompany.GiveEverybodyBonus(500);
myCompany.ShowAllEmployeesInfo();

Console.WriteLine("---------------------------------------------");
Console.WriteLine($"Total Payroll Expenditure: {myCompany.TotalToPay()}");
Console.WriteLine("---------------------------------------------\n");

// Keep the console open for debugging
Console.WriteLine("Press any key to exit...");
Console.ReadKey();


// --- 2. TYPE DEFINITIONS (Classes) ---

public class Employee
{
    private string name;
    private int salary;
    private int bonus;

    // Read-only property for Name
    public string Name => name;

    // Open property for Salary (Encapsulation allows us to add validation later)
    public int Salary
    {
        get => salary;
        set => salary = value;
    }

    public Employee(string name, int salary)
    {
        this.name = name;
        this.salary = salary;
    }

    // Virtual: Allows SalesPerson and Manager to override the math
    public virtual void SetBonus(int bonus)
    {
        this.bonus = bonus;
    }

    public int ToPay() => salary + bonus;
}

public class SalesPerson : Employee
{
    private int percent;

    public SalesPerson(string name, int salary, int percent)
        : base(name, salary)
    {
        this.percent = percent;
    }

    // Override: Implements performance-based multipliers
    public override void SetBonus(int bonus)
    {
        if (percent > 200) base.SetBonus(bonus * 3);
        else if (percent > 100) base.SetBonus(bonus * 2);
        else base.SetBonus(bonus);
    }
}

public class Manager : Employee
{
    private int quantity;

    public Manager(string name, int salary, int clientAmount)
        : base(name, salary)
    {
        this.quantity = clientAmount;
    }

    // Override: Implements flat-rate client volume bonuses
    public override void SetBonus(int bonus)
    {
        if (quantity > 150) base.SetBonus(bonus + 1000);
        else if (quantity > 100) base.SetBonus(bonus + 500);
        else base.SetBonus(bonus);
    }
}

public class Company
{
    private Employee[] employees;

    public Company(Employee[] employees) => this.employees = employees;

    // Polymorphism: Calling SetBonus on the Employee reference 
    // executes the child class override automatically.
    public void GiveEverybodyBonus(int companyBonus)
    {
        foreach (var emp in employees) emp.SetBonus(companyBonus);
    }

    public int TotalToPay()
    {
        int total = 0;
        foreach (var emp in employees) total += emp.ToPay();
        return total;
    }

    // Cleaned output using GetType().Name to show roles dynamically
    public void ShowAllEmployeesInfo()
    {
        foreach (var emp in employees)
        {
            string role = emp.GetType().Name;
            // Alignment syntax: {value, -padding} for clean columns
            Console.WriteLine($"Role: {role,-12} | Name: {emp.Name,-12} | Total: {emp.ToPay(),10}");
        }
    }
}