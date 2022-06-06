using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace Training.Sample.Utilities
{
    public class BasePage : IDriver
    {
        private IWebDriver driver;
        public BasePage()
        {

        }
        public IWebDriver GetDriver()
        {
            return driver;
        }

        public void SetDriver(string browserName)
        {
            switch (browserName)
            {
                case "Firefox":
                    driver = new FirefoxDriver();
                    break;

                case "Chrome":
                    driver = new ChromeDriver();
                    break;

                case "Edge":
                    driver = new EdgeDriver();
                    break;

                case null:
                    Console.WriteLine("Enter the valid browser");
                    break;
            }
        }

        public void GoToUrl(string url)
        {
            driver.Navigate().GoToUrl(url);
        }
        public void MaximiseDriver()
        {
            driver.Manage().Window.Maximize();
        }
        public void MinimiseDriver()
        {
            driver.Manage().Window.Minimize();
        }
        public void RefreshDriver()
        {
            driver.Navigate().Refresh();
        }
        public void GoBackDriver()
        {
            driver.Navigate().Back();
        }
        public void GoForwardDriver()
        {
            driver.Navigate().Forward();
        }
        public void ImplicitWait(int timeInSec)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeInSec);
        }
        public void CloseDriver()
        {
            driver.Close();
        }
        public void QuitDriver()
        {
            driver.Quit();
        }
    }
}
