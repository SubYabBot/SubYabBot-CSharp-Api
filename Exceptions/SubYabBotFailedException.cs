using System;
using System.Collections.Generic;
using System.Text;

namespace SubYabBot_API.Exceptions
{
    public class SubYabBotFailedException : Exception
    {
        public SubYabBotFailedException() { }
        public SubYabBotFailedException(string message) : base(message) { }
        public SubYabBotFailedException(string message, Exception inner) : base(message, inner) { }
        protected SubYabBotFailedException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
