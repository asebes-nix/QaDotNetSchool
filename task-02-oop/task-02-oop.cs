using System;
using System.Collections.Generic;
using System.Linq;

// --- MAIN RUNTIME LOGIC (Top-level Statements) ---
// Initialize a diverse staff list to test different logic paths
Employee[] staff = new Employee[]
{
    new SalesPerson("Smith", 2000, 150),   // Over 100% fulfillment (2x bonus)
    new Manager("Johnson", 3000, 120),    // Over 100 clients (+500 bonus)
    new Employee("Brown", 1500),          // Standard Employee
    new SalesPerson("Elon Ma", 1, 3000),  // Extreme Case: 3000% fulfillment
    new Manager("Lazy Larry", 5000, 0),   // Edge Case: 0 clients
    new Employee("Casper", 0)             // Edge Case: 0 salary
};

Company myCompany = new Company(staff);

// Simulation: Standard Company Bonus
Console.WriteLine("--- Payroll Report: Standard Bonus ($500) ---");
myCompany.GiveEverybodyBonus(500);
myCompany.ShowAllEmployeesInfo();

Console.WriteLine("------------------------------------------------------------");
Console.WriteLine($"Total Payroll Expenditure: {myCompany.TotalToPay():C}");
Console.WriteLine("------------------------------------------------------------\n");

Console.WriteLine("Press any key to exit...");
Console.ReadKey();


// --- CLASSES (Encapsulation, Inheritance, Polymorphism) ---

public class Employee
{
    public string Name { get; set; }
    public int BaseSalary { get; set; }
    protected int Bonus { get; set; }

    public Employee(string name, int baseSalary)
    {
        Name = name;
        BaseSalary = baseSalary;
    }

    // Virtual method to allow overriding in child classes
    public virtual void SetBonus(int companyBonus)
    {
        Bonus = companyBonus;
    }

    public virtual int ToPay()
    {
        return BaseSalary + Bonus;
    }
}

// Inheritance: Manager is an Employee
public class Manager : Employee
{
    public int ClientCount { get; set; }

    public Manager(string name, int baseSalary, int clientCount) : base(name, baseSalary)
    {
        ClientCount = clientCount;
    }

    // Polymorphism: Specialized bonus logic for Managers
    public override void SetBonus(int companyBonus)
    {
        // Managers get an extra $500 if they have more than 100 clients
        int extra = (ClientCount > 100) ? 500 : 0;
        Bonus = companyBonus + extra;
    }
}

// Inheritance: SalesPerson is an Employee
public class SalesPerson : Employee
{
    public double SalesTargetPercent { get; set; }

    public SalesPerson(string name, int baseSalary, double salesTargetPercent) : base(name, baseSalary)
    {
        SalesTargetPercent = salesTargetPercent;
    }

    // Polymorphism: Specialized bonus logic for Salespeople
    public override void SetBonus(int companyBonus)
    {
        // Salespeople get double bonus if they exceed 100% of their target
        double multiplier = (SalesTargetPercent >= 100) ? 2.0 : 1.0;
        Bonus = (int)(companyBonus * multiplier);
    }
}

public class Company
{
    private Employee[] employees;

    public Company(Employee[] employees) => this.employees = employees;

    // Polymorphism in action: Calling SetBonus on the Employee reference
    // executes the child class override automatically.
    public void GiveEverybodyBonus(int companyBonus)
    {
        foreach (var emp in employees)
            emp.SetBonus(companyBonus);
    }

    public int TotalToPay()
    {
        int total = 0;
        foreach (var emp in employees)
            total += emp.ToPay();
        return total;
    }

    // Cleaned output using GetType().Name to show roles dynamically
    public void ShowAllEmployeesInfo()
    {
        foreach (var emp in employees)
        {
            string role = emp.GetType().Name;
            // Alignment syntax: {value, -padding} for clean columns
            Console.WriteLine($"Role: {role,-12} | Name: {emp.Name,-12} | Total: {emp.ToPay(),10:C}");
        }
    }
}