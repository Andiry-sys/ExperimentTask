using System.Text.Json.Serialization;

namespace ExperimentTask.Model
{
    public class Device
    {
        public string? Id { get; set; }
        public string? DeviceToken { get; set; }

        public string? ExperimentId { get; set; }
        [JsonIgnore]
        public Experiment? Experiment { get; set; }
    }
}
