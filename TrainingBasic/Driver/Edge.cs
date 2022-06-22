using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Edge;
using Helpers.Driver;
using Helpers.Json;

namespace Helpers.Drivers
{
    public sealed class Edge : IDriver
    {
        private IWebDriver driver;
        JsonReader js = new JsonReader();

        private static Lazy<Edge> DriverInstance = new Lazy<Edge>(() => new Edge());

        public static Edge GetDriverInstance
        {
            get { return DriverInstance.Value; }
        }

        private Edge()
        {
        }
        public void CloseDriver()
        {
            driver.Close();
            driver.Quit();
        }

        public IWebDriver GetDriver()
        {
            return driver;
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

        public void SetDriver(IWebDriver driver = null)
        {
            this.driver = (driver != null) ? driver : new EdgeDriver();
        }
    }
}
