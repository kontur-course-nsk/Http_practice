using System.Text.Json.Serialization;

namespace WizardApi.Models
{
    public sealed class Ingredient
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
