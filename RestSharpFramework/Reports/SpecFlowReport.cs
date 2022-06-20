using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using TechTalk.SpecFlow;

namespace RestSharpAutomationFramework.Reports
{
    public class SpecFlowReport
    {
        private ExtentTest Test;
        public static ExtentReports extent;


        [BeforeScenario]
        public void StartTestReport()
        {
            String workingDirectory = Environment.CurrentDirectory;

            //To generate file in the parent folder
            String reportPath = workingDirectory + "\\ApiTestReport.html";

            //path where file should be generated
            var htmlReporter = new ExtentHtmlReporter(reportPath);

            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
            extent.AddSystemInfo("Host Name", "Local Host");
            extent.AddSystemInfo("Environment", "QA");
            extent.AddSystemInfo("Username", "Dugni Nikhitha");

            Test = extent.CreateTest(ScenarioContext.Current.ScenarioInfo.Title);
            var Info = FeatureContext.Current.FeatureInfo;
            Test.Log(Status.Info, "Starting the Reporting");
        }

        [AfterScenario]
        public void ReportTearDown()
        {
            if (ScenarioContext.Current.ScenarioExecutionStatus == ScenarioExecutionStatus.TestError)
                Test.Fail(ScenarioContext.Current.TestError.Message);
            else if (ScenarioContext.Current.ScenarioExecutionStatus == ScenarioExecutionStatus.OK)
                Test.Pass("Test Passed!");
            else
                Test.Skip("Test Case Skipped!");
            extent.Flush();
        }
    }
}
