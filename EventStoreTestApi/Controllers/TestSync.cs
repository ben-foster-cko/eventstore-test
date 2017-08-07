using System;
using System.Text;
using System.Web.Http;
using EventStore.ClientAPI;
using SerilogTimings.Extensions;

namespace EventStoreTestApi.Controllers
{
    public class TestSyncController : ApiController
    {
        public IHttpActionResult Post()
        {
            WriteAuthoriseEventsSync();
            return Ok();
        }

        private static void WriteAuthoriseEventsSync()
        {
            var requestedEvent = new EventData(Guid.NewGuid(), "ChargeRequested", true,
                Encoding.UTF8.GetBytes(JsonEvents.RequestedEvent), null);

            var authorisedEvent = new EventData(Guid.NewGuid(), "ChargeAuthorised", true,
                Encoding.UTF8.GetBytes(JsonEvents.AuthorisedJson), null);

            var chargeId = Guid.NewGuid();

            using (Global.Logger.TimeOperation("Writing to event store"))
            {
                Global.EsConnection.AppendToStreamAsync(
                    $"Test.CardCharge-{chargeId}",
                    ExpectedVersion.Any, requestedEvent,
                    authorisedEvent).Wait();
            }
        }

    }
}