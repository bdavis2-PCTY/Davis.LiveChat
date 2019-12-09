using Davis.LiveChat.Exceptions;
using Davis.LiveChat.Logic.Core.Database;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Davis.LiveChat.Logic.Core.API
{
    public class MessageAPI : BaseAPI
    {
        /// <summary>
        /// The maximum minutes in the past recent messages will be pulled from
        /// </summary>
        public static readonly int MAX_RECENT_MESSAGE_MINUTES = 20;

        /// <summary>
        /// Maximum characters for a message
        /// </summary>
        public static readonly int MAX_MESSAGE_LENGTH = 5000;

        /// <summary>
        /// Saves a new message to the database
        /// </summary>
        /// <param name="pUserDisplayName"></param>
        /// <param name="pMessageText"></param>
        public void SaveMessage(string pUserDisplayName, string pMessageText)
        {
            try
            {
                string Message = pMessageText;
                if (Message != null)
                {
                    Message = System.Web.HttpUtility.HtmlEncode(Message.Trim());
                }

                // Validate input
                new UserAPI().ValidateUserName(pUserDisplayName);
                ValidateMessage(Message);


                using (LiveChatEntities DatabaseContext = new LiveChatEntities())
                {
                    Log.Information("User {@pUserDisplayname} sent message: {@pMessageText}", pUserDisplayName, pMessageText);

                    DatabaseContext.ChatMessages.Add(new ChatMessage(Guid.NewGuid(), DateTime.Now, pUserDisplayName, pMessageText));
                    DatabaseContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
                throw;
            }
        }

        /// <summary>
        /// Returns all messages within the past <see cref="MAX_RECENT_MESSAGE_MINUTES"/> minutes
        /// </summary>
        public List<DTO.ChatMessage> GetRecentMessages()
        {
            try
            {
                using (LiveChatEntities DatabaseContext = new LiveChatEntities())
                {
                    DateTime DTCutoff = DateTime.Now.AddMinutes(MAX_RECENT_MESSAGE_MINUTES * -1);

                    List<DTO.ChatMessage> Messages = (from item in DatabaseContext.ChatMessages
                                                      where item.SentDateTime >= DTCutoff
                                                      select item).ToList()
                                                     .Select(item => new DTO.ChatMessage(item.SentDateTime, item.SentUserName, item.MessageText)).ToList();

                    return Messages;
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
                throw;
            }
        }

        #region Helpers

        /// <summary>
        /// Validates a message meets requirements.
        /// Throws an InvalidMessageException if it does not.
        /// </summary>
        /// <param name="pMessage"></param>
        private void ValidateMessage(string pMessage)
        {
            if (string.IsNullOrWhiteSpace(pMessage))
            {
                throw new InvalidMessageException("A message must be entered");
            }

            if (pMessage.Length > MAX_MESSAGE_LENGTH)
            {
                throw new InvalidMessageException($"A message cannot exceed {MAX_MESSAGE_LENGTH} characters");
            }
        }

        #endregion 

    }
}