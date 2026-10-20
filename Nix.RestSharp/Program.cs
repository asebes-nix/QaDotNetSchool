using Nix.RestSharp;
using Nix.RestSharp.Models;
using RestSharp;
using System.Text.Json;

// Task 1
// Task 1
try
{
    var spec = await Task1.GetAllPaths();
    var results = await Task1.CheckPaths(spec!);
    foreach (var result in results)
        Console.WriteLine($"https://nghttp2.org/httpbin{result.Key} - {result.Value}");
}
catch (Exception ex)
{
    Console.WriteLine($"Task 1 failed: {ex.Message}");
}

//Task 2
try
{
    var body = new PostFormRequest
    {
        CustomerName = "András",
        CustomerTel = "123456",
        CustomerEmail = "a@a.com",
        Size = "small",
        Toppings = ["bacon", "cheese"],
        Delivery = "17:00",
        Comments = "test"
    };

    var requestHeaders = new Dictionary<string, string>
    {
        { "User-Agent", "Learning Automation" }
    };

    var (form, responseHeaders) = await Task2.SendPostRequest(body, requestHeaders);
    Console.WriteLine("=== FORM ===");
    foreach (var kv in form)
        Console.WriteLine($"{kv.Key}: {kv.Value}");
    Console.WriteLine("=== HEADERS ===");
    foreach (var kv in responseHeaders)
        Console.WriteLine($"{kv.Key}: {kv.Value}");
}
catch (Exception ex)
{
    Console.WriteLine($"Task 2 failed: {ex.Message}");
}

// Task 3.1
var countriesApi = new CountriesApi();
var languages = await countriesApi.GetAllLanguages();
Console.WriteLine($"Unique languages: {languages.Count}");
foreach (var lang in languages)
    Console.WriteLine(lang);

// Task 3.2
var populationByLanguage = await countriesApi.GetPopulationByLanguage();
foreach (var kv in populationByLanguage)
    Console.WriteLine($"{kv.Key}: {kv.Value}");

Console.ReadKey();