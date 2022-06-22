using Helpers.Drivers;
using Helpers.Json;
using Helpers.Logging;
using OpenQA.Selenium;

namespace Helpers.Driver
{
    public class DriverFactory
    {
        private IDriver driver;
        JsonReader js = new JsonReader();

        public IDriver GetDriverType()
        {
            js.extractData();
            string browserName = js.property.browser;
            switch (browserName)
            {
                case "Firefox":
                    driver = Firefox.GetDriverInstance;
                    break;

                case "Chrome":
                    driver = Chrome.GetDriverInstance;
                    break;

                case "Edge":
                    driver = Edge.GetDriverInstance;
                    break;

                default:
                    Logger.PrintLog(new InfoLogger().LogMessage("Enter the valid browser"));
                    break;
            }
            return driver;
        }
    }
}
