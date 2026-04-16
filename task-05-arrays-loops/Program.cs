int[,] matrix = new int[8, 8];
Random random = new(); 

for (int i = 0; i < 8; i++)
{
    for (int j = 0; j < 8; j++)
    {
        matrix[i, j] = random.Next(-50, 51);
    }
}

List<int> filteredElements = []; 

foreach (int current in matrix)
{
    if (current > 0 && current % 2 != 0)
    {
        filteredElements.Add(current);
    }
}

foreach (int[] group in filteredElements.Chunk(5))
{
    Console.WriteLine(string.Join("\t", group));
}

Console.WriteLine("\n--- Results ---");
Console.WriteLine($"Total count of elements: {filteredElements.Count}");

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