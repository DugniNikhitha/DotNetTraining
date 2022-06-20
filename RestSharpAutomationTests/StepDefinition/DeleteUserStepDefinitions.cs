using System;
using NUnit.Framework;
using RestSharpAutomationBLL.Responses;
using RestSharpAutomationBLL.Utils;
using TechTalk.SpecFlow;

namespace RestSharpAutomationTests
{
    [Binding]
    public class DeleteUserStepDefinitions
    {
        bool response;

        [Given(@"Delete a user using id")]
        public void GivenDeleteAUserUsingIdId(Table table)
        {
            foreach (TableRow row in table.Rows)
            {
                foreach (string id in row.Values)
                {
                    response = PostUtils.DeletePost(int.Parse(id));
                }
            }
        }

        [Then(@"Check whether the user got deleted")]
        public void ThenCheckWhetherTheUserGotDeleted()
        {
            Assert.IsTrue(response);
        }

    }
}
