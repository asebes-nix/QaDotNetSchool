// --- MAIN RUNTIME LOGIC (Top-level statements) ---

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

    string? choice = Console.ReadLine();

    if (choice == "5")
    {
        keepRunning = false;
        Console.WriteLine("Exiting calculator... Goodbye!");
        continue;
    }

    if (choice != "1" && choice != "2" && choice != "3" && choice != "4")
    {
        Console.WriteLine("Error: Invalid option. Press any key to try again.");
        Console.ReadKey();
        continue;
    }

    Console.Clear();

    double num1 = GetNumberFromUser("Enter the first number: ");
    double num2 = GetNumberFromUser("Enter the second number: ");

    // Handle division by zero before calculation
    if (choice == "4" && num2 == 0)
    {
        Console.WriteLine("Error: Division by zero is not allowed.");
    }
    else
    {
        // Using switch expression for cleaner scope and direct assignment
        double result = choice switch
        {
            "1" => num1 + num2,
            "2" => num1 - num2,
            "3" => num1 * num2,
            "4" => num1 / num2,
            _ => 0 // Fallback for the compiler
        };

        // Displaying the result with a clean format
        string op = choice switch { "1" => "+", "2" => "-", "3" => "*", _ => "/" };
        Console.WriteLine($"\nResult: {num1} {op} {num2} = {result}");
    }

    Console.WriteLine("\nPress any key to return to the menu...");
    Console.ReadKey();
}

// Local function for input validation
double GetNumberFromUser(string prompt)
{
    while (true)
    {
        Console.Write(prompt);
        string? input = Console.ReadLine();

        if (double.TryParse(input, out double number))
        {
            return number;
        }
        Console.WriteLine("Invalid input. Please enter a valid number.");
    }
}