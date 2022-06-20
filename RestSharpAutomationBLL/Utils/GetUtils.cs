using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using RestSharpAutomationBLL.Responses;
using RestSharpAutomationFramework.Utils;

namespace RestSharpAutomationBLL.Utils
{
    public class GetUtils
    {
        public static CreateGetValidResponse CreateGetRequest()
        {
            return RestClientUtils
                .Get<CreateGetValidResponse>
                 (
                    "/api/users", DataFormat.Json
                 );
        }
    }
}
