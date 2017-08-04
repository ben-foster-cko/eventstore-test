using System;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using EventStore.ClientAPI;
using SerilogTimings.Extensions;

namespace EventStoreTestApi.Controllers
{
    public class TestController : ApiController
    {
        public async Task<IHttpActionResult> Post()
        {
            await WriteAuthoriseEventsAsync();
            return Ok();
        }

        private static async Task WriteAuthoriseEventsAsync()
        {
            var requestedEvent = new EventData(Guid.NewGuid(), "ChargeRequested", true,
                Encoding.UTF8.GetBytes(JsonEvents.RequestedEvent), null);

            var authorisedEvent = new EventData(Guid.NewGuid(), "ChargeAuthorised", true,
                Encoding.UTF8.GetBytes(JsonEvents.AuthorisedJson), null);

            var chargeId = Guid.NewGuid();

            using (Global.Logger.TimeOperation("Writing to event store"))
            {
                await Global.EsConnection.AppendToStreamAsync(
                    $"Test.CardCharge-{chargeId}",
                    ExpectedVersion.NoStream, requestedEvent,
                    authorisedEvent);
            }
        }

    }
}