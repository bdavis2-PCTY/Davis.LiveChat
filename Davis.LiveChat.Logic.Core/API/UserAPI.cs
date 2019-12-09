using Davis.LiveChat.Exceptions;

namespace Davis.LiveChat.Logic.Core.API
{
    public class UserAPI : BaseAPI
    {
        /// <summary>
        /// Minimum characters of a user name
        /// </summary>
        public static readonly int MIN_USERNAME_LENGTH = 3;

        /// <summary>
        /// Maximum characters for a username
        /// </summary>
        public static readonly int MAX_USERNAME_LENGTH = 50;

        /// <summary>
        /// Validates the user's name. Throws an InvalidUserNameException if the username does not meet requirements
        /// </summary>
        /// <param name="pUserName"></param>
        public void ValidateUserName(string pUserName)
        {
            // valid the user actually has a user name
            if (string.IsNullOrWhiteSpace(pUserName))
            {
                throw new InvalidUserNameException("Username must be provided");
            }

            // Validate length
            if (pUserName.Length < MIN_USERNAME_LENGTH)
            {
                throw new InvalidUserNameException($"Username must be at least {MIN_USERNAME_LENGTH} characters");
            }
            else if (pUserName.Length > MAX_USERNAME_LENGTH)
            {
                throw new InvalidUserNameException($"Maximum username is {MAX_USERNAME_LENGTH} characters");
            }
        }
    }
}