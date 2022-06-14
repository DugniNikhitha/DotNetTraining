using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Helpers.Actions
{
    public class MouseActions : DriverActions
    {
        OpenQA.Selenium.Interactions.Actions Action;

        public void ClickElement(By selector)
        {
            WaitUntilElementDisplayed(selector).Click();
        }

        public void MoveToElement(By selector)
        {
            Action = new OpenQA.Selenium.Interactions.Actions(driver);
            Action.MoveToElement(driver.FindElement(selector)).Perform();
        }

        public void MouseHover(By selector)
        {
            WaitUntilElementDisplayed(selector);
            MoveToElement(selector);
        }

        public void RightClick(By selector)
        {
            Action = new OpenQA.Selenium.Interactions.Actions(driver);
            Action.ContextClick(driver.FindElement(selector)).Perform();
        }
    }
}
