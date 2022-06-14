using System.Configuration;
using AventStack.ExtentReports;
using Helpers.Driver;
using Helpers.Json;
using Helpers.Pages;
using Helpers.Reports;
using NUnit.Framework;

namespace Training.BDD.Hooks
{
    [Binding]
    public sealed class UITestHooks : ExtentReportManager
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks
        private BaseDriver DriverInstance = BaseDriver.GetDriverInstance;
        private BasePage _basePage = BasePage.GetInstance;
        ExtentTest test;

        [BeforeScenario("@UITests")]
        public void BeforeScenarioWithTag()
        {
            DriverInstance.SetDriver();
            DriverInstance.MaximiseDriver();
            _basePage.SetWebDriver(DriverInstance.GetDriver());
        }

        [AfterScenario("@UITests")]
        public void AfterScenario()
        {
            DriverInstance.QuitDriver();
        }
    }
}