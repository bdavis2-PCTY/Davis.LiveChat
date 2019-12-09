using Serilog;
using System;

namespace Davis.LiveChat.Logic.Core.API
{
    /// <summary>
    /// Used as a base object for APIs
    /// </summary>
    public abstract class BaseAPI
    {
        /// <summary>
        /// Handle exceptions being thrown in an API
        /// </summary>
        /// <param name="pException"></param>
        public void ExceptionHandler(Exception pException)
        {
            // Check if it was a custom exception
            if (pException.Source.StartsWith("Davis.LiveChat"))
            {
                // Custom exception. Only warn log.
                Log.Warning(pException, "Custom exception message");
            }
            else
            {
                // Unhandled exception
                string CustomErrorMessage = "There was an unhandled exception. Please try again or contact an administrator.";
                Log.Error(pException, CustomErrorMessage);
                throw new Exception(CustomErrorMessage);
            }
        }
    }
}