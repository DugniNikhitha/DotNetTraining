using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using RestSharpAutomationBLL.Responses;
using RestSharpAutomationBLL.Utils;
using TechTalk.SpecFlow;

namespace RestSharpAutomationTests
{
    [Binding]
    public class GetUserListStepDefinitions
    {
        CreateGetValidResponse response;

        [Given(@"Get users list using Get API request")]
        public void GivenGetUsersListUsingGetAPIRequest()
        {
            response = GetUtils.CreateGetRequest();
        }

        [Then(@"Check whether the following names are present")]
        public void ThenCheckWhetherTheFollowingNamesArePresent(Table table)
        {
            List<string> expectedNames = table.Rows.Select(t => t["Name"]).ToList();
            List<string> actualNames = response.Data.Select(usr => usr.FirstName).ToList();
            Assert.AreEqual(expectedNames, actualNames);
        }
    }
}
