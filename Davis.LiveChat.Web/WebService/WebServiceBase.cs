namespace Davis.LiveChat.Web.WebService
{
    /// <summary>
    /// Base object for web services
    /// </summary>
    public abstract class WebServiceBase
    {
        public string ResponseHandler(object pResponseObj)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(pResponseObj, Newtonsoft.Json.Formatting.None, new Newtonsoft.Json.JsonSerializerSettings()
            {
                DateFormatString = "HH:mm:ss"
            });
        }
    }
}