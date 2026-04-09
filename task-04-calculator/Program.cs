bool keepRunning = true;

while (keepRunning)
{
    Console.Clear();
    Console.WriteLine("--- Calculator Menu ---");
    Console.WriteLine("1. Addition (+)\n2. Subtraction (-)\n3. Multiplication (*)\n4. Division (/)\n5. Exit");
    Console.Write("\nSelect an option (1-5): ");

    string? choice = Console.ReadLine();

    if (choice == "5")
    {
        keepRunning = false;
        continue;
    }

    // Single switch to handle logic and output as requested by mentor
    switch (choice)
    {
        case "1":
        case "2":
        case "3":
        case "4":
            Console.Clear();
            double num1 = GetNumberFromUser("Enter the first number: ");
            double num2 = GetNumberFromUser("Enter the second number: ");

            if (choice == "1") Console.WriteLine($"Result: {num1} + {num2} = {num1 + num2}");
            else if (choice == "2") Console.WriteLine($"Result: {num1} - {num2} = {num1 - num2}");
            else if (choice == "3") Console.WriteLine($"Result: {num1} * {num2} = {num1 * num2}");
            else if (choice == "4")
            {
                // Check for division by zero
                if (num2 != 0) Console.WriteLine($"Result: {num1} / {num2} = {num1 / num2}");
                else Console.WriteLine("Error: Division by zero is not allowed.");
            }
            break;

        default:
            Console.WriteLine("Error: Invalid option. Press any key to try again.");
            break;
    }

    Console.WriteLine("\nPress any key to continue...");
    Console.ReadKey();
}

// Added static keyword as it doesn't access instance properties
static double GetNumberFromUser(string prompt)
{
    while (true)
    {
        Console.Write(prompt);
        if (double.TryParse(Console.ReadLine(), out double number))
        {
            return number;
        }
        Console.WriteLine("Invalid input. Please enter a valid number.");
    }
}