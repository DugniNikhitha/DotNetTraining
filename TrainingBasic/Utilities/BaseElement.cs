
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace Training.Sample.Utilities
{
    public class BaseElement
    {
        private IWebElement webElement;
        private IWebDriver driver;


        public BaseElement(IWebDriver driver, By selector)
        {
            this.driver = driver;
            webElement = FindElement(selector);
        }
        protected virtual IWebElement FindElement(By selector)
        {
            return new WebDriverWait(driver, new TimeSpan(0, 0, 10))
            .Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(selector));
        }

        protected void MoveToElement(By selector)
        {
            Actions action = new Actions(driver);
            action.MoveToElement(FindElement(selector));
            action.Perform();
        }

        public void ClickElement()
        {
            webElement.Click();
        }

        public void SendText(string text)
        {
            webElement.SendKeys(text);
        }

        public string GetText()
        {
            return webElement.Text;
        }

        public object GetAttribute(string attributeName)
        {
            return webElement.GetAttribute(attributeName);
        }

        public void ClearText()
        {
            webElement.Clear();
        }



       

    }
}
