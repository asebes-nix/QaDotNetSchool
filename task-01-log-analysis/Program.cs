using Nix.Exceptions;

double ratio = LogAnalyzer.AnalyzeLogs("testLogs.log");
Console.WriteLine("─────────────────────────────");
Console.WriteLine($"Total/Error ratio: {ratio}");
Console.WriteLine("─────────────────────────────");

Console.ReadKey();