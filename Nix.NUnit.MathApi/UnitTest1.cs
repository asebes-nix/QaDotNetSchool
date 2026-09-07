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

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            _httpClient.Dispose();
        }
    }
}