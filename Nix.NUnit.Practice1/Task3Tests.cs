namespace Nix.NUnit.Practice1;

public class Task3Tests
{
    private Dictionary<string, long> _result = null!;

    [SetUp]
    public async Task Setup()
    {
        var task3 = new Task3();
        _result = await task3.GetPopulationByLanguage();
    }

    [Test]
    public void GetPopulationByLanguage_ResultIsNotEmpty()
    {
        Assert.That(_result, Is.Not.Empty);
    }

    [Test]
    public void GetPopulationByLanguage_AllPopulationsArePositive()
    {
        Assert.That(_result.Values, Is.All.GreaterThan(0));
    }
}