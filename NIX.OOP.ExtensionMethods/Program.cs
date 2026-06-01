using NIX.OOP.ExtensionMethods;

Worker worker = new Worker(51, 201);

if (worker.Rate < 50 && worker.TotalHour > 200)
{
    Console.WriteLine(worker.CalculateSallaryWithBonus());
}
else
{
    Console.WriteLine(worker.CalculateSallary());
}
Console.ReadKey();