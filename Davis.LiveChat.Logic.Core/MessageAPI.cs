using Davis.LiveChat.Logic.Core.Database;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Davis.LiveChat.Logic.Core
{
    public class MessageAPI
    {
        /// <summary>
        /// Saves a new message to the database
        /// </summary>
        /// <param name="pUserDisplayName"></param>
        /// <param name="pMessageText"></param>
        public void SaveMessage(string pUserDisplayName, string pMessageText)
        {
            using (var context = new LiveChatEntities())
            {
                context.ChatMessages.Add(new ChatMessage()
                {
                    SentDateTime = DateTime.Now,
                    Guid = Guid.NewGuid(),
                    SentUserName = pUserDisplayName,
                    MessageText = pMessageText
                });

                context.SaveChanges();
            }
        }

        /// <summary>
        /// Returns all messages within the past 20 minutes
        /// </summary>
        public List<DTO.ChatMessage> GetRecentMessages()
        {
            using (var context = new LiveChatEntities())
            {
                var DTCutoff = DateTime.Now.AddMinutes(-20);

                var items = (from item in context.ChatMessages
                             where item.SentDateTime >= DTCutoff
                             select item).ToList();

                var newItems = items.ConvertAll<DTO.ChatMessage>(item => new DTO.ChatMessage(item.SentDateTime, item.SentUserName, item.MessageText));

                return newItems;
            }
        }
    }
}