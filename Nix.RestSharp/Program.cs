using Nix.RestSharp;
using Nix.RestSharp.Models;
using System.Text.Json;

var httpBinApi = new HttpBinApi();
// Task 1
try
{
    var spec = await Task1.GetAllPaths(httpBinApi);
    var results = Task1.CheckPaths(spec!);
    foreach (var result in results)
        Console.WriteLine($"{result.Key} - {result.Value}");
}
catch (Exception ex)
{
    Console.WriteLine($"Task 1 failed: {ex.Message}");
}

//Task 2
try
{
    var body = new FormData
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

    var (form, responseHeaders) = await Task2.SendPostRequest(httpBinApi, body, requestHeaders);
    Console.WriteLine("=== FORM ===");
    Console.WriteLine(JsonSerializer.Serialize(form, new JsonSerializerOptions(JsonSerializerDefaults.Web)));
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
var countries = await countriesApi.GetCountries();
var languages = countries
    .Where(c => c.Languages != null)
    .SelectMany(c => c.Languages!)
    .Select(l => l.Iso639_2)
    .OfType<string>()
    .Distinct()
    .ToList();
Console.WriteLine("=== UNIQUE LANGUAGES ===");
Console.WriteLine($"Unique languages: {languages.Count}");
foreach (var lang in languages)
    Console.WriteLine(lang);

// Task 3.2
var populationByLanguage = new Dictionary<string, long>();
foreach (var lang in languages)
{
    var langCountries = await countriesApi.GetCountriesByLanguage(lang);
    populationByLanguage[lang] = langCountries.Sum(c => c.Population);
}
Console.WriteLine("=== POPULATION BY LANGUAGE ===");
foreach (var kv in populationByLanguage)
    Console.WriteLine($"{kv.Key}: {kv.Value}");

Console.ReadKey();