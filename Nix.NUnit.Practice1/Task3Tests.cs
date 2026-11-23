namespace Nix.NUnit.Practice1;

public class Task3Tests
{
    [Test]
    public async Task GetAllLanguages_ReturnsUniqueLanguages()
    {
        var task3 = new Task3();
        var languages = await task3.GetAllLanguages();

        Assert.That(languages, Is.Unique);
    }

    [Test]
    public async Task GetPopulationByLanguage_ReturnsPositiveValues()
    {
        var task3 = new Task3();
        var result = await task3.GetPopulationByLanguage();

        Assert.Multiple(() =>
        {
            Assert.That(result, Is.Not.Empty);
            Assert.That(result.Values, Is.All.GreaterThan(0));
        });
    }
}