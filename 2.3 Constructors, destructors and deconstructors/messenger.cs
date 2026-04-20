namespace Nix.Oop.Constructors;

public class Messenger
{
    public static string State;
    public string message;
    public int messageCounter;

    static Messenger()
    {
        State = "Active";
    }

    public Messenger(string message, int messageCounter)
    {
        this.message = message;
        this.messageCounter = messageCounter;
    }

    internal void Deconstruct(out string msg, out int counter)
    {
        msg = message;
        counter = messageCounter;
    }
}