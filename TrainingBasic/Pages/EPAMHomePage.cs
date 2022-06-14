using System;
using Helpers.Driver;
using OpenQA.Selenium;

namespace Helpers.Pages
{
    public sealed class EPAMHomePage
    {
        //Locators 
        By searchButton = By.XPath("//button[contains(@class, 'header-search__button')]");
        By acceptCookiesButton = By.XPath("//button[text()='Accept All']");

        //Singleton Pattern 
        private static Lazy<EPAMHomePage> _epamHome = new Lazy<EPAMHomePage>(() => new EPAMHomePage());
        private static BasePage _basePage;

        public static EPAMHomePage GetInstance
        {
            get
            {
                return _epamHome.Value;
            }
        }

        private EPAMHomePage()
        {
            Console.WriteLine("EPAM HOME PAGE");
            _basePage = BasePage.GetInstance;
        }

        //Utility methods
        public EPAMHomePage ClickSearch()
        {
            _basePage.mouseAction.ClickElement(searchButton);
            return this;
        }

        public EPAMHomePage AcceptCookies()
        {
            _basePage.mouseAction.ClickElement(acceptCookiesButton);
            return this;
        }

        public EPAMHomePage GetPresenceOfSearch(out bool isPresent)
        {
            isPresent = _basePage.GetPresenceOfElement(searchButton);
            return this;
        }

    }
   
}
