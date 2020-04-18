using System.Text.Json.Serialization;

namespace PoePricing.PoeModels
{
    public class Tab
    {
        [JsonPropertyName("n")]
        public string Name { get; set; }

        [JsonPropertyName("i")]
        public int Index { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }
    }
}