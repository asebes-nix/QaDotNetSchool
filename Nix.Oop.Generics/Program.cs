using Nix.Oop.Generics;

User user1 = new User(1, 100);
Provider<User> provider = new Provider<User>();
provider.CheckBalance(user1);

Console.ReadKey();