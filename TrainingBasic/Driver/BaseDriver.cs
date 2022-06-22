//using System;
//using Helpers.Json;
//using OpenQA.Selenium;
//using OpenQA.Selenium.Chrome;
//using OpenQA.Selenium.Edge;
//using OpenQA.Selenium.Firefox;

//namespace Helpers.Driver
//{
//    public class BaseDriver : IDriver
//    {
//        public string browserName;
//        private IWebDriver driver;
//        private static Lazy<BaseDriver> DriverInstance = new Lazy<BaseDriver>(() => new BaseDriver());
//        JsonReader js = new JsonReader();

//        public static BaseDriver GetDriverInstance
//        {
//            get 
//            { 
//                return DriverInstance.Value; 
//            }
//        }

//        public BaseDriver()
//        {
           
//        }
//        public IWebDriver GetDriver()
//        {
//            return driver;
//        }
        
//        public void SetDriver()
//        {
//            js.extractData();
//            string browserName = js.property.browser;
//            switch (browserName)
//            {
//                case "Firefox":
//                    driver = new FirefoxDriver();
//                    break;

//                case "Chrome":
//                    driver = new ChromeDriver();
//                    break;

//                case "Edge":
//                    driver = new EdgeDriver();
//                    break;

//                case null:
//                    Console.WriteLine("Enter the valid browser");
//                    break;
//            }
//        }

//        public void GoToUrl()
//        {
//            string url = js.property.url;
//            driver.Navigate().GoToUrl(url);
//        }
//        public void MaximiseDriver()
//        {
//            driver.Manage().Window.Maximize();
//        }
//        public void MinimiseDriver()
//        {
//            driver.Manage().Window.Minimize();
//        }
//        public void RefreshDriver()
//        {
//            driver.Navigate().Refresh();
//        }
//        public void GoBackDriver()
//        {
//            driver.Navigate().Back();
//        }
//        public void GoForwardDriver()
//        {
//            driver.Navigate().Forward();
//        }
//        public void ImplicitWait(int timeInSec)
//        {
//            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeInSec);
//        }
//        public void CloseDriver()
//        {
//            driver.Close();
//        }
//        public void QuitDriver()
//        {
//            driver.Quit();
//        }
//    }
//}
