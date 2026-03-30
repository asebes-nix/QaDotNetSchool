using System.Net.Mail;

// 1. TOP-LEVEL STATEMENTS (No namespace or class needed here anymore)

// --- NAME VALIDATION ---
string? name = string.Empty;
while (string.IsNullOrWhiteSpace(name))
{
    Console.Write("Enter your name: ");
    name = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(name))
        Console.WriteLine("Error: Name cannot be empty.");
}

// --- EMAIL VALIDATION ---
string? emailInput = string.Empty;
MailAddress? email = null;
while (email == null)
{
    Console.Write("Enter your email: ");
    emailInput = Console.ReadLine();

    // Using TryCreate instead of try-catch as suggested
    if (MailAddress.TryCreate(emailInput, out email) && emailInput != null && emailInput.Contains("."))
    {
        // Valid email
    }
    else
    {
        email = null; // Keep looping
        Console.WriteLine("Error: Invalid format. Advice: Use 'name@domain.com'.");
    }
}

// --- AGE VALIDATION ---
int age = 0;
while (age < 1 || age > 149)
{
    Console.Write("Enter your age (1-149): ");
    string? input = Console.ReadLine();
    if (!int.TryParse(input, out age) || age < 1 || age > 149)
        Console.WriteLine("Error: Invalid age. Enter a number between 1 and 149.");
}

// --- PASSWORD MASKING (Advanced logic) ---
Console.Write("Enter your 4-digit password: ****");
Console.SetCursorPosition(Console.CursorLeft - 4, Console.CursorTop);

string passInput = "";
while (passInput.Length < 4)
{
    ConsoleKeyInfo key = Console.ReadKey(true); // true = don't display the typed character

    // Only allow digits and limit to 4
    if (char.IsDigit(key.KeyChar) && passInput.Length < 4)
    {
        passInput += key.KeyChar;
        Console.Write(key.KeyChar); // Overwrite the asterisk
    }
    // Handle backspace
    else if (key.Key == ConsoleKey.Backspace && passInput.Length > 0)
    {
        passInput = passInput.Remove(passInput.Length - 1);
        Console.Write("\b*\b"); // Move back, restore asterisk, move back again
    }
}

// --- FINAL OUTPUT ---
Console.Clear();
// Using :D4 directly in the interpolation as suggested
Console.Write($"\n\tName: {name} (Characters: {name?.Length ?? 0})" +
              $"\n\tEmail: {email}" +
              $"\n\tAge: {age}" +
              $"\n\tPassword: {passInput:D4}\n");

Console.WriteLine("\nPress any key to exit...");
Console.ReadKey();