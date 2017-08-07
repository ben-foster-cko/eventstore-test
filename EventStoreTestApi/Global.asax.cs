using System;
using System.Configuration;
using System.Web.Http;
using EventStore.ClientAPI;
using Serilog;

namespace EventStoreTestApi
{
    public class Global : System.Web.HttpApplication
    {
        private static Lazy<IEventStoreConnection> _connection;

        public static IEventStoreConnection EsConnection => _connection.Value;

        public static Serilog.ILogger Logger { get; private set; }

        protected void Application_Start(object sender, EventArgs e)
        {
            Logger = new LoggerConfiguration()
                .ReadFrom.AppSettings()
                .Enrich.WithProperty("ApplicationName", "EventStoreTestApi")
                .CreateLogger();

            _connection = new Lazy<IEventStoreConnection>(ConnectToEventStore);

            GlobalConfiguration.Configure(configuration =>
            {
                configuration.Routes.MapHttpRoute("Default", "{controller}/{id}", new { id = RouteParameter.Optional });;
            });
        }

        private static IEventStoreConnection ConnectToEventStore()
        {
            var settings = ConnectionSettings.Create()
                .UseCustomLogger(new SerilogEventStoreLogger(Logger));

            var connection =
                EventStoreConnection.Create(
                    ConfigurationManager.ConnectionStrings["EventStoreConnection"].ConnectionString, settings,
                    "EventStore Test App");

            connection
                .Connected += (sender, args)
                => Logger.Information("Connected to Event Store");

            connection.ConnectAsync().GetAwaiter().GetResult();

            return connection;
        }
    }
}