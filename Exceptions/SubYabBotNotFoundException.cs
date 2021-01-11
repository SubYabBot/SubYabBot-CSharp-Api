using System;
using System.Collections.Generic;
using System.Text;

namespace SubYabBot_API.Exceptions
{
    public class SubYabBotNotFoundException : Exception
    {
        public SubYabBotNotFoundException() { }
        public SubYabBotNotFoundException(string message) : base(message) { }
        public SubYabBotNotFoundException(string message, Exception inner) : base(message, inner) { }
        protected SubYabBotNotFoundException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
