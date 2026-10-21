using Nix.NUnit.Practice1;
using Nix.NUnit.Practice1.Models;
using System;

namespace Nix.NUnit.Practice1;

public class Task2Tests
{
    private PostFormRequest _form = null!;
    private (Dictionary<string, string> form, Dictionary<string, string> headers) _result;

    [SetUp]
    public async Task Setup()
    {
        _form = new PostFormRequest
        {
            CustomerName = "András",
            CustomerTel = "06301234567",
            CustomerEmail = "andras@test.com",
            Size = "large",
            Toppings = ["cheese", "mushroom"],
            Delivery = "12:00",
            Comments = "extra crispy"
        };

        _result = await Task2.SendPostRequest(_form, new Dictionary<string, string>());
    }

    [Test]
    public void SendPostRequest_FormMatchesRequest()
    {
        var expected = new Dictionary<string, string>
        {
            { "custname", _form.CustomerName! },
            { "custtel", _form.CustomerTel! },
            { "custemail", _form.CustomerEmail! },
            { "size", _form.Size! },
            { "delivery", _form.Delivery! },
            { "comments", _form.Comments! }
        };

        Assert.That(_result.form, Is.EqualTo(expected));
    }

    [Test]
    public void SendPostRequest_UserAgentContainsLearningAutomation()
    {
        Assert.That(_result.headers["User-Agent"], Does.Contain("Learning Automation"));
    }
}

