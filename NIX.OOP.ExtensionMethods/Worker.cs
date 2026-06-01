namespace NIX.OOP.ExtensionMethods;

public sealed class Worker
{
    public int Rate;
    public int TotalHour;

    public Worker(int rate, int totalHour)
    {
        Rate = rate;
        TotalHour = totalHour;
    }

    public double CalculateSallary()
    {
        return Rate * TotalHour * 1.5; //1.5 - coefficient
    }
}