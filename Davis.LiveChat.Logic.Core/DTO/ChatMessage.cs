using System;

namespace Davis.LiveChat.Logic.Core.DTO
{
    public class ChatMessage
    {
        public DateTime SentDateTime { get; set; }
        public string UserName { get; set; }
        public string Message { get; set; }

        public ChatMessage(DateTime pSentDateTime, string pUserName, string pMessage)
        {
            SentDateTime = pSentDateTime;
            UserName = pUserName;
            Message = pMessage;
        }
    }
}