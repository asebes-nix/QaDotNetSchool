using Nix.Oop.Final;

Company company = new([
    new Employee("Ivan Nevpyisai", 50000),
    new SalesPerson("Petro Dovidyshchko", 40000, 150),
    new Manager("Mykola Perevertai", 60000, 120)
]);

company.GiveEverybodyBonus(500);
company.GetNameSalary();
Console.WriteLine($"Total: {company.TotalToPay()}");

Console.ReadKey();