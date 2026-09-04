using NUnit.Framework;

namespace Nix.NUnit.Practice1;

public class Task1Tests
{
    [Test]
    public async Task CheckPaths_ResultIsNotEmpty()
    {
        var paths = await Task1.GetAllPaths();
        var result = await Task1.CheckPaths(paths);

        Assert.That(result, Is.Not.Empty);
    }

    [Test]
    public async Task CheckPaths_ContainsOnlyNon200StatusCodes()
    {
        var paths = await Task1.GetAllPaths();
        var result = await Task1.CheckPaths(paths);

        Assert.That(result.Values, Is.All.Not.EqualTo(200));
    }
}

public class Task2Tests
{
    [Test]
    public async Task SendPostRequest_FormIsNotEmpty()
    {
        var result = await Task2.SendPostRequest(
            new Dictionary<string, string> { { "name", "Andr?s" } },
            new Dictionary<string, string>());

        Assert.That(result.form, Is.Not.Empty);
    }

    [Test]
    public async Task SendPostRequest_HeadersContainUserAgent()
    {
        var result = await Task2.SendPostRequest(
            new Dictionary<string, string> { { "name", "Andr?s" } },
            new Dictionary<string, string>());

        Assert.That(result.headers.ContainsKey("User-Agent"), Is.True);
    }

    [Test]
    public async Task SendPostRequest_UserAgentIsLearningAutomation()
    {
        var result = await Task2.SendPostRequest(
            new Dictionary<string, string> { { "name", "Andr?s" } },
            new Dictionary<string, string>());

        Assert.That(result.headers["User-Agent"], Does.Contain("Learning Automation"));
    }
}

public class Task3Tests
{
    [Test]
    public async Task GetPopulationByLanguage_ResultIsNotEmpty()
    {
        var languages = await Task3.GetAllLanguages();
        var result = await Task3.GetPopulationByLanguage(languages);

        Assert.That(result, Is.Not.Empty);
    }

    [Test]
    public async Task GetPopulationByLanguage_AllPopulationsArePositive()
    {
        var languages = await Task3.GetAllLanguages();
        var result = await Task3.GetPopulationByLanguage(languages);

        Assert.That(result.Values, Is.All.GreaterThan(0));
    }
}