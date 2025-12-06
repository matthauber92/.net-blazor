using System;

namespace BlazorApp.Domain.Exceptions
{
    public class DomainException : Exception
    {
        // Parameterless constructor
        public DomainException()
        {
        }

        // Constructor to accept a custom message
        public DomainException(string message)
            : base(message)
        {
        }

        // Constructor to accept a message and an inner exception
        public DomainException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        // Optional: Add a constructor for serialization (for older .NET Framework scenarios, 
        // but good practice if your application might cross AppDomains).
        // protected DomainException(
        //     System.Runtime.Serialization.SerializationInfo info, 
        //     System.Runtime.Serialization.StreamingContext context) 
        //     : base(info, context)
        // {
        // }
    }
}