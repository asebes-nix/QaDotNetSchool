using Nix.NUnit.Practice1.Models;

namespace Nix.NUnit.Practice1;

public class Task2Tests
{
    [Test]
    public async Task SendPostRequest_ReturnsSentFormAndJsonContentType()
    {
        var form = new FormData
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

        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.form, Is.EqualTo(form).UsingPropertiesComparer());
            Assert.That(result.headers["Content-Type"], Does.Contain("application/json"));
        }
    }
}