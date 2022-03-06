using System;
using System.Threading.Tasks;
using WizardApi.Client;
using System.Linq;
using System.Collections.Generic;

namespace WizardApi.Service
{
    public sealed class WizardService : IWizardService
    {
        private readonly IWizardClient wizardClient;

        public WizardService(IWizardClient wizardClient)
        {
            this.wizardClient = wizardClient;
        }

        // Этот метод принимает на вход идентификатор ингредиента,
        // а должен вернуть количество разных эликсиров,
        // в приготовлении которого этот ингредиент участвует
        public async Task<int> CountIngredientUsagesAsync(string ingredientId)
        {
            var ingredientResult = await wizardClient.GetIngredientAsync(ingredientId);
            ingredientResult.EnsureSuccess();
            var ingredientName = ingredientResult.Response.Name;

            var elixirsResult = await wizardClient.GetElixirAsync(ingredientName, "");
            elixirsResult.EnsureSuccess();
            var elixirs = elixirsResult.Response;

            return elixirs.Length;
        }

        // Этот метод принимает на вход идентификатор волшебника,
        // а должен вернуть количество разных ингредиентов,
        // которые использует этот волшебник в рецептах своих эликсиров
        public async Task<int> CountWizardIngredientsAsync(Guid wizardId)
        {
            var wizardResult = await wizardClient.GetWizardAsync(wizardId.ToString());
            if (!wizardResult.IsSuccessful())
                return 0;
            var wizard = wizardResult.Response;

            if (wizard.Elixirs.Length == 0)
                return 0;

            var elixirs = new List<Models.Elixir>();
            foreach (var elixir in wizard.Elixirs)
            {
                var elixirResult = await wizardClient.GetElixirAsync(elixir.Id);
                if (!elixirResult.IsSuccessful())
                    return 0;
                elixirs.Add(elixirResult.Response);
            }

            var ingredients = elixirs
                .SelectMany(e => e.Ingredients
                    .Select(i => i.Name))
                .Distinct();
            return ingredients.Count();
        }

        // Хитрый метод! На входе - идентификатор эликсира.
        // Нужно посчитать, сколько различных эликсиров придумали
        // изобретатели входного эликсира
        public async Task<int> CountElixirInventorsElixirsAsync(Guid elixirId)
        {
            var elixirResult = await wizardClient.GetElixirAsync(elixirId.ToString());
            if (!elixirResult.IsSuccessful())
                return 0;
            var elixir = elixirResult.Response;

            var elixirsGroupedByWizard = new List<Models.Elixir[]>();
            foreach (var wizard in elixir.Inventors)
            {
                var inventedElixirsResult = await wizardClient.GetElixirAsync("",
                    $"{wizard.FirstName} {wizard.LastName}");
                if (!inventedElixirsResult.IsSuccessful())
                    return 0;
                elixirsGroupedByWizard.Add(inventedElixirsResult.Response);
            }

            var elixirsNames = elixirsGroupedByWizard
                .SelectMany(l => l)
                .Select(e => e.Name)
                .Distinct();

            return elixirsNames.Count();
        }
    }
}
