using Nix.RestSharp;
using RestSharp;
using System.Text.Json;

// Task 1
var paths = await Task1.GetAllPaths();
var results = await Task1.CheckPaths(paths);

foreach (var result in results)
{
    Console.WriteLine($"https://nghttp2.org/httpbin{result.Key} - {result.Value}");
}


//Task 2
var body = new Dictionary<string, string>
{
    { "custname", "András" },
    { "custtel", "123456" },
    { "custemail", "a@a.com" },
    { "size", "small" },
    { "topping", "bacon" },
    { "delivery", "17:00" },
    { "comments", "test" }
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

// Task 3.1
var languages = await Task3.GetAllLanguages();
Console.WriteLine($"Unique languages: {languages.Count}");
foreach (var lang in languages)
    Console.WriteLine(lang);

// Task 3.2
var populationByLanguage = await Task3.GetPopulationByLanguage();
foreach (var kv in populationByLanguage)
    Console.WriteLine($"{kv.Key}: {kv.Value}");
Console.ReadKey();