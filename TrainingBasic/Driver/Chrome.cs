using Helpers.Driver;
using Helpers.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

namespace Helpers.Drivers
{
    public sealed class Chrome : IDriver
    {
        private IWebDriver driver;
        JsonReader js = new JsonReader();
        private static Lazy<Chrome> DriverInstance = new Lazy<Chrome>(()=> new Chrome());

        public static Chrome GetDriverInstance 
        {
            get { return DriverInstance.Value; }
        }

        private Chrome()
        {
        }

        public IWebDriver GetDriver()
        {
            return driver;
        }

        public void SetDriver(IWebDriver driver = null)
        {
            this.driver = (driver != null) ? driver : new ChromeDriver();
        }

        public void MaximiseDriver()
        {
            driver.Manage().Window.Maximize();
        }

        public void MinimiseDriver()
        {
            driver.Manage().Window.Minimize();
        }

        public void GoToUrl()
        {
            js.extractData();
            string url = js.property.url;
            driver.Navigate().GoToUrl(url);
        }

        public void CloseDriver()
        {
            driver.Close();
            driver.Quit();
        }
    }
}
