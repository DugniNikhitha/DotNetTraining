using Helpers.Driver;
using Helpers.Pages;
using NUnit.Framework;

namespace Training.BDD.StepDefinitions.UITests
{
    [Binding]
    
    public class EPAMSearchUsingDataTableInExampleStepDefinition
    {
        private EPAMHomePage epamHome = EPAMHomePage.GetInstance;
        private EPAMSearchPage epamSearch = EPAMSearchPage.GetInstance;

        [Given(@"I have entered the EPAM home")]
        public void GivenIHaveEnteredTheEPAMHome()
        {
            var driver = ScenarioContext.Current.Get<IDriver>("driver");
            driver.GoToUrl();
        }

        [Given(@"I have navigated to the Search combo")]
        public void GivenIHaveNavigatedToTheSearchCombo()
        {
            //EPAMHomePage.GetInstance.AcceptCookies(); Follow this for all pages 
            epamHome.AcceptCookies();
            epamHome.ClickSearch();
        }

        [When(@"I entered the SkillSet to search as (.*)")]
        public void WhenIEnteredTheSkillSetToSearchAsAutomation(string skill)
        {
            epamSearch.EnterSearchText(skill);
            epamSearch.ClickFind();
        }

        [Then(@"The record message of the search result should match the (.*)")]
        public void ThenTheRecordMessageOfTheSearchResultShouldMatchThe(int count)
        {
            epamSearch.GetResultCount(out string result);
            Assert.That(int.Parse(result.Split(' ')[0]), Is.EqualTo(count));
        }

    }
}
