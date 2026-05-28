namespace Nix.Oop.Principles;

public class Barista
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
