using System;
using System.Threading.Tasks;
using WizardApi.Client;

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
        public Task<int> CountIngredientUsagesAsync(string ingredientId)
        {
            throw new NotImplementedException();
        }

        // Этот метод принимает на вход идентификатор волшебника,
        // а должен вернуть количество разных ингредиентов,
        // которые использует этот волшебник в рецептах своих эликсиров
        public Task<int> CountWizardIngredientsAsync(Guid wizardId)
        {
            throw new NotImplementedException();
        }

        // Хитрый метод! На входе - идентификатор эликсира.
        // Нужно посчитать, сколько различных эликсиров придумали
        // изобретатели входного эликсира
        public Task<int> CountElixirInventorsElixirsAsync(Guid elixirId)
        {
            throw new NotImplementedException();
        }
    }
}
