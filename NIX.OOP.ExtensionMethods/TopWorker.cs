namespace NIX.OOP.ExtensionMethods;

public static class TopWorker
{
    public static double CalculateSallaryWithBonus(this Worker worker)
    {
        return worker.Rate * worker.TotalHour * 2.0;
    }
}
