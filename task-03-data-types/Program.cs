using System.Net.Mail;

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
MailAddress? email = null;
while (email == null)
{
    Console.Write("Enter your email: ");
    string? emailInput = Console.ReadLine(); // Declared inside the loop

    // Reversed condition: if NOT valid, show error.
    // TryCreate handles nulls and format internally.
    if (!MailAddress.TryCreate(emailInput, out email))
    {
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

// --- PASSWORD MASKING ---
Console.Write("Enter your 4-digit password: ****");
Console.SetCursorPosition(Console.CursorLeft - 4, Console.CursorTop);

string passInput = "";
while (passInput.Length < 4)
{
    ConsoleKeyInfo key = Console.ReadKey(true);

    if (char.IsDigit(key.KeyChar) && passInput.Length < 4)
    {
        passInput += key.KeyChar;
        Console.Write(key.KeyChar);
    }
    else if (key.Key == ConsoleKey.Backspace && passInput.Length > 0)
    {
        // Using the modern Range operator [..^1] as suggested
        passInput = passInput[..^1];
        Console.Write("\b*\b");
    }
}

// --- FINAL OUTPUT ---
Console.Clear();
Console.Write($"\n\tName: {name} (Characters: {name?.Length ?? 0})" +
              $"\n\tEmail: {email}" +
              $"\n\tAge: {age}" +
              $"\n\tPassword: {passInput:D4}\n");

Console.WriteLine("\nPress any key to exit...");
Console.ReadKey();