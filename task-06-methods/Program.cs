int[] firstArray = new int[5];
int[] secondArray = new int[5];

Console.WriteLine("--- Initialize First Array ---");
InitializeArray(firstArray);

Console.WriteLine("\n--- Initialize Second Array ---");
InitializeArray(secondArray);

Console.WriteLine("\nFirst Array (Original):");
PrintArray(firstArray);

Console.WriteLine("Second Array (Original):");
PrintArray(secondArray);

SortDescending(firstArray);
SortDescending(secondArray);

Console.WriteLine("\nFirst Array (Sorted Descending):");
PrintArray(firstArray);

Console.WriteLine("Second Array (Sorted Descending):");
PrintArray(secondArray);

// Renamed from AreArraysEquivalent to AreArraysEqual as requested
if (AreArraysEqual(firstArray, secondArray))
{
    Console.WriteLine("\nResult: The arrays are equal.");
}
else
{
    Console.WriteLine("\nResult: The arrays are NOT equal.");
}

Console.WriteLine("\nPress any key to exit...");
Console.ReadKey();

void InitializeArray(int[] array)
{
    for (int i = 0; i < array.Length; i++)
    {
        while (true)
        {
            Console.Write($"Enter element {i + 1}: ");
            string? input = Console.ReadLine();

            if (int.TryParse(input, out int value))
            {
                array[i] = value;
                break;
            }

            Console.WriteLine("Invalid input. Please enter an integer.");
        }
    }
}

void PrintArray(int[] array)
{
    // Replaced manual loop with string.Join() to simplify and avoid trailing tabs
    Console.WriteLine(string.Join("\t", array));
}

void SortDescending(int[] array)
{
    int n = array.Length;
    for (int i = 0; i < n - 1; i++)
    {
        for (int j = 0; j < n - i - 1; j++)
        {
            if (array[j] < array[j + 1])
            {
                (array[j], array[j + 1]) = (array[j + 1], array[j]);
            }
        }
    }
}

// Renamed method to better reflect index-by-index comparison
bool AreArraysEqual(int[] array1, int[] array2)
{
    if (array1.Length != array2.Length) return false;

    for (int i = 0; i < array1.Length; i++)
    {
        if (array1[i] != array2[i]) return false;
    }
    return true;
}