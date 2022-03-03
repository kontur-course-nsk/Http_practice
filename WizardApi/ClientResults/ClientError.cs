using System.Text.Json.Serialization;

namespace WizardApi.ClientResults
{
    public sealed class ClientError
    {
        public override string ToString()
        {
            return base.ToString();
        }
    }

    public sealed class ErrorIds
    {
        [JsonPropertyName("id")]
        public string[] Ids { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
