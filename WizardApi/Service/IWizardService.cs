using System;
using System.Threading.Tasks;

namespace WizardApi.Service
{
    public interface IWizardService
    {
        Task<int> CountIngredientUsagesAsync(string ingredientId);

        Task<int> CountWizardIngredientsAsync(Guid wizardId);

        Task<int> CountElixirInventorsElixirsAsync(Guid elixirId);
    }
}
