using Nix.Oop.Interfaces.AbstractClasses;

Animal dog = new Dog();
dog.Sound();
((IRunable)dog).Run();
((IEatable)dog).Eat();
((ISleepable)dog).Sleep();
((IAnimal)dog).IsAnimal();

Animal cat = new Cat();
cat.Sound();
((IRunable)cat).Run();
((IEatable)cat).Eat();
((ISleepable)cat).Sleep();
((IAnimal)cat).IsAnimal();

Console.ReadKey();