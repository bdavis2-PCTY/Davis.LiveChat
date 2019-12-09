using System;
using System.Runtime.Serialization;

/// <summary>
/// User Specific Exceptions
/// </summary>
namespace Davis.LiveChat.Exceptions
{
    /// <summary>
    /// Thrown when the user's name does not meet requirements.
    /// </summary>
    [Serializable]
    public class InvalidUserNameException : Exception
    {
        public InvalidUserNameException() : base("Invalid username!") { }
        public InvalidUserNameException(string pMessage) : base(pMessage) { }
        protected InvalidUserNameException(SerializationInfo serializationInfo, StreamingContext streamingContext) { }
    }
}