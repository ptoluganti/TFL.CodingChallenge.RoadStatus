using System.Net.Http;
using System.Threading.Tasks;
using TFL.CodingChallenge.RoadStatus.Services.Models;

namespace TFL.CodingChallenge.RoadStatus.Services.Console
{
    class Program
    {
        static async Task<int> Main(string[] args)
        {
            var roadService = new RoadService(new HttpClient());
            RequestStatus requestStatus = await roadService.GetRoadStatus(args[0]);
            System.Console.WriteLine(requestStatus.Result.Text);

            return requestStatus.ExitCode;
        }
    }
}
