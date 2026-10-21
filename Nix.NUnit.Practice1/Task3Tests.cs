using Nix.NUnit.Practice1;
using System;

namespace Nix.NUnit.Practice1;

public class Task3Tests
{
    [Test]
    public async Task GetPopulationByLanguage_ResultIsNotEmpty()
    {
        var result = await Task3.GetPopulationByLanguage();

        Assert.That(result, Is.Not.Empty);
    }

    [Test]
    public async Task GetPopulationByLanguage_AllPopulationsArePositive()
    {
        var result = await Task3.GetPopulationByLanguage();

        Assert.That(result.Values, Is.All.GreaterThan(0));
    }
}
