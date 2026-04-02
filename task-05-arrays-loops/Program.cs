using System.Collections.Generic;
using System.Linq;

// --- MAIN LOGIC (Top-level statements) ---

int[,] matrix = new int[8, 8];
Random random = new Random();

// 1. Fill the array with random numbers (-50 to 50)
for (int i = 0; i < 8; i++)
{
    for (int j = 0; j < 8; j++)
    {
        matrix[i, j] = random.Next(-50, 51);
    }
}

// 2. Filter elements: must be ODD and POSITIVE
// Using List directly without pre-declaring empty variables outside
List<int> filteredElements = new List<int>();

foreach (int current in matrix)
{
    if (current > 0 && current % 2 != 0)
    {
        filteredElements.Add(current);
    }
}

// 3. Sort the collected elements
filteredElements.Sort();

Console.WriteLine("Filtered elements (Odd, Positive, Sorted):");

// 4. Display elements (max 5 per line)
for (int i = 0; i < filteredElements.Count; i++)
{
    Console.Write($"{filteredElements[i]}\t");

    if ((i + 1) % 5 == 0)
    {
        Console.WriteLine();
    }
}

// 5. Final Statistics
Console.WriteLine("\n\n--- Results ---");
Console.WriteLine($"Total count of elements: {filteredElements.Count}");

// Using LINQ to handle empty list safety and direct assignment
if (filteredElements.Any())
{
    // Since it is already sorted, Max() or Last() is fine.
    // Max() is more descriptive of what we want.
    int maxValue = filteredElements.Max();
    Console.WriteLine($"Maximum value: {maxValue}");
}
else
{
    Console.WriteLine("No elements matched the criteria.");
}

Console.WriteLine("\nPress any key to exit...");
Console.ReadKey();