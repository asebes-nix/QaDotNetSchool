namespace Nix.Exceptions;

public class CriticalErrorException : Exception
{
    public CriticalErrorException(string message) : base(message)
    {
    }
}