using System;

namespace Davis.LiveChat.Logic.Core.Database
{
    public partial class ChatMessage
    {
        internal ChatMessage() { }

        public ChatMessage(Guid pGuid, DateTime pSentDateTime, string pSentUserName, string pMessageText)
        {
            this.Guid = pGuid;
            this.SentDateTime = pSentDateTime;
            this.SentUserName = pSentUserName;
            this.MessageText = pMessageText;
        }
    }
}