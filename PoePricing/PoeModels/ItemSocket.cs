using System.Text.Json.Serialization;

namespace PoePricing.PoeModels
{
    public class ItemSocket
    {
        [JsonPropertyName("group")]
        public int Group { get; set; }

        [JsonPropertyName("attr")]
        public string Attribute { get; set; }

        [JsonPropertyName("sColour")]
        public string SocketColor { get; set; }
    }
}