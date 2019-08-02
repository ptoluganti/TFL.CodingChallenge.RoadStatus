using System.Threading.Tasks;
using TFL.CodingChallenge.RoadStatus.Services.Models;

namespace TFL.CodingChallenge.RoadStatus.Services
{
    public interface IRoadService
    {
        Task<RequestStatus> GetRoadStatus(string road);
    }
}