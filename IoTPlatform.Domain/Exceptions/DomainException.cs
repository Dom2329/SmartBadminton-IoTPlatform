
using System;

namespace IoTPlatform.Domain.Exceptions
{
    public class DomainException : Exception
    {
        //----------------------------------------constructor-----------------------
        public DomainException(string message) : base(message)
        {
        }
    }
}
