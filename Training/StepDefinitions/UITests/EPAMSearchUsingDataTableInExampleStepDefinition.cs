using Helpers.Driver;
using Helpers.Pages;
using Helpers.Reports;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Training.BDD.StepDefinitions.UITests
{
    [Binding]
    
    public class EPAMSearchUsingDataTableInExampleStepDefinition
    {
        private EPAMHomePage epamHome = EPAMHomePage.GetInstance;
        private EPAMSearchPage epamSearch = EPAMSearchPage.GetInstance;
        private BaseDriver DriverInstance = BaseDriver.GetDriverInstance;

        [Given(@"I have entered the EPAM home")]
        public void GivenIHaveEnteredTheEPAMHome()
        {
            DriverInstance.GoToUrl();
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
            //Assert.That(result, Is.EqualTo(count));
            Assert.That(int.Parse(result.Split(' ')[0]), Is.EqualTo(count));
        }

    }
}
