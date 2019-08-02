using Newtonsoft.Json;

namespace TFL.CodingChallenge.RoadStatus.Services.Models
{
    public class Road : IResult
    {
        [JsonProperty("id")] public string Id { get; set; }

        [JsonProperty("displayName")] public string DisplayName { get; set; }

        [JsonProperty("statusSeverity")] public string StatusSeverity { get; set; }

        [JsonProperty("statusSeverityDescription")] public string StatusSeverityDescription { get; set; }

        public string Text => $@"The status of the {this.DisplayName} is as follows
        Road Status is {this.StatusSeverity}
        Road Status Description is {StatusSeverityDescription}";
    }
}
