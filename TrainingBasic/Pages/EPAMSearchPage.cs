using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Helpers.Pages
{
    public sealed class EPAMSearchPage
    {
        //Locators 
        By searchCombo = By.Id("new_form_search");
        By homeButton = By.ClassName("header__logo");
        By findButton = By.CssSelector(".header-search__submit");
        By resultCount = By.ClassName("search-results__counter");

        //Singleton Pattern
        private static Lazy<EPAMSearchPage> _epamSearch = new Lazy<EPAMSearchPage>(() => new EPAMSearchPage());
        private static BasePage _basePage;

        public static EPAMSearchPage GetInstance
        {
            get 
            { 
                return _epamSearch.Value; 
            }
        }

        private EPAMSearchPage()
        {
            Console.WriteLine("EPAM SEARCH PAGE");
            _basePage = BasePage.GetInstance;
        }

        //Utility Methods 
        public EPAMSearchPage EnterSearchText(string searchText)
        {
            _basePage.keysAction.SendText(searchCombo, searchText);
            return this;
        }

        public EPAMHomePage GoToHome()
        {
            _basePage.mouseAction.ClickElement(homeButton);
            return EPAMHomePage.GetInstance;
        }

        public EPAMSearchPage ClickFind()
        {
            _basePage.mouseAction.ClickElement(findButton);
            return this;
        }

        public EPAMSearchPage GetResultCount(out string result)
        {
            result = _basePage.GetText(resultCount);
            return this;
        }
    }
}
