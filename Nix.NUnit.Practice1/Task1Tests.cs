using Nix.NUnit.Practice1;
using System;

namespace Nix.NUnit.Practice1;

public class Task1Tests
{
    [Test]
    public async Task CheckPaths_ResultIsNotEmpty()
    {
        var paths = await Task1.GetAllPaths();
        var result = await Task1.CheckPaths(paths!);

        Assert.That(result, Is.Not.Empty);
    }

    [Test]
    public async Task CheckPaths_ContainsOnlyNon200StatusCodes()
    {
        var paths = await Task1.GetAllPaths();
        var result = await Task1.CheckPaths(paths!);

        Assert.That(result.Values, Is.All.Not.EqualTo(200));
    }
}