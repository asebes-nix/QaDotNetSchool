using System.Globalization;
using RestSharp;

namespace Nix.NUnit.MathApi;

public class Tests
{
    private MathApiService _service = null!;
    private int _roundingIndex;

    [OneTimeSetUp]
    public void OneTimeSetup()
    {
        _service = new MathApiService();

        string roundingIndexString = TestContext.Parameters.Get("RoundingIndex", "2");
        _roundingIndex = int.Parse(roundingIndexString);
    }

    [TestCase("2+3", "5")]
    [TestCase("0+0", "0")]
    [TestCase("-5+3", "-2")]
    [TestCase("1.5+2.5", "4")]
    [Category("Addition")]
    public async Task Addition_ReturnsExpectedResult(string expr, string expected)
    {
        string result = await _service.PostExpressionAsync(expr);
        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase("11-3", "8")]
    [TestCase("0-0", "0")]
    [TestCase("-5-3", "-8")]
    [TestCase("10.5-0.5", "10")]
    [Category("Subtraction")]
    public async Task Subtraction_ReturnsExpectedResult(string expr, string expected)
    {
        string result = await _service.PostExpressionAsync(expr);
        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase("4*2", "8")]
    [TestCase("0*999", "0")]
    [TestCase("-3*4", "-12")]
    [TestCase("1.5*2", "3")]
    [Category("Multiplication")]
    public async Task Multiplication_ReturnsExpectedResult(string expr, string expected)
    {
        string result = await _service.PostExpressionAsync(expr);
        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase("25/3", 8.33)]
    [TestCase("1/4", 0.25)]
    [TestCase("-10/4", -2.5)]
    [TestCase("1/3", 0.33)]
    [Category("Division")]
    public async Task Division_ReturnsExpectedResult(string expr, double expected)
    {
        string result = await _service.PostExpressionAsync(expr);
        double actual = Math.Round(
            double.Parse(result, CultureInfo.InvariantCulture),
            _roundingIndex);
        double expectedRounded = Math.Round(expected, _roundingIndex);
        Assert.That(actual, Is.EqualTo(expectedRounded));
    }

    [TestCase("sqrt(64)", "8")]
    [TestCase("sqrt(0)", "0")]
    [TestCase("sqrt(2)", "1.4142135623730951")]
    [Category("SquareRoot")]
    public async Task SquareRoot_ReturnsExpectedResult(string expr, string expected)
    {
        string result = await _service.GetExpressionAsync(expr);
        Assert.That(result, Is.EqualTo(expected));
    }

    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        _service = null!;
    }
}