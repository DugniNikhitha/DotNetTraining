using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Helpers.Logging;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Helpers.Actions
{
    public class MouseActions : DriverActions
    {
        OpenQA.Selenium.Interactions.Actions Action;

        public void ClickElement(By selector)
        {
            try
            {
                WaitUntilElementDisplayed(selector).Click();
                Logger.PrintLog(new InfoLogger().LogMessage($"Clicked on the element '{selector}'"));
            }
            catch(ElementClickInterceptedException e)
            {
                Logger.PrintLog(new ErrorLogger().LogMessage(e.ToString()));

            }
        }

        public void MoveToElement(By selector)
        {
            try
            {
                Action = new OpenQA.Selenium.Interactions.Actions(driver);
                Action.MoveToElement(driver.FindElement(selector)).Perform();
                Logger.PrintLog(new InfoLogger().LogMessage($"Moved to the element '{selector}'"));
            }
            catch(Exception e)
            {
                Logger.PrintLog(new ErrorLogger().LogMessage(e.ToString()));
            }
        }

        public void MouseHover(By selector)
        {
            try
            {
                WaitUntilElementDisplayed(selector);
                MoveToElement(selector);
                Logger.PrintLog(new InfoLogger().LogMessage($"Mouse hovered on the element '{selector}'"));
            }
            catch (Exception e)
            {
                Logger.PrintLog(new ErrorLogger().LogMessage(e.ToString()));
            }
        }

        public void RightClick(By selector)
        {
            try
            {
                Action = new OpenQA.Selenium.Interactions.Actions(driver);
                Action.ContextClick(driver.FindElement(selector)).Perform();
                Logger.PrintLog(new InfoLogger().LogMessage($"Right clicked on the element '{selector}'"));
            }
            catch (Exception e)
            {
                Logger.PrintLog(new ErrorLogger().LogMessage(e.ToString()));
            }
        }
    }
}
