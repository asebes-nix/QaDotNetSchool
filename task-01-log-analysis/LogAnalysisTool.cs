using System.Text.RegularExpressions;

namespace Nix.Exceptions;

public class LogAnalyzer
{
    public static double AnalyzeLogs(string inputPath)
    {
        int errorCount = 0;
        int totalCount = 0;

        try
        {
            string[] logLines = File.ReadAllLines(inputPath);
            totalCount = logLines.Length;

            using (StreamWriter writer = new StreamWriter("errors.log"))
            {
                foreach (string line in logLines)
                {
                    if (Regex.IsMatch(line, "error", RegexOptions.IgnoreCase))
                    {
                        try
                        {
                            if (Regex.IsMatch(line, "CRITICAL ERROR", RegexOptions.IgnoreCase))
                            {
                                throw new CriticalErrorException(line);
                            }
                        }
                        catch (CriticalErrorException ex)
                        {
                            Console.WriteLine($"CRITICAL ERROR found: {ex.Message}");
                        }
                        writer.WriteLine(line);
                        errorCount++;
                    }
                }
            }

            if (errorCount == 0)
            {
                throw new DivideByZeroException("No errors found in the logs.");
            }
        }
        catch (CriticalErrorException ex)
        {
            Console.WriteLine($"CRITICAL ERROR found: {ex.Message}");
        }
        catch (DivideByZeroException ex)
        {
            Console.WriteLine($"Division error: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
        finally
        {
            Console.WriteLine("Log analysis completd.");
        }
        return (double)totalCount / errorCount;
    }
}
