namespace Nix.Oop.Constructors;

public class Messenger(string message, int messageCounter)
{
    public static string State;

    static Messenger()
    {
        State = "Active";
    }

    internal void Deconstruct(out string msg, out int counter)
    {
        msg = message;
        counter = messageCounter;
    }
}