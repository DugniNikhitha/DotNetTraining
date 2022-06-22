using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using Helpers.Driver;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Helpers.Reports
{
    [Binding]
    public class ReportManager
    {
        private static ExtentReports extent;
        private static ExtentTest scenario;
        private static ExtentTest featureName;
        private ExtentTest Test;

        private static DateTime time = DateTime.Now;
        String fileName = projectDirectory + "\\Screenshots\\Screenshot" + time.ToString("h_mm_ss") + ".png";
        static string workingDirectory = Environment.CurrentDirectory;
        static string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;

        public static void InitialiseReport()
        {
            string path = $"{projectDirectory}\\Reports\\index.html";
            ExtentHtmlReporter htmlreporter = new ExtentHtmlReporter(path);
            htmlreporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Standard;
            extent = new ExtentReports();
            extent.AttachReporter(htmlreporter);
        }

        public static void FeatureName()
        {
            featureName = extent.CreateTest<Feature>(FeatureContext.Current.FeatureInfo.Title);
            Console.WriteLine("BeforeFeature");
        }

        public void SetScenario()
        {
            Console.WriteLine("BeforeScenario");
            var Info = FeatureContext.Current.FeatureInfo;
            Test = extent.CreateTest(ScenarioContext.Current.ScenarioInfo.Title);
            Test.Log(Status.Info, "Starting the Reporting");
            scenario = featureName.CreateNode<Scenario>(ScenarioContext.Current.ScenarioInfo.Title);
        }

        public void ReportTearDown()
        {
            var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();
            if (ScenarioContext.Current.TestError == null)
            {
                if (stepType == "Given")
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType == "When")
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType == "Then")
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType == "And")
                    scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text);
            }
            else if (ScenarioContext.Current.TestError != null)
            {
                if (stepType == "Given")
                {
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message);
                }
                else if (stepType == "When")
                {
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message);
                }
                else if (stepType == "Then")
                {
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message);
                }
                else if (stepType == "And")
                {
                    scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message);
                }
            }
        }

        public void TestResult()
        {
            var driver = ScenarioContext.Current.Get<IDriver>("driver");

            if (ScenarioContext.Current.ScenarioExecutionStatus == ScenarioExecutionStatus.TestError)
                Test.Fail(ScenarioContext.Current.TestError.Message, CaptureScreenshot(driver.GetDriver(), fileName));
            else if (ScenarioContext.Current.ScenarioExecutionStatus == ScenarioExecutionStatus.OK)
                Test.Pass("Test Passed!");
            else
                Test.Skip("Test Case Skipped!");
        }

        public MediaEntityModelProvider CaptureScreenshot(IWebDriver driver, String screenshotName)
        {
            //driver should be cast with interface screenshot
            //driver will switch to SS mode
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            var screenshot = ts.GetScreenshot().AsBase64EncodedString;
            ts.GetScreenshot().SaveAsFile(screenshotName);
            Console.Write(screenshotName);

            //builds and gives the media entity which extent reports is expecting
            return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot, screenshotName).Build();
        }

        public static void FlushReport()
        {
            extent.Flush();
        }
    }
}
