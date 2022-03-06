using System;
using System.Threading.Tasks;
using WizardApi.Client;
using WizardApi.Service;

namespace WizardApi
{
    public sealed class Program
    {
        public static async Task Main()
        {
            var client = new WizardClient();
            var service = new WizardService(client);

            var ingredient = await client.GetIngredientAsync("not guid");
            var wizard = await client.GetWizardAsync("de736ba2-3a67-4bce-b451-f40bac39fd03");
        }
    }
}
