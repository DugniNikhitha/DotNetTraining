using System;
using Helpers.Actions;
using OpenQA.Selenium;

namespace Helpers.Pages
{
    public sealed class BasePage : DriverActions
    {
        public KeyboardActions keysAction = new KeyboardActions();
        public MouseActions mouseAction = new MouseActions();
        private static Lazy<BasePage> _basePage = new Lazy<BasePage>(() => new BasePage());

        public static BasePage GetInstance 
        { get 
            { 
                return _basePage.Value; 
            } 
        }

        private BasePage()
        {
            Console.WriteLine("EPAM BASE PAGE");
        }

        public override void SetWebDriver(IWebDriver _driver)
        {
            driver = _driver;
        }

    }
}
