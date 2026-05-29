bool keepRunning = true;

while (keepRunning)
{
    Console.Clear();
    Console.WriteLine("--- Calculator Menu ---");
    Console.WriteLine("1. Addition (+)\n2. Subtraction (-)\n3. Multiplication (*)\n4. Division (/)\n5. Exit");
    Console.Write("\nSelect an option (1-5): ");

    string? choice = Console.ReadLine();

     switch (choice)
    {
        case "1":
        {
            Console.Clear();
            double num1 = GetNumberFromUser("Enter the first number: ");
            double num2 = GetNumberFromUser("Enter the second number: ");
            Console.WriteLine($"Result: {num1} + {num2} = {num1 + num2}");
            break;
        }

        case "2":
        {
            Console.Clear();
            double num1 = GetNumberFromUser("Enter the first number: ");
            double num2 = GetNumberFromUser("Enter the second number: ");
            Console.WriteLine($"Result: {num1} - {num2} = {num1 - num2}");
            break;
        }
        case "3":
        {
            Console.Clear();
            double num1 = GetNumberFromUser("Enter the first number: ");
            double num2 = GetNumberFromUser("Enter the second number: ");
            Console.WriteLine($"Result: {num1} * {num2} = {num1 * num2}");
            break;
        }
        case "4":
        {
            Console.Clear();
            double num1 = GetNumberFromUser("Enter the first number: ");
            double num2 = GetNumberFromUser("Enter the second number: ");
            if (num2 != 0) Console.WriteLine($"Result: {num1} / {num2} = {num1 / num2}");
            else Console.WriteLine("Error: Division by zero is not allowed.");
            break;
        }
        case "5":
        {
            Console.WriteLine("Exiting calculator... Goodbye!");
            keepRunning = false;
            break;
        }

         

        default:
            Console.WriteLine("Error: Invalid option. Press any key to try again.");
            break;
    }

    if (keepRunning)
    {
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }
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