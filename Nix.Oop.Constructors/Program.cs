using Nix.Oop.Constructors;

Messenger myMessenger = new("Hey! Just testing the Cunsturctors.", 1);
Console.WriteLine($"Status: {Messenger.State}");

var(text, sequence) = myMessenger;

Console.WriteLine($"Message: {text}");
Console.WriteLine($"#{sequence} - {text}");

Console.ReadKey();