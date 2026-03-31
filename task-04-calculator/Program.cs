// --- TOP-LEVEL STATEMENTS: No namespace or class Program needed ---

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

    // Nullable string to handle potential null from ReadLine
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

    double result;

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
            if (num2 != 0)
            {
                result = num1 / num2;
                Console.WriteLine($"Result: {num1} / {num2} = {result}");
            }
            else
            {
                Console.WriteLine("Error: Division by zero is not allowed.");
            }
            break;
    }

    Console.WriteLine("\nPress any key to return to the menu...");
    Console.ReadKey();
}

// Local function - cleaner than static methods in Top-level statements
double GetNumberFromUser(string prompt)
{
    double number;
    while (true)
    {
        Console.Write(prompt);
        // Handling nullability for the input
        string? input = Console.ReadLine();
        if (double.TryParse(input, out number))
        {
            return number;
        }
        Console.WriteLine("Invalid input. Please enter a valid number.");
    }
}