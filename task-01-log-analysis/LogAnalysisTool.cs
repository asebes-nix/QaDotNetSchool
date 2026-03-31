using System;
using System.IO;

// --- MENTOR-FRIENDLY LOG ANALYSIS ---
string inputPath = "testLogs.txt";
string outputPath = "errors.log";

// 1. Create a sample log file if it's missing
if (!File.Exists(inputPath))
{
    File.WriteAllLines(inputPath, new[] {
        "[INFO] App started",
        "[ERROR] Database timeout",
        "[WARNING] High CPU usage",
        "[ERROR] Null reference exception"
    });
}

Console.WriteLine($"--- Analyzing: {inputPath} ---");

// 2. Simple logic using built-in methods
try
{
    string[] logs = File.ReadAllLines(inputPath);
    int errorCount = 0;

    using (StreamWriter writer = new StreamWriter(outputPath))
    {
        foreach (string line in logs)
        {
            if (line.Contains("[ERROR]"))
            {
                Console.WriteLine($"Found: {line}");
                writer.WriteLine(line);
                errorCount++;
            }
        }
    }

    Console.WriteLine("\n-----------------------------------------");
    Console.WriteLine($"Analysis finished. Errors saved: {errorCount}");
    Console.WriteLine("-----------------------------------------");
}
catch (Exception ex)
{
    Console.WriteLine($"An error occurred: {ex.Message}");
}

Console.WriteLine("\nPress any key to exit...");
Console.ReadKey();