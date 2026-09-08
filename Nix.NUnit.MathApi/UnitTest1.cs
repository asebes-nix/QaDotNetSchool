using System.Net.Http;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Nix.NUnit.MathApi
{
    public class Tests
    {
        private HttpClient _httpClient;
        private int _roundingIndex;
        private static readonly System.Text.Json.JsonSerializerOptions _jsonOptions = new() { PropertyNameCaseInsensitive = true };

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "Learning Automation");

            string roundingIndexString = TestContext.Parameters.Get("RoundingIndex", "2");
            _roundingIndex = int.Parse(roundingIndexString);
        }

        private async Task<string> PostMathExpressionAsync(string expr)
        {
            var requestBody = new { expr };
            string json = System.Text.Json.JsonSerializer.Serialize(requestBody);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PostAsync("http://api.mathjs.org/v4/", content);
            string responseBody = await response.Content.ReadAsStringAsync();

            MathApiResponse? parsed = System.Text.Json.JsonSerializer.Deserialize<MathApiResponse>(responseBody, _jsonOptions);

            Assert.That(parsed, Is.Not.Null);
            return parsed!.Result!;
        }

        private async Task<string> GetMathExpressionAsync(string expr)
        {
            string url = $"http://api.mathjs.org/v4/?expr={Uri.EscapeDataString(expr)}";
            string result = await _httpClient.GetStringAsync(url);
            return result.Trim();
        }

        [TestCase("2+3", "5")]
        [TestCase("5+3", "8")]
        [Category("Addition")]
        public async Task Addition_ReturnsExpectedResult(string expr, string expected)
        {
            string result = await PostMathExpressionAsync(expr);
            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase("11-3", "8")]
        [TestCase("25-17", "8")]
        [Category("Subtraction")]
        public async Task Subtraction_ReturnsExpectedResult(string expr, string expected)
        {
            string result = await PostMathExpressionAsync(expr);
            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase("4*2", "8")]
        [TestCase("8*1", "8")]
        [Category("Multiplication")]
        public async Task Multiplication_ReturnsExpectedResult(string expr, string expected)
        {
            string result = await PostMathExpressionAsync(expr);
            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase("25/3", 8.33)]
        [TestCase("33/4", 8.25)]
        [Category("Division")]
        public async Task Division_ReturnsExpectedResult(string expr, double expected)
        {
            string result = await PostMathExpressionAsync(expr);
            double actual = Math.Round(double.Parse(result), _roundingIndex);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase("sqrt(64)", "8")]
        [TestCase("sqrt(16)", "4")]
        [Category("SquareRoot")]
        public async Task SquareRoot_ReturnsExpectedResult(string expr, string expected)
        {
            string result = await GetMathExpressionAsync(expr);
            Assert.That(result, Is.EqualTo(expected));
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            _httpClient.Dispose();
        }
    }

    public class MathApiResponse
    {
        public string? Result { get; set; }
        public string? Error { get; set; }
    }
}