using RestSharpAutomationFramework.Reports;
using TechTalk.SpecFlow;

namespace RestSharpAutomationTests.Hooks
{
    [Binding]
    public sealed class APITestHooks : SpecFlowReport
    {

        [BeforeScenario("@APITests")]
        public void BeforeScenarioWithTag()
        {
        }

        [AfterScenario("@APITests")]
        public void AfterScenario()
        {
        }
    }
}