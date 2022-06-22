using System;
using System.Collections.Generic;
using System.Linq;
using Helpers.Logging;
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
            bool result = false;
            try
            {
                result = driver.FindElement(selector).Displayed;
                Logger.PrintLog(new InfoLogger().LogMessage($"Element '{selector}' is present"));
            }
            catch(NoSuchElementException)
            {
                Logger.PrintLog(new ErrorLogger().LogMessage($"Element '{selector}' is present"));
            }
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
            IWebElement element = null;
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(selector));
                Logger.PrintLog(new InfoLogger().LogMessage($"Element '{selector}' is displayed"));
            }
            catch(TimeoutException)
            {
                Logger.PrintLog(new ErrorLogger().LogMessage($"Element '{selector}' is not displayed"));
            }
            return element;
        }

        protected virtual IWebElement WaitUntilElementClickable(By selector)
        {
            IWebElement element = null;
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(selector));
                Logger.PrintLog(new InfoLogger().LogMessage($"Element '{selector}' is clickable"));
            }
            catch(TimeoutException)
            {
                Logger.PrintLog(new ErrorLogger().LogMessage($"Element '{selector}' is not clickable"));
            }

            return element;
        }
    }
}
