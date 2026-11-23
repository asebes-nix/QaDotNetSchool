using Nix.NUnit.Practice1.Models;

namespace Nix.NUnit.Practice1;

public class Task2Tests
{
    [Test]
    public async Task SendPostRequest_FormMatchesAndUserAgentIsSet()
    {
        var form = new PostFormRequest
        {
            CustomerName = "Andras",
            CustomerTel = "06301234567",
            CustomerEmail = "andras@test.com",
            Size = "large",
            Toppings = ["cheese", "mushroom"],
            Delivery = "12:00",
            Comments = "extra crispy"
        };
        var task2 = new Task2();
        var result = await task2.SendPostRequest(form, []);

        Assert.Multiple(() =>
        {
            Assert.That(result.form, Is.EqualTo(form));
            Assert.That(result.headers["User-Agent"], Does.Contain("Learning Automation"));
        });
    }
}