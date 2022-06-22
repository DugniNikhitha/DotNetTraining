using Helpers.Driver;
using Helpers.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;

namespace Helpers.Drivers
{
    public sealed class Firefox : IDriver
    {
        private IWebDriver driver;
        JsonReader js = new JsonReader();

        private static Lazy<Firefox> DriverInstance = new Lazy<Firefox>(()=> new Firefox());

        public static Firefox GetDriverInstance
        {
            get { return Firefox.DriverInstance.Value; }
        }

        public Firefox()
        {
        }

        public IWebDriver GetDriver()
        {
            return driver;
        }

        public void SetDriver(IWebDriver driver = null)
        {
            this.driver = (driver != null) ? driver : new FirefoxDriver(Directory.GetCurrentDirectory());
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
