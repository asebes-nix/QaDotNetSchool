using System;

namespace Task06Methods
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initialize 2 arrays with size 5
            int[] firstArray = new int[5];
            int[] secondArray = new int[5];

            // 1. Initialize arrays from keyboard
            Console.WriteLine("--- Initialize First Array ---");
            InitializeArray(firstArray);
            Console.WriteLine("\n--- Initialize Second Array ---");
            InitializeArray(secondArray);

            // 2. Display original arrays
            Console.WriteLine("\nFirst Array (Original):");
            PrintArray(firstArray);
            Console.WriteLine("Second Array (Original):");
            PrintArray(secondArray);

            // 3. Sort arrays in descending order
            SortDescending(firstArray);
            SortDescending(secondArray);

            // 4. Display sorted arrays
            Console.WriteLine("\nFirst Array (Sorted Descending):");
            PrintArray(firstArray);
            Console.WriteLine("Second Array (Sorted Descending):");
            PrintArray(secondArray);

            // 5. Check equivalence
            bool areEqual = AreArraysEquivalent(firstArray, secondArray);

            if (areEqual)
            {
                Console.WriteLine("\nResult: The arrays are equivalent.");
            }
            else
            {
                Console.WriteLine("\nResult: The arrays are NOT equivalent.");
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }

        // Method 1: Initialize array from user input
        static void InitializeArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                bool isValid = false;
                while (!isValid)
                {
                    Console.Write($"Enter element {i + 1}: ");
                    if (int.TryParse(Console.ReadLine(), out array[i]))
                    {
                        isValid = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter an integer.");
                    }
                }
            }
        }

        // Method 2: Print array elements with tabs
        static void PrintArray(int[] array)
        {
            foreach (int item in array)
            {
                Console.Write(item + "\t");
            }
            Console.WriteLine();
        }

        // Method 3: Sort array in descending order (Bubble Sort)
        static void SortDescending(int[] array)
        {
            int n = array.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    // For descending order, we swap if the current is smaller than the next
                    if (array[j] < array[j + 1])
                    {
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
        }

        // Method 4: Check if two arrays are equivalent
        static bool AreArraysEquivalent(int[] array1, int[] array2)
        {
            // First check if lengths are different
            if (array1.Length != array2.Length) return false;

            // Check element by element
            for (int i = 0; i < array1.Length; i++)
            {
                if (array1[i] != array2[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}