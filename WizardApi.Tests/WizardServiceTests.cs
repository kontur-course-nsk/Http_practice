using System;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using WizardApi.Client;
using WizardApi.Service;

namespace WizardApi.Tests
{
    [TestFixture]
    public sealed class WizardServiceTests
    {
        private IWizardService wizardService;

        [OneTimeSetUp]
        public void SetUp()
        {
            this.wizardService = new WizardService(new WizardClient());
        }

        [TestCase(TestData.PearlDust, 7)]
        [TestCase(TestData.MandrakeRoot, 2)]
        public async Task CountIngredientUsagesTest(string ingredientId, int expectedResult)
        {
            var actualResult = await this.wizardService.CountIngredientUsagesAsync(ingredientId);

            actualResult.Should().Be(expectedResult);
        }

        [TestCase(TestData.GeorgeWeasley, 6)]
        [TestCase(TestData.ZygmuntBudge, 26)]
        public async Task CountWizardIngredientsTest(string wizardId, int expectedResult)
        {
            var actualResult = await this.wizardService.CountWizardIngredientsAsync(new Guid(wizardId));

            actualResult.Should().Be(expectedResult);
        }

        [TestCase(TestData.LovePotion, 8)]
        [TestCase(TestData.Doxycide, 4)]
        public async Task CountElixirInventorsElixirsTest(string elixirId, int expectedResult)
        {
            var actualResult = await this.wizardService.CountElixirInventorsElixirsAsync(new Guid(elixirId));

            actualResult.Should().Be(expectedResult);
        }

        //[TestCase(TestData.BadIngredientId, 400, TestData.BadIngredientIdMessage)]
        //[TestCase(TestData.UnknownIngredientId, 404, TestData.UnknownIngredientMessage)]
        ////public async Task CountBadOrUnknownIngredientUsagesShouldThrowTest(string ingredientId, int statusCode, string message, string errorId = null)
        //{
        //    Func<Task> act = async () => await this.wizardService.CountIngredientUsagesAsync(ingredientId);

        //    (await act.Should().ThrowAsync<ClientException>())
        //        .Where(x => x.StatusCode == statusCode && x.Message.Contains(message));
        //}

        //[TestCase(TestData.UnknownWizard, 0)]
        //public async Task CountUnknownWizardIngredientsTest(string wizardId, int expectedResult)
        //{
        //    var actualResult = await this.wizardService.CountWizardIngredientsAsync(new Guid(wizardId));

        //    actualResult.Should().Be(expectedResult);
        //}

        //[TestCase(TestData.UnknownPotion, 0)]
        //public async Task CountUnknownElixirInventorsElixirsTest(string wizardId, int expectedResult)
        //{
        //    var actualResult = await this.wizardService.CountWizardIngredientsAsync(new Guid(wizardId));

        //    actualResult.Should().Be(expectedResult);
        //}
    }
}
