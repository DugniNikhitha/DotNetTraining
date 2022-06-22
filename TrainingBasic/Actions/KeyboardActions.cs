using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Helpers.Logging;
using OpenQA.Selenium;

namespace Helpers.Actions
{
    public class KeyboardActions : DriverActions
    {
        public void SendText(By selector, string text)
        {
            WaitUntilElementDisplayed(selector).SendKeys(text);
            Logger.PrintLog(new InfoLogger().LogMessage($"Entered the '{text}' to the element '{selector}'"));
        }

        public void ClearText(By selector)
        {
            WaitUntilElementDisplayed(selector).Clear();
            Logger.PrintLog(new InfoLogger().LogMessage($"Cleared the values inside the element '{selector}'"));
        }
    }
}
