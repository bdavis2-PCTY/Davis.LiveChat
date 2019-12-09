using Newtonsoft.Json;
using System.Web.Services;

namespace Davis.LiveChat.Web.WebService
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class SiteLink : WebServiceBase
    {
        [WebMethod(true)]
        public void SaveMessage(string pUserDisplayName, string pMessageText)
        {
            new Logic.Core.API.MessageAPI().SaveMessage(pUserDisplayName, pMessageText);
        }

        [WebMethod(true)]
        public string GetRecentMessages()
        {
            var Messages = new Logic.Core.API.MessageAPI().GetRecentMessages();
            return base.ResponseHandler(Messages);
        }
    }
}