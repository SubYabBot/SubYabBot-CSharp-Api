using System;
using System.Collections.Generic;
using System.Text;

namespace SubYabBot_API.Exceptions
{
    public class SubYabBotAuthorizationException : Exception
    {
        public SubYabBotAuthorizationException() { }
        public SubYabBotAuthorizationException(string message) : base(message) { }
        public SubYabBotAuthorizationException(string message, Exception inner) : base(message, inner) { }
        protected SubYabBotAuthorizationException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
