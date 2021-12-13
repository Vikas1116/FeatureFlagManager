using System.Text.Json.Serialization;

namespace FeatureFlagManager.Models
{
    public class UpdateFeatureRequest
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
}
