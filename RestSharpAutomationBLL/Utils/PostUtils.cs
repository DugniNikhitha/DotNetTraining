using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using RestSharpAutomationBLL.Requests;
using RestSharpAutomationBLL.Responses;
using RestSharpAutomationFramework.Utils;

namespace RestSharpAutomationBLL.Utils
{
    public class PostUtils
    {
        //Create a new post
        public static CreatePostValidResponse CreatePost(string name, string job)
        {
            return RestClientUtils
                .Post<CreatePostValidResponse>
                 (
                    "/api/users", CreatePostRequestBody(name, job), DataFormat.Json
                 );
        }

        public static string CreatePostRequestBody(string name, string job)
        {
            CreatePostValidRequest request = new CreatePostValidRequest();
            request.name = name;
            request.job = job;
            return JsonConvert.SerializeObject(request);
        }

        //Update a post
        public static CreatePostValidResponse UpdateRequest(string name, string job)
        {
            return RestClientUtils
                .Patch<CreatePostValidResponse>
                 (
                    "/api/users/2", CreatePostRequestBody(name, job), DataFormat.Json
                 );
        }

        //Delete a post 
        public static bool DeletePost(int id)
        {
            return RestClientUtils.Delete("/api/users/"+id.ToString(), DataFormat.Json, HttpStatusCode.NoContent);
        }
    }
}
