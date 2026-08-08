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
            using (StreamReader reader = new(inputPath))
            using (StreamWriter writer = new("errors.log"))
            {
                string? line;
                while ((line = reader.ReadLine()) != null)
                {
                    totalCount++;

                    if (Regex.IsMatch(line, "^\\d{2}:\\d{2}:\\d{2} E:"))
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
        catch (DivideByZeroException ex)
        {
            Console.WriteLine($"Division error: {ex.Message}");
            return 0;
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
