using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using TFL.CodingChallenge.RoadStatus.Services;
using TFL.CodingChallenge.RoadStatus.Services.Models;

namespace TFL.CodingChallenge.RoadStatus.Tests
{
    [TestClass]
    public class RoadService_GivenRoadId
    {

        [TestMethod]
        public async Task RoadStatus_GivenInputIsA2_ReturnValidRoadIds()
        {
            // Arrange
            var expected = new Road()
            {
                Id = "a2",
                DisplayName = "A2",
                StatusSeverity = "Good",
                StatusSeverityDescription = "No Exceptional Delays"
            };

            var fakeHttpMessageHandler = new Mock<FakeHttpMessageHandler> { CallBase = true };

            fakeHttpMessageHandler.Setup(x => x.Send(It.IsAny<HttpRequestMessage>()))
                                  .Returns(new HttpResponseMessage(HttpStatusCode.OK)
                                  {
                                      Content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(new Road[] { expected }))
                                  });

            var client = new HttpClient(fakeHttpMessageHandler.Object);

            var roadService = new RoadService(client);

            // Act
            var actual = await roadService.GetRoadStatus("A2");

            // Asset
            fakeHttpMessageHandler.Verify();
            Assert.AreEqual(expected.Text, actual.Result.Text);
        }

        [TestMethod]
        public async Task RoadStatus_GivenInputIsA233_ReturnValidRoadIds()
        {
            // Arrange
            var expected = new RequestError() { Message = "A233" };

            var fakeHttpMessageHandler = new Mock<FakeHttpMessageHandler> { CallBase = true };

            fakeHttpMessageHandler.Setup(x => x.Send(It.IsAny<HttpRequestMessage>()))
                                  .Returns(new HttpResponseMessage(HttpStatusCode.NotFound)
                                  {
                                      Content = new StringContent($"A233 is not a valid road")
                                  });
            var client = new HttpClient(fakeHttpMessageHandler.Object);

            var roadService = new RoadService(client);

            // Act
            var actual = await roadService.GetRoadStatus("A233");

            // Asset
            fakeHttpMessageHandler.Verify();
            Assert.AreEqual(expected.Text, actual.Result.Text);            
        }
    }
}
