using System;
using System.Configuration;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using Helpers.Driver;
using Helpers.Json;
using Helpers.Pages;
using Helpers.Reports;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Training.BDD.Hooks
{
    [Binding]
    public sealed class UITestHooks : ReportManager
    {
        static IDriver driver;
        IWebDriver webDriver;

        DriverFactory driverFactory = new DriverFactory();
        private BasePage _basePage = BasePage.GetInstance;

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            InitialiseReport();
        }

        [BeforeFeature]
        public static void BeforeFeature()
        {
            FeatureName();
        }

        [BeforeScenario("@UITests")]
        public void BeforeScenarioWithTag()
        {
            Console.WriteLine("Before Scenario");

            driver = driverFactory.GetDriverType();
            driver.SetDriver();
            webDriver = driver.GetDriver();
            driver.MaximiseDriver();
            _basePage.SetWebDriver(webDriver);

            ScenarioContext.Current.Add("driver", driver);
            SetScenario();
        }

        [BeforeStep]
        public void BeforeStep()
        {
            Console.WriteLine("Step has started");
        }

        [AfterStep]
        public void InsertReportingSteps()
        {
            ReportTearDown();
            Console.WriteLine("Step has ended");
        }

        [AfterScenario]
        public void AfterScenario()
        {
            Console.WriteLine("AfterScenario");
            TestResult();
            driver.CloseDriver();
        }

        [AfterFeature]
        public static void AfterFeature()
        {
            Console.WriteLine("Feature has ended");
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            FlushReport();
        }
    }
}