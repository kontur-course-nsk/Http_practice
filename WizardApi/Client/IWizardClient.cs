namespace WizardApi.Client
{
    // BaseUrl : https://wizard-world-api.herokuapp.com
    public interface IWizardClient
    {
        // GET /wizards/{id}

        // GET /wizards?firstName={firstName}&lastName={lastName}

        // GET /elixirs/{id}

        // GET /elixirs?ingredient={ingredientName}&inventorFullName={inventorFullName}

        // GET /ingredients/{id}
        Task<Ingredient> GetIngredientAsync(string id);

        // POST /feedback
        // body : FeedbackInfo
    }
}
