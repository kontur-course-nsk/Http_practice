using System;
using System.Threading.Tasks;
using WizardApi.ClientResult;
using WizardApi.Models;

namespace WizardApi.Client
{
    // BaseUrl : https://wizard-world-api.herokuapp.com
    public interface IWizardClient
    {
        // GET /wizards/{id}
        Task<ClientResult<Wizard>> GetWizardAsync(string id);

        // GET /wizards?firstName={firstName}&lastName={lastName}
        Task<ClientResult<Wizard>> GetWizardAsync(string firstName, string lastName);

        // GET /elixirs/{id}
        Task<ClientResult<Elixir>> GetElixirAsync(string id);

        // GET /elixirs?ingredient={ingredientName}&inventorFullName={inventorFullName}
        Task<ClientResult<Elixir[]>> GetElixirAsync(string ingredientName, string inventorFullName);

        // GET /ingredients/{id}
        Task<ClientResult<Ingredient>> GetIngredientAsync(string id);

        // POST /feedback
        // body : FeedbackInfo
        Task<ClientResult<Uri>> CreateFeedbackAsync(FeedbackType feedbackType, string feedback);
    }
}
