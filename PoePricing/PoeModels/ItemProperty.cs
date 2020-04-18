using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PoePricing.PoeModels
{
    public class ItemProperty
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("values")]
        public List<string> Values { get; set; }
    }
}