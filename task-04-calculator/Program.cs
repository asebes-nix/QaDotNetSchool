using System;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            bool keepRunning = true;

            while (keepRunning)
            {
                Console.Clear();
                Console.WriteLine("--- Calculator Menu ---");
                Console.WriteLine("1. Addition (+)");
                Console.WriteLine("2. Subtraction (-)");
                Console.WriteLine("3. Multiplication (*)");
                Console.WriteLine("4. Division (/)");
                Console.WriteLine("5. Exit");
                Console.Write("\nSelect an option (1-5): ");

                string choice = Console.ReadLine();

                // Handle exit immediately
                if (choice == "5")
                {
                    keepRunning = false;
                    Console.WriteLine("Exiting calculator... Goodbye!");
                    continue;
                }

                // Validate menu input
                if (choice != "1" && choice != "2" && choice != "3" && choice != "4")
                {
                    Console.WriteLine("Error: Invalid option. Press any key to try again.");
                    Console.ReadKey();
                    continue;
                }

                // Clear screen after selection as required
                Console.Clear();

                // Operand input with basic validation
                double num1 = GetNumberFromUser("Enter the first number: ");
                double num2 = GetNumberFromUser("Enter the second number: ");

                double result = 0;
                bool success = true;

                // Using switch for operations
                switch (choice)
                {
                    case "1":
                        result = num1 + num2;
                        Console.WriteLine($"Result: {num1} + {num2} = {result}");
                        break;
                    case "2":
                        result = num1 - num2;
                        Console.WriteLine($"Result: {num1} - {num2} = {result}");
                        break;
                    case "3":
                        result = num1 * num2;
                        Console.WriteLine($"Result: {num1} * {num2} = {result}");
                        break;
                    case "4":
                        // Using if..else for division by zero check
                        if (num2 != 0)
                        {
                            result = num1 / num2;
                            Console.WriteLine($"Result: {num1} / {num2} = {result}");
                        }
                        else
                        {
                            Console.WriteLine("Error: Division by zero is not allowed.");
                            success = false;
                        }
                        break;
                }

                Console.WriteLine("\nPress any key to return to the menu...");
                Console.ReadKey();
            }
        }

        // Helper method for clean number input
        static double GetNumberFromUser(string prompt)
        {
            double number;
            while (true)
            {
                Console.Write(prompt);
                if (double.TryParse(Console.ReadLine(), out number))
                {
                    return number;
                }
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }
    }
}