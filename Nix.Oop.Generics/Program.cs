using Nix.Oop.Generics;

User user1 = new(1, 100);
Provider<User> provider = new();
provider.CheckBalance(user1);

Console.ReadKey();