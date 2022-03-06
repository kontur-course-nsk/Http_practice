using System.Text.Json.Serialization;

namespace WizardApi.Models
{
    public sealed class Wizard
    {
        [JsonPropertyName("elixirs")]
        public Elixir[] Elixirs { get; set; }
        
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }

        [JsonPropertyName("lastName")]
        public string LastName { get; set; }
    }
}
