using System;
using System.Net;
using NUnit.Framework;
using RestSharpAutomationBLL.Responses;
using RestSharpAutomationBLL.Utils;
using TechTalk.SpecFlow;

namespace RestSharpAutomationTests
{
    [Binding]
    public class CreateNewUserStepDefinitions
    {
        CreatePostValidResponse response;
       
        [Given(@"Create user using name as (.*) and job as (.*)")]
        public void GivenCreateUserUsingNameAsNikhithaAndJobAsQAAutomation(string name, string job)
        {
            response = PostUtils.CreatePost(name, job);
        }

        [Then(@"Check if a user is created with name (.*) and job (.*)")]
        public void ThenCheckIfAUserIsCreatedWithNameNikhithaAndJobQAAutomation(string name, string job)
        {
            Assert.AreEqual(name, response.Name);
            Assert.AreEqual(job, response.Job);
        }

    }
}
