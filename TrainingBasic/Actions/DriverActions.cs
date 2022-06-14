using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Helpers.Actions
{
    public class DriverActions 
    {
        public static IWebDriver driver { get; set; }

        public DriverActions()
        {
        }

        public virtual void SetWebDriver(IWebDriver _driver)
        {
            driver = _driver;
        }

        public string GetText(By selector)
        {
            return WaitUntilElementDisplayed(selector).Text;
        }

        public string GetAttributes(By selector, string attribute)
        {
            return WaitUntilElementDisplayed(selector).GetAttribute(attribute);
        }

        public virtual bool GetPresenceOfElement(By selector)
        {
            bool result = driver.FindElement(selector).Displayed;
            return result;
        }

        public void GetText(By selector, out List<string> list)
        {
            WaitUntilElementDisplayed(selector);
            list = driver.FindElements(selector)
                .Select(e => e.Text).ToList();
        }

        public void GetAttributes(By selector, string attribute, out List<string> list)
        {
            WaitUntilElementDisplayed(selector);
            list = driver.FindElements(selector)
                .Select(e => e.GetAttribute(attribute)).ToList();
        }

        protected virtual IWebElement WaitUntilElementDisplayed(By selector)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(selector));
            return element;
        }

        protected virtual IWebElement WaitUntilElementClickable(By selector)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(selector));
            return element;
        }
    }
}
