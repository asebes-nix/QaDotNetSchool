using Nix.Oop.Interfaces.AbstractClasses;

Dog dog = new Dog();
dog.Sound();
dog.Run();
dog.Eat();
dog.Sleep();
((IAnimal)dog).IsAnimal();

Cat cat = new Cat();
cat.Sound();
cat.Run();
cat.Eat();
cat.Sleep();
((IAnimal)cat).IsAnimal();

Console.ReadKey();