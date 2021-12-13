using System.Text.Json.Serialization;

namespace FeatureFlagManager.Models
{
    public class DeleteFeatureRequest
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("enabled")]
        public bool Enabled { get; set; }
    }
}
