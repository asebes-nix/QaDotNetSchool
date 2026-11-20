using Nix.NUnit.Practice1.Models;

namespace Nix.NUnit.Practice1;

public class Task1Tests
{
    private Dictionary<string, int[]> _result = null!;

    [SetUp]
    public async Task Setup()
    {
        var task1 = new Task1();
        var spec = await task1.GetAllPaths();
        _result = await task1.CheckPaths(spec!);
    }

    [Test]
    public void CheckPaths_ResultIsNotEmpty()
    {
        Assert.That(_result, Is.Not.Empty);
    }

    [Test]
    public void CheckPaths_AllValuesContainNon200StatusCodes()
    {
        Assert.That(_result.Values, Is.All.Not.Empty);
        Assert.That(_result.Values.SelectMany(v => v), Is.All.Not.EqualTo(200));
    }
}