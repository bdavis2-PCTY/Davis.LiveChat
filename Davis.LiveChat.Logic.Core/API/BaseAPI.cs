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
            Log.Error(pException, "API Error");

            throw new Exception("There was an error in an API!");
        }
    }
}