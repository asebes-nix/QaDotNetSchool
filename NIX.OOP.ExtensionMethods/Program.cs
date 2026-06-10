using NIX.OOP.ExtensionMethods;

Worker worker = new Worker(49, 199);

if (worker.Rate < 50 && worker.TotalHour > 200)
{
    Console.WriteLine(worker.CalculateSallaryWithBonus());
}
else
{
    Console.WriteLine(worker.CalculateSallary());
}
Console.ReadKey();