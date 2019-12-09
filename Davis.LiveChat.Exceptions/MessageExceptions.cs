using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Message specific exceptions
/// </summary>
namespace Davis.LiveChat.Exceptions
{

    /// <summary>
    /// Thrown when a message is invalid
    /// </summary>
    [Serializable]
    public class InvalidMessageException : Exception
    {
        public InvalidMessageException() : base("Invalid message!") { }
        public InvalidMessageException(string pMessage) : base(pMessage) { }
        protected InvalidMessageException(SerializationInfo serializationInfo, StreamingContext streamingContext) { }
    }
}
