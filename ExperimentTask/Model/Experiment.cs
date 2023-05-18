using System.Text.Json.Serialization;

namespace ExperimentTask.Model
{
    public class Experiment
    {
        public string? Id { get; set; }
        public string? Key { get; set; }
        public int Count { get; set; }
        
        public string? Options { get; set; }
        [JsonIgnore]
        public ICollection<Device>? Devices { get; set; }

    }
}
