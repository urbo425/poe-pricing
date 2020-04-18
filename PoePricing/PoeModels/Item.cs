using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PoePricing.PoeModels
{
    public class Item
    {
        // [JsonPropertyName("id")]
        // public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("typeLine")]
        public string TypeLine { get; set; }

        [JsonPropertyName("icon")]
        public string Icon { get; set; }

        [JsonPropertyName("implicitMods")] 
        public List<string> ImplicitMods { get; set; } = new List<string>();

        [JsonPropertyName("explicitMods")]
        public List<string> ExplicitMods { get; set; } = new List<string>();

        // [JsonPropertyName("w")]
        // public int Width { get; set; }
        //
        // [JsonPropertyName("h")]
        // public int Height { get; set; }

        // [JsonPropertyName("league")]
        // public string League { get; set; }
        //
        // [JsonPropertyName("identified")]
        // public bool Identified { get; set; }
        //
        // [JsonPropertyName("ilvl")]
        // public int ItemLevel { get; set; }
        //
        // [JsonPropertyName("sockets")]
        // public List<ItemSocket> ItemSockets { get; set; }
        //
        // [JsonPropertyName("properties")]
        // public List<ItemProperty> Properties { get; set; }
        //
        // [JsonPropertyName("requirements")]
        // public List<ItemProperty> Requirements { get; set; }

        // [JsonPropertyName("implicitMods")]
        // public List<string> ImplicitMods { get; set; }
        //
        // [JsonPropertyName("explicitMods")]
        // public List<string> ExplicitMods { get; set; }
    }
}