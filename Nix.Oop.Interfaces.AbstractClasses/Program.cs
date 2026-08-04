using Nix.Oop.Interfaces.AbstractClasses;

Animal dog = new Dog();
dog.Sound();
((IRunable)dog).Run();
((IEscapable)dog).Run();
((IEatable)dog).Eat();
((ISleepable)dog).Sleep();

Animal cat = new Cat();
cat.Sound();
((IRunable)cat).Run();
((IEscapable)cat).Run();
((IEatable)cat).Eat();
((ISleepable)cat).Sleep();

Console.ReadKey();