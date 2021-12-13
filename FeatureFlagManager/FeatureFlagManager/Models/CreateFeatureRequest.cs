using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace FeatureFlagManager.Models
{
    public class CreateFeatureRequest
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("enabled")]
        public bool Enabled { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
        [JsonPropertyName("conditions")]
        public Condition Conditions { get; set; }
    }

    public class Condition
    {
        [JsonPropertyName("client_filters")]
        public List<Client_Filter> Client_filters { get; set; }
    }

    public class Client_Filter
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("parameters")]
        public Dictionary<string, string> Parameters { get; set; }
    }
}
