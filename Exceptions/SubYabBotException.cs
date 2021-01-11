using System;
using System.Collections.Generic;
using System.Text;

namespace SubYabBot_API.Exceptions
{
    [global::System.Serializable]
    public class SubYabBotException : Exception
    {
        public SubYabBotException() { }
        public SubYabBotException(string message) : base(message) { }
        public SubYabBotException(string message, Exception inner) : base(message, inner) { }
        protected SubYabBotException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }

    }
}
