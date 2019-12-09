using Serilog;
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
            // Configure Serilog
            string LogPath = System.Configuration.ConfigurationManager.AppSettings["LogFile"];

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Warning()
                .WriteTo.RollingFile(pathFormat: LogPath,
                                     restrictedToMinimumLevel: GetMinimumLogLevel(),
                                     fileSizeLimitBytes: 5000000,   // 5MB
                                     retainedFileCountLimit: 10)
                .CreateLogger();

            Log.Information("Application starting...");

            // Register MVC & bundles
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_End()
        {
            try
            {
                Log.Information("Application ending...");

                // Close Serilog
                Log.CloseAndFlush();
            }
            catch
            {
                // App is ending.. Ignore any errors.
            }
        }

        /// <summary>
        /// Gets the log level from the web config
        /// </summary>
        /// <returns></returns>
        private Serilog.Events.LogEventLevel GetMinimumLogLevel()
        {
            try
            {
                string WebConfigLogLevel = System.Configuration.ConfigurationManager.AppSettings["LogLevel"].ToString().ToLower().Trim();
                switch (WebConfigLogLevel)
                {
                    case "verb":
                    case "verbose":
                        return Serilog.Events.LogEventLevel.Verbose;
                    case "debug":
                        return Serilog.Events.LogEventLevel.Debug;
                    case "info":
                    case "information":
                        return Serilog.Events.LogEventLevel.Information;
                    case "warn":
                    case "warning":
                        return Serilog.Events.LogEventLevel.Warning;
                    case "error":
                        return Serilog.Events.LogEventLevel.Error;
                    case "fatal":
                        return Serilog.Events.LogEventLevel.Fatal;
                }
            }
            catch (Exception ex) { }

            // Default to Warning if unable to read it
            return Serilog.Events.LogEventLevel.Warning;
        }
    }
}