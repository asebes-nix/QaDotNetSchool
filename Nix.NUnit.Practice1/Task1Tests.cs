using Nix.NUnit.Practice1.Models;

namespace Nix.NUnit.Practice1;

public class Task1Tests
{
    private Dictionary<string, string>? _result;

    [Test]
    public async Task CheckPaths_ReturnsPathsWithNon200Responses()
    {
        var task1 = new Task1();
        var spec = await task1.GetAllPaths();
        _result = Task1.CheckPaths(spec!);

        Assert.Multiple(() =>
        {
            Assert.That(_result, Is.Not.Null);
            Assert.That(_result, Is.Not.Empty);
            Assert.That(_result.Values, Is.All.Not.Empty);
        });
    }
}