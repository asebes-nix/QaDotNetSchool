using System.Net.Http;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Nix.NUnit.MathApi
{
    public class Tests
    {
        private HttpClient _httpClient;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "Learning Automation");
        }

        [Test]
        [Category("SquareRoot")]
        public async Task Sqrt_Of16_Returns4()
        {
            string url = "http://api.mathjs.org/v4/?expr=sqrt(16)";

            string result = await _httpClient.GetStringAsync(url);

            Assert.That(result.Trim(), Is.EqualTo("4"));
        }

        [Test]
        [Category("Addition")]
        public async Task Add_2Plus3_Returns5()
        {
            var requestBody = new { expr = "2+3" };
            string json = System.Text.Json.JsonSerializer.Serialize(requestBody);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PostAsync("http://api.mathjs.org/v4/", content);
            string responseBody = await response.Content.ReadAsStringAsync();

            var options = new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            MathApiResponse? parsed = System.Text.Json.JsonSerializer.Deserialize<MathApiResponse>(responseBody, options);

            Assert.That(parsed, Is.Not.Null);
            Assert.That(parsed!.Result, Is.EqualTo("5"));
        }

        [Test]
        [Category("Subtraction")]
        public async Task Subtract_10Minus2_Returns8()
        {
            var requestBody = new { expr = "10-2" };
            string json = System.Text.Json.JsonSerializer.Serialize(requestBody);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PostAsync("http://api.mathjs.org/v4/", content);
            string responseBody = await response.Content.ReadAsStringAsync();

            var options = new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            MathApiResponse? parsed = System.Text.Json.JsonSerializer.Deserialize<MathApiResponse>(responseBody, options);

            Assert.That(parsed, Is.Not.Null);
            Assert.That(parsed!.Result, Is.EqualTo("8"));
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