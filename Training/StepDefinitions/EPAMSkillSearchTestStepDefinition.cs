using NUnit.Framework;
using OpenQA.Selenium;
using Training.Sample.PageObjects;
using Training.Sample.Utilities;

namespace Training.BDD.StepDefinitions
{
    [Binding]
    public class EPAMSkillSearchTestStepDefinition
    {
        private IWebDriver driver;
        private BasePage WebDriver;
        private EPAMHomePage homepage;
        private EPAMSearchPage searchPage;


        [Given(@"I have entered the EPAM home page")]
        public void GivenIHaveEnteredTheEPAMHomePage()
        {
            WebDriver = new BasePage();
            WebDriver.SetDriver("Chrome");

            driver = WebDriver.GetDriver();
            WebDriver.MaximiseDriver();
            WebDriver.GoToUrl("https://www.epam.com/");
        }

        [Given(@"I have navigated to the Search panel")]
        public void GivenIHaveNavigatedToTheSearchPanel()
        {
            homepage = new EPAMHomePage(driver);
            homepage.SearchButton().ClickElement();
        }

        [When(@"I entered the SkillSet to search as (.*)")]
        public void WhenIEnteredTheSkillSetToSearchAsAutomation(string skill)
        {
            searchPage = new EPAMSearchPage(driver);
            searchPage.AcceptCookies().ClickElement();
            searchPage.SearchBox().SendText(skill);
            searchPage.SearchBox().SendText(Keys.Enter);
        }

        [Then(@"The record message of the search result should match the (.*)")]
        public void ThenTheRecordMessageOfTheSearchResultShouldMatchThe(int count)
        {
            searchPage = new EPAMSearchPage(driver);
            string resultCount = searchPage.ResultCount().GetText();
            Assert.That(Int32.Parse(resultCount.Split(' ')[0]), Is.EqualTo(count));
        }

        [Then(@"Close the browser")]
        public void ThenCloseTheBrowser()
        {
            WebDriver.CloseDriver();
        }


    }
}
