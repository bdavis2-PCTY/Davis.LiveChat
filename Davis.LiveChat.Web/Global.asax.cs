using Davis.LiveChat.Logic.Core.Database;
using System;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Davis.LiveChat.Web
{
    public class LiveChatApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Configure db
            using (var context = new LiveChatEntities())
            {
                var post = new ChatMessage()
                {
                    Guid = Guid.NewGuid(),
                    SentUserName = "Sender Name",
                    MessageText = "My Message :)",
                    SentDateTime = DateTime.Now
                };

                context.ChatMessages.Add(post);
                context.SaveChanges();
            }

        }
    }
}