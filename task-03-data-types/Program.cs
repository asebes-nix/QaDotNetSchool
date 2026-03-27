using System;
using System.Net.Mail;

namespace Task03DataTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            // --- NAME VALIDATION (max 50 chars) ---
            string name = "";
            while (string.IsNullOrWhiteSpace(name) || name.Length > 50)
            {
                Console.Write("Enter your name (max 50 characters): ");
                name = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(name) || name.Length > 50)
                    Console.WriteLine("Error: Invalid name. Advice: Use 1-50 characters.");
            }

            // --- EMAIL VALIDATION (standard format) ---
            string email = "";
            bool isValidEmail = false;
            while (!isValidEmail)
            {
                Console.Write("Enter your email: ");
                email = Console.ReadLine();
                try
                {
                    var addr = new MailAddress(email);
                    if (addr.Address == email && email.Contains("."))
                        isValidEmail = true;
                    else
                        throw new Exception();
                }
                catch
                {
                    Console.WriteLine("Error: Invalid format. Advice: Use 'name@domain.com' format.");
                }
            }

            // --- AGE VALIDATION (1-149) ---
            int age = 0;
            while (age < 1 || age > 149)
            {
                Console.Write("Enter your age (1-149): ");
                string input = Console.ReadLine();
                if (!int.TryParse(input, out age) || age < 1 || age > 149)
                    Console.WriteLine("Error: Invalid age. Advice: Enter a whole number between 1 and 149.");
            }

            // --- PASSWORD VALIDATION (exactly 4 digits) ---
            int password = 0;
            bool isValidPass = false;
            while (!isValidPass)
            {
                Console.Write("Enter your 4-digit password: ****");
                Console.SetCursorPosition(Console.CursorLeft - 4, Console.CursorTop);

                string input = Console.ReadLine();
                // Check if it's a number, positive, and exactly 4 characters long
                if (int.TryParse(input, out password) && input.Length == 4 && password >= 0)
                    isValidPass = true;
                else
                    Console.WriteLine("\nError: Invalid password. Advice: Enter exactly 4 positive digits.");
            }

            // --- FINAL OUTPUT ---
            Console.Clear();
            int nameLength = name.Length;

            // Using escape sequences: \n for new line, \t for tab
            Console.Write($"\n\tName: {name} (Characters: {nameLength})" +
                          $"\n\tEmail: {email}" +
                          $"\n\tAge: {age}" +
                          $"\n\tPassword: {password.ToString("D4")}\n");

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}