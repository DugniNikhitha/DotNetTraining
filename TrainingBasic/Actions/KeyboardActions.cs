using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Helpers.Actions
{
    public class KeyboardActions : DriverActions
    {
        public void SendText(By selector, string text)
        {
            WaitUntilElementDisplayed(selector).SendKeys(text);
        }

        public void ClearText(By selector)
        {
            WaitUntilElementDisplayed(selector).Clear();
        }
    }
}
