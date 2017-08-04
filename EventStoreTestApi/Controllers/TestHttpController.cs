using System;
using System.Configuration;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Newtonsoft.Json;
using SerilogTimings.Extensions;

namespace EventStoreTestApi.Controllers
{
    public class TestHttpController : ApiController
    {
        private static readonly HttpClient HttpClient = new HttpClient();

        public async Task<IHttpActionResult> Post()
        {
            await WriteAuthoriseEventsAsync();
            return Ok();
        }

        private static async Task WriteAuthoriseEventsAsync()
        {
            var requestedEvent = JsonConvert.DeserializeObject(JsonEvents.RequestedEvent);
            var authorisedEvent = JsonConvert.DeserializeObject(JsonEvents.AuthorisedJson);

            var events = new[]
                {CreateEvent("ChargeRequested", requestedEvent), CreateEvent("ChargeAuthorised", authorisedEvent)};

            var eventStoreHttpUrl =
                ConfigurationManager.ConnectionStrings["EventStoreHttpConnection"].ConnectionString;


            var streamUrl = $"{eventStoreHttpUrl}/streams/Test.CardCharge-{Guid.NewGuid()}";
            var json = JsonConvert.SerializeObject(events);

            var request = new HttpRequestMessage(HttpMethod.Post, new Uri(streamUrl))
            {
                Content = new StringContent(json, Encoding.UTF8, "application/vnd.eventstore.events+json")
            };

            request.Headers.Add("ES-ExpectedVersion", "-1");

            using (Global.Logger.TimeOperation("Writing to event store"))
            {
                var response = await HttpClient.SendAsync(request);
                response.EnsureSuccessStatusCode();
            }
        }

        private static object CreateEvent(string eventType, object data)
        {
            return new
            {
                eventId = Guid.NewGuid(),
                eventType = eventType,
                data = data
            };
        }
    }
}