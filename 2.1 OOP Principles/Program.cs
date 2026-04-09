CoffeeMachinePhilips philips = new CoffeeMachinePhilips();
Console.WriteLine(philips.ModelName);
Coffee coffee = new Coffee();
coffee.MakeLatte();
Barista barista = new Barista();
barista.MakingEspresso();
Trainee trainee = new Trainee();
trainee.MakingEspresso();
Console.ReadKey();

class CoffeeMachine
{
    public string ModelName { get; set; } = "Generic Machine";
}
class CoffeeMachinePhilips : CoffeeMachine {}

abstract class CoffeeOptions 
{
    public abstract void MakeLatte();
} 

class Coffee : CoffeeOptions
{
    public override void MakeLatte()
    {
        Console.WriteLine("Making a delicious Latte...!");
    }
}

class Barista
{
    private static void MakingSecretCofee()
    {
        Console.WriteLine("Making a coffeee with a secret ingredient!");
    }
    public virtual void MakingEspresso()
    {
        MakingSecretCofee();
        Console.WriteLine("Barista is making a classic Espresso.");
     }
}

class Trainee : Barista
{
    public override void MakingEspresso()
    {
        Console.WriteLine("Trainee is making Espresso (it takes a bit longer...)");
    }
}