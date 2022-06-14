using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Helpers.Driver;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.IO;
using System.Reflection;
using TechTalk.SpecFlow;

namespace Helpers.Reports
{
    public class ExtentReportManager
    {
        public static ExtentReports extent;
        public static ExtentTest test;
        private BaseDriver DriverInstance = BaseDriver.GetDriverInstance;

        [BeforeScenario]
        public void StartReport()
        {
            //sets the full path of current working directory - Utilities
            String workingDirectory = Environment.CurrentDirectory;

            //Go one step back to get the parent of it - project
            String projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;

            //To generate file in the parent folder
            String reportPath = projectDirectory + "\\index.html";

            //path where file should be generated
            var htmlReporter = new ExtentHtmlReporter(reportPath);

            //pass of object of reporter 
            //giving knowledge to parent where excatly the html report is present
            //Create object or else null exception will be thrown
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
            extent.AddSystemInfo("Host Name", "Local Host");
            extent.AddSystemInfo("Environment", "QA");
            extent.AddSystemInfo("Username", "Dugni Nikhitha");

            test = extent.CreateTest(ScenarioContext.Current.ScenarioInfo.Title);
        }

        [AfterScenario]
        public void AfterTest()
        {
            //Report results to extent
            //Returns pass or fail
            var status = ScenarioContext.Current.ScenarioExecutionStatus;
            
            //with time stamp
            DateTime time = DateTime.Now;
            String fileName = "Screenshot" + time.ToString("h_mm_ss") + ".png";

            if (status == ScenarioExecutionStatus.TestError)
            {
                var stackTrace = ScenarioContext.Current.TestError.Message;
                test.Fail("Test Failed", CaptureScreenshot(DriverInstance.GetDriver(), fileName));
                test.Log(Status.Fail, "Test failed with log trace" + stackTrace);
            }
            else if (status == ScenarioExecutionStatus.OK)
            {
                //this need not be handled it will return pass anyways
                test.Pass("Test Passed!");
            }

            //It releases all objects and creates freshly next time
            extent.Flush();

            //driver.Value.Quit();

        }
        public MediaEntityModelProvider CaptureScreenshot(IWebDriver driver, String screenshotName)
        {
            //driver should be cast with interface screenshot
            //driver will switch to SS mode
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            var screenshot = ts.GetScreenshot().AsBase64EncodedString;

            //builds and gives the media entity which extent reports is expecting
            return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot, screenshotName).Build();
        }
    }
}
