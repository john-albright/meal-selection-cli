using System;
using System.Collections.Generic;
using System.Text;

namespace Menu_Selection
{
    class InvalidOrderException : Exception
    {
        private readonly static string msg = "Unable to process order";
        public InvalidOrderException() : base(msg) { }
        public InvalidOrderException(string message) : base(message) { }
        public InvalidOrderException(string message, Exception inner) : base(message, inner) { }
    }
}
