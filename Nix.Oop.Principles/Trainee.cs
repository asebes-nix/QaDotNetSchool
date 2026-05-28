namespace Nix.Oop.Principles;

public class Trainee : Barista
{
    public override void MakingEspresso()
    {
        Console.WriteLine("Trainee is making Espresso (it takes a bit longer...)");
    }
}
