using System;
using RestSharpAutomationFramework.Reports;
using TechTalk.SpecFlow;

namespace RestSharpAutomationTests.Hooks
{
    [Binding]
    public sealed class APITestHooks : APIReportManager
    {
        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            Console.WriteLine("BEFORE TEST RUN");
            InitialiseReport();
        }

        [BeforeFeature]
        public static void BeforeFeature()
        {
            FeatureName();
        }

        [BeforeScenario("@APITests")]
        public void BeforeScenario()
        {
            Console.WriteLine("Before Scenario");
            SetScenario();

        }

        [BeforeStep("@APITests")]
        public void BeforeStep()
        {
            Console.WriteLine("Step has started");
        }

        [AfterStep("@APITests")]
        public void AfterStep()
        {
            ReportTearDown();
            Console.WriteLine("Step has ended");
        }

        [AfterScenario("@APITests")]
        public void AfterScenario()
        {
            Console.WriteLine("After Scenario");
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            FlushReport();
            Console.WriteLine("AFTER TEST RUN");
        }
    }
}