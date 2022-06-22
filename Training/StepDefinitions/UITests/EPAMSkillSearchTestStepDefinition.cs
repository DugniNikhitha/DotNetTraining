using Helpers.Driver;
using Helpers.Pages;
using NUnit.Framework;

namespace Training.BDD.StepDefinitions.UITests
{
    [Binding]
    public class EPAMSkillSearchTestStepDefinition 
    {
        private EPAMHomePage epamHome = EPAMHomePage.GetInstance;
        private EPAMSearchPage epamSearch = EPAMSearchPage.GetInstance;

        [Given(@"I have entered the EPAM home page")]
        public void GivenIHaveEnteredTheEPAMHomePage()
        {
            var driver = ScenarioContext.Current.Get<IDriver>("driver");
            driver.GoToUrl();
        }

        [Given(@"I have navigated to the Search panel")]
        public void GivenIHaveNavigatedToTheSearchPanel()
        {
            epamHome.AcceptCookies();
            epamHome.ClickSearch();
        }

        [When(@"I entered the SkillSet to search as")]
        public void WhenIEnteredTheSkillSetToSearchAs(Table table)
        {
            foreach (TableRow row in table.Rows)
            {
                foreach (String value in row.Values)
                {
                    epamSearch.EnterSearchText(value);
                    epamSearch.ClickFind();
                }
            }
        }

        [Then(@"The record message of the search result should match")]
        public void ThenTheRecordMessageOfTheSearchResultShouldMatch(Table table)
        {
            foreach (TableRow row in table.Rows)
            {
                foreach (var value in row.Values)
                {
                    epamSearch.GetResultCount(out string result);
                    //Assert.That(result, Is.EqualTo(value));
                    Assert.That(int.Parse(result.Split(' ')[0]), Is.EqualTo(int.Parse(value)));
                } 
            }
        }
    }
}
