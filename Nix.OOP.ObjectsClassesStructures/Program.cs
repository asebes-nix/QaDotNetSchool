using Nix.OOP.ObjectsClassesStructures;

User testUser = new(1, "Péter", 45);
testUser.PrintInfo();
User.ChangeUserAge(testUser, 46);
testUser.PrintInfo();
Console.ReadKey();
