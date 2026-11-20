using Nix.NUnit.Practice1.Models;

namespace Nix.NUnit.Practice1;

public class Task2Tests
{
    private PostFormRequest _form = null!;
    private (FormData? form, Dictionary<string, string> headers) _result;

    [SetUp]
    public async Task Setup()
    {
        _form = new PostFormRequest
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
        _result = await task2.SendPostRequest(_form, []);
    }

    [Test]
    public void SendPostRequest_FormMatchesRequest()
    {
        Assert.That(_result.form?.CustomerName, Is.EqualTo(_form.CustomerName));
        Assert.That(_result.form?.CustomerTel, Is.EqualTo(_form.CustomerTel));
        Assert.That(_result.form?.CustomerEmail, Is.EqualTo(_form.CustomerEmail));
        Assert.That(_result.form?.Size, Is.EqualTo(_form.Size));
        Assert.That(_result.form?.Delivery, Is.EqualTo(_form.Delivery));
        Assert.That(_result.form?.Comments, Is.EqualTo(_form.Comments));
    }

    [Test]
    public void SendPostRequest_UserAgentContainsLearningAutomation()
    {
        Assert.That(_result.headers["User-Agent"], Does.Contain("Learning Automation"));
    }
}