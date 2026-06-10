namespace NIX.OOP.ExtensionMethods;

public sealed class Worker(int rate, int totalHour)
{
    public int Rate = rate;
    public int TotalHour = totalHour;

    public double CalculateSallary()
    {
        return Rate * TotalHour * 1.5;
    }
}