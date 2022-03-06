using System;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using WizardApi.ClientResult;
using WizardApi.Models;

namespace WizardApi.Client
{
    public sealed class WizardClient : IWizardClient
    {
        private readonly HttpClient httpClient;
        private readonly JsonSerializerOptions options;

        public WizardClient()
        {
            httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://wizard-world-api.herokuapp.com/")
            };

            options = new JsonSerializerOptions
            {
                Converters =
                {
                    new JsonStringEnumConverter(JsonNamingPolicy.CamelCase)
                }
            };
        }

        public async Task<ClientResult<Uri>> CreateFeedbackAsync(FeedbackType feedbackType, string feedback)
        {
            var feedbackInfo = new FeedbackInfo()
            {
                Feedback = feedback,
                Type = Enum.GetName(typeof(FeedbackInfo), feedbackType)
            };
            var stringContent = new StringContent(JsonSerializer.Serialize(feedbackInfo, typeof(FeedbackInfo)));

            HttpResponseMessage response = await httpClient.PostAsync($"feedback/", stringContent);
            response.EnsureSuccessStatusCode();

            if (response.IsSuccessStatusCode)
                return new ClientResult<Uri>((int)response.StatusCode, response.Headers.Location);
            else
                return new ClientResult<Uri>((int)response.StatusCode, 
                                             JsonSerializer.Deserialize<ClientError>(await response.Content.ReadAsStringAsync()));
        }

        public async Task<ClientResult<Elixir>> GetElixirAsync(string id)
        {
            var response = await httpClient.GetAsync($"elixirs/{id}");
            var content = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
                return new ClientResult<Elixir>((int)response.StatusCode, JsonSerializer.Deserialize<Elixir>(content, options));
            else
                return new ClientResult<Elixir>((int)response.StatusCode, JsonSerializer.Deserialize<ClientError>(content));
        }

        public async Task<ClientResult<Elixir[]>> GetElixirAsync(string ingredientName, string inventorFullName)
        {
            var response = await httpClient.GetAsync($"elixirs?ingredient={ingredientName}&inventorFullName={inventorFullName}");
            var content = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
                return new ClientResult<Elixir[]>((int)response.StatusCode, JsonSerializer.Deserialize<Elixir[]>(content, options));
            else
                return new ClientResult<Elixir[]>((int)response.StatusCode, JsonSerializer.Deserialize<ClientError>(content));
        }

        public async Task<ClientResult<Ingredient>> GetIngredientAsync(string id)
        {
            var response = await httpClient.GetAsync($"ingredients/{id}");
            var content = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
                return new ClientResult<Ingredient>((int)response.StatusCode, JsonSerializer.Deserialize<Ingredient>(content));
            else
                return new ClientResult<Ingredient>((int)response.StatusCode, JsonSerializer.Deserialize<ClientError>(content));
        }

        public async Task<ClientResult<Wizard>> GetWizardAsync(string id)
        {
            var response = await httpClient.GetAsync($"wizards/{id}");
            var content = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
                return new ClientResult<Wizard>((int)response.StatusCode, JsonSerializer.Deserialize<Wizard>(content));
            else
                return new ClientResult<Wizard>((int)response.StatusCode, JsonSerializer.Deserialize<ClientError>(content));
        }

        public async Task<ClientResult<Wizard>> GetWizardAsync(string firstName, string lastName)
        {
            var response = await httpClient.GetAsync($"wizards?firstName={firstName}&lastName={lastName}");
            var content = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
                return new ClientResult<Wizard>((int)response.StatusCode, JsonSerializer.Deserialize<Wizard>(content));
            else
                return new ClientResult<Wizard>((int)response.StatusCode, JsonSerializer.Deserialize<ClientError>(content));
        }
    }
}
