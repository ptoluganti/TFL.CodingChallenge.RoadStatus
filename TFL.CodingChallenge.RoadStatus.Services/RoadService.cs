using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using TFL.CodingChallenge.RoadStatus.Services.Models;

namespace TFL.CodingChallenge.RoadStatus.Services
{
    public class RoadService : IRoadService
    {
        private readonly HttpClient httpClient;

        public RoadService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
            this.httpClient.BaseAddress = new Uri("https://api.tfl.gov.uk");
        }

        public async Task<RequestStatus> GetRoadStatus(string road)
        {
            using (HttpResponseMessage response = await httpClient.GetAsync($"/Road/{road}"))
            {
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    return new RequestStatus()
                    {
                        Result = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Road>>(data).First(),
                        ExitCode = 0
                    };
                }

                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    return new RequestStatus()
                    {
                        Result = new RequestError() { Message = road },
                        ExitCode = 1
                    };
                }
                return default;
            }
        }
    }
}
