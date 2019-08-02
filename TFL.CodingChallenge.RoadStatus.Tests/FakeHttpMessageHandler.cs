using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace TFL.CodingChallenge.RoadStatus.Tests
{
    public class FakeHttpMessageHandler : HttpMessageHandler
    {
        public virtual HttpResponseMessage Send(HttpRequestMessage request)
        {
            return new HttpResponseMessage();
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return Task.FromResult(Send(request));
        }
    }
}
