using System;
using NUnit.Framework;
using RestSharpAutomationBLL.Responses;
using RestSharpAutomationBLL.Utils;
using TechTalk.SpecFlow;

namespace RestSharpAutomationTests
{
    [Binding]
    public class UpdateUserInfoStepDefinitions
    {
        CreatePostValidResponse response;
        
        [Given(@"Update existing user with (.*) job to (.*)")]
        public void GivenUpdateExistingUserWithMorpheusJobToQA(string name, string job)
        {
            response = PostUtils.UpdateRequest(name, job);
        }

        [Then(@"Check if the (.*) has been updated")]
        public void ThenCheckIfTheQAHasBeenUpdated(string job)
        {
            Assert.AreEqual(job, response.Job);
        }
    }
}
