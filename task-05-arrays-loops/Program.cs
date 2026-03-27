using System;
using System.Collections.Generic; // Required for List
using System.Linq;               // Required for Sorting

namespace Task05ArraysLoops
{
    class Program
    {
        static void Main(string[] args)
        {
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
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    int current = matrix[i, j];
                    if (current > 0 && current % 2 != 0)
                    {
                        filteredElements.Add(current);
                    }
                }
            }

            // 4. SORT the collected elements in ascending order
            filteredElements.Sort();

            Console.WriteLine("Filtered elements (Odd, Positive, Sorted):");

            // 5. Display elements (max 5 per line)
            for (int i = 0; i < filteredElements.Count; i++)
            {
                Console.Write(filteredElements[i] + "\t");

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
                // Since it's sorted, the last element is the maximum
                int max = filteredElements[filteredElements.Count - 1];
                Console.WriteLine($"Maximum value: {max}");
            }
            else
            {
                Console.WriteLine("No elements matched the criteria.");
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}