namespace TFL.CodingChallenge.RoadStatus.Services.Models
{
    public class RequestError : IResult
    {

        public string Message { get; set; }

        public string Text => $"{this.Message} is not a valid road";
    }
}
