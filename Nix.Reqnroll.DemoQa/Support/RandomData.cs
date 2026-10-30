namespace Nix.Reqnroll.DemoQa.Support;

internal static class RandomData
{
    private static readonly string[] FirstNames = ["Taras", "Oksana", "Bohdan", "Solomiia", "Mykola", "Olena", "Dmytro"];
    private static readonly string[] LastNames = ["Bugenko", "Testenko", "Regresiuk", "Hotfixchuk", "Debuhovych", "Flakovskyi", "Asertenko"];
    private static readonly string[] Cities = ["Kyiv", "Lviv", "Kharkiv", "Odesa"];
    private static readonly string[] Streets = ["Bahova", "Testova", "Rehresiina", "Releasna", "Sprintova"];
    private static readonly string[] MobilePrefixes = ["050", "063", "067", "093"];

    public static string FirstName() => Pick(FirstNames);

    public static string LastName() => Pick(LastNames);

    public static string Email(string firstName, string lastName) =>
        $"{firstName}.{lastName}{Random.Shared.Next(100, 1000)}@example.com".ToLowerInvariant();

    public static string Mobile() => $"{Pick(MobilePrefixes)}{Random.Shared.Next(1_000_000, 10_000_000)}";

    public static string Address() => $"{Pick(Cities)}, {Pick(Streets)} vul. {Random.Shared.Next(1, 500)}";

    private static string Pick(string[] values) => values[Random.Shared.Next(values.Length)];
}