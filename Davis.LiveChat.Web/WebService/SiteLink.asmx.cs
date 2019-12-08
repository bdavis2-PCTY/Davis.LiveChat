using Newtonsoft.Json;
using System.Web.Services;

namespace Davis.LiveChat.Web.WebService
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class SiteLink : System.Web.Services.WebService
    {
        [WebMethod(true)]
        public void SaveMessage(string pUserDisplayName, string pMessageText)
        {
            new Davis.LiveChat.Logic.Core.MessageAPI().SaveMessage(pUserDisplayName, pMessageText);
        }

        [WebMethod(true)]
        public string GetRecentMessages()
        {
            var messages = new Logic.Core.MessageAPI().GetRecentMessages();
            return JsonConvert.SerializeObject(messages);
        }
    }
}