namespace Nix.NUnit.Practice1;

public class Task1Tests
{
    [Test]
    public async Task CheckPaths_ReturnsPathsWithNon200Responses()
    {
        var task1 = new Task1();
        var spec = await task1.GetAllPaths();
        Assert.That(spec, Is.Not.Null);

        var result = Task1.CheckPaths(spec);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(result, Is.Not.Null.And.Not.Empty);
            Assert.That(result.Values, Is.All.Not.Empty);
            Assert.That(result.Values, Has.None.Contains("200"));
        }
    }
}