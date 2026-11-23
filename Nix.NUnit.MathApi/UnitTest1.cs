using System.Globalization;
using RestSharp;

namespace Nix.NUnit.MathApi;

public class Tests
{
    private MathApiService _service;
    private int _roundingIndex;

    [OneTimeSetUp]
    public void OneTimeSetup()
    {
        _service = new MathApiService();
        string roundingIndexString = TestContext.Parameters.Get("RoundingIndex", "2");
        _roundingIndex = int.Parse(roundingIndexString);
    }

    private double Round(string value) =>
        Math.Round(double.Parse(value, CultureInfo.InvariantCulture), _roundingIndex);

    private void AssertResult(RestResponse response, string? actual, string expected)
    {
        Assert.That(response.IsSuccessful, Is.True, $"Request failed: {response.StatusCode}");
        Assert.That(actual, Is.Not.Null);
        Assert.That(Round(actual), Is.EqualTo(Round(expected)));
    }

    [TestCase("2+3", "5")]
    [TestCase("0+0", "0")]
    [TestCase("-5+3", "-2")]
    [TestCase("1.1+2.2", "3.3")]
    [TestCase("1e3+2.5e2", "1250")]
    [Category("Addition")]
    public async Task Addition_ReturnsExpectedResult(string expr, string expected)
    {
        var response = await _service.PostExpressionAsync(expr);
        AssertResult(response, response.Data?.Result, expected);
    }

    [TestCase("11-3", "8")]
    [TestCase("0-0", "0")]
    [TestCase("-5-3", "-8")]
    [TestCase("3.3-1.1", "2.2")]
    [TestCase("1e3-2.5e2", "750")]
    [Category("Subtraction")]
    public async Task Subtraction_ReturnsExpectedResult(string expr, string expected)
    {
        var response = await _service.PostExpressionAsync(expr);
        AssertResult(response, response.Data?.Result, expected);
    }

    [TestCase("4*2", "8")]
    [TestCase("0*999", "0")]
    [TestCase("-3*4", "-12")]
    [TestCase("1.25*2.25", "2.8125")]
    [TestCase("2e3*1.5e-3", "3")]
    [Category("Multiplication")]
    public async Task Multiplication_ReturnsExpectedResult(string expr, string expected)
    {
        var response = await _service.PostExpressionAsync(expr);
        AssertResult(response, response.Data?.Result, expected);
    }

    [TestCase("25/3", "8.333333333333334")]
    [TestCase("1/4", "0.25")]
    [TestCase("-10/4", "-2.5")]
    [TestCase("4.84/2.2", "2.2")]
    [TestCase("1e3/8", "125")]
    [Category("Division")]
    public async Task Division_ReturnsExpectedResult(string expr, string expected)
    {
        var response = await _service.PostExpressionAsync(expr);
        AssertResult(response, response.Data?.Result, expected);
    }

    [TestCase("sqrt(64)", "8")]
    [TestCase("sqrt(0)", "0")]
    [TestCase("sqrt(2)", "1.4142135623730951")]
    [TestCase("sqrt(1e4)", "100")]
    [Category("SquareRoot")]
    public async Task SquareRoot_ReturnsExpectedResult(string expr, string expected)
    {
        var response = await _service.GetExpressionAsync(expr);
        AssertResult(response, response.Content, expected);
    }
}