using System.Collections.Generic;
using System.Linq;

// --- TOP-LEVEL STATEMENTS ---

// 1. Initialize 8x8 array and random generator
int[,] matrix = new int[8, 8];
Random random = new Random();
List<int> filteredElements = new List<int>();

// 2. Fill the array with random numbers (-50 to 50)
for (int i = 0; i < 8; i++)
{
    for (int j = 0; j < 8; j++)
    {
        matrix[i, j] = random.Next(-50, 51);
    }
}

// 3. Filter elements: must be ODD and POSITIVE
foreach (int current in matrix)
{
    // Using Math.Abs for the modulo is a safe habit for odd checks, 
    // though current > 0 already ensures positive numbers.
    if (current > 0 && current % 2 != 0)
    {
        filteredElements.Add(current);
    }
}

// 4. SORT the collected elements in ascending order
filteredElements.Sort();

Console.WriteLine("Filtered elements (Odd, Positive, Sorted):");

// 5. Display elements (max 5 per line)
for (int i = 0; i < filteredElements.Count; i++)
{
    Console.Write($"{filteredElements[i]}\t");

    // Move to next line after every 5th element
    if ((i + 1) % 5 == 0)
    {
        Console.WriteLine();
    }
}

// 6. Final Statistics
Console.WriteLine("\n\n--- Results ---");
Console.WriteLine($"Total count of elements: {filteredElements.Count}");

if (filteredElements.Count > 0)
{
    // Simplified: Use the LINQ Max() or the last element of the sorted list
    int max = filteredElements.Last();
    Console.WriteLine($"Maximum value: {max}");
}
else
{
    Console.WriteLine("No elements matched the criteria.");
}

Console.WriteLine("\nPress any key to exit...");
Console.ReadKey();