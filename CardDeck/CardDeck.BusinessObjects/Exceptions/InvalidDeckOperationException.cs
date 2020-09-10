using System;
using System.Collections.Generic;
using System.Text;

namespace CardDeck.Exceptions
{
    public class InvalidDeckOperationException : Exception
    {
        public InvalidDeckOperationException()
        {
        }

        public InvalidDeckOperationException(string message)
            : base(message)
        { }

        public InvalidDeckOperationException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
