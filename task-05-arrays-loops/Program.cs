// ImplicitUsings are enabled, so no manual using directives are needed

int[,] matrix = new int[8, 8];
Random random = new(); // Simplified init

for (int i = 0; i < 8; i++)
{
    for (int j = 0; j < 8; j++)
    {
        matrix[i, j] = random.Next(-50, 51);
    }
}

List<int> filteredElements = []; // Simplified init using collection expression

foreach (int current in matrix)
{
    if (current > 0 && current % 2 != 0)
    {
        filteredElements.Add(current);
    }
}

// Display elements (max 5 per line) using LINQ Chunk
foreach (int[] group in filteredElements.Chunk(5))
{
    Console.WriteLine(string.Join("\t", group));
}

Console.WriteLine("\n--- Results ---");
Console.WriteLine($"Total count of elements: {filteredElements.Count}");

// Using Count check instead of Any()
if (filteredElements.Count > 0)
{
    Console.WriteLine($"Maximum value: {filteredElements.Max()}");
}
else
{
    Console.WriteLine("No elements matched the criteria.");
}

Console.WriteLine("\nPress any key to exit...");
Console.ReadKey();