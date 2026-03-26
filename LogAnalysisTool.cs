using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;

string inputPath = "testLogs.log";
string outputPath = "errors.log";

if (File.Exists(inputPath))
{
    Console.WriteLine($"[INFO]: Starting analysis on {inputPath}...");
    LogProcessor processor = new LogProcessor();
    double resultRatio = processor.ProcessLogs(inputPath, outputPath);

    Console.WriteLine("**************************************************");
    Console.WriteLine($"Log Analysis Finished. Ratio: {resultRatio:F2}");
    Console.WriteLine("**************************************************");
}
else
{
    Console.WriteLine($"[ERROR]: Input file '{inputPath}' not found!");
}

Console.WriteLine("\nPress any key to exit...");
Console.ReadKey();


public class CriticalErrorException : Exception
{
    public CriticalErrorException(string message) : base(message) { }
}

public class LogProcessor
{
    public double ProcessLogs(string input, string output)
    {
        int totalLines = 0;
        int errorCount = 0;
        List<string> errorLines = new List<string>();
        string errorPattern = @"(?i)error";

        try
        {
            string[] allLines = File.ReadAllLines(input);
            totalLines = allLines.Length;

            foreach (string line in allLines)
            {
                if (Regex.IsMatch(line, errorPattern))
                {
                    errorCount++;
                    errorLines.Add(line);

                    if (line.Contains("CRITICAL ERROR"))
                    {
                        try
                        {
                            throw new CriticalErrorException(line);
                        }
                        catch (CriticalErrorException ex)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"[CRITICAL ALERT]: {ex.Message}");
                            Console.ResetColor();
                        }
                    }
                }
            }

            File.WriteAllLines(output, errorLines);

            if (errorCount == 0)
            {
                throw new DivideByZeroException("No error records found.");
            }

            return (double)totalLines / errorCount;
        }
        catch (DivideByZeroException ex)
        {
            Console.WriteLine($"Math Error: {ex.Message}");
            return 0; // Return 0 if we cn't calculate
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            return 0; // Return 0 for any other erors
        }
        finally
        {
            Console.WriteLine("[System]: Processing attempt finished.");
        }

        return 0;
    }
}