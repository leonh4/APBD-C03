using System.Runtime.Serialization;

namespace C03;

public class OverfillException : Exception
{
    public OverfillException()
    {
    }
    
    public OverfillException(string? message) 
        : base(message)
    {
    }

    public OverfillException(string? message, Exception? innerException) 
        : base(message, innerException)
    {
    }
}