﻿using System.Net;
using Newtonsoft.Json;
using RestSharp;
using JsonReader = RestSharpAutomationFramework.Json.JsonReader;

namespace RestSharpAutomationFramework.Utils
{
    public class RestClientUtils
    {
        public static RestClient _RestClient;
        public static RestRequest _RestRequest;
        //JsonReader js = new JsonReader();
        
        public static RestClient RestClient
        {
            get
            {
                if (_RestClient == null)
                {
                    return new RestClient(new JsonReader().property.BaseUrl);
                }
                else
                {
                    return _RestClient;
                }
            }
        }

        public static RestRequest CreateRequest(string resource, Method method)
        {
            if (_RestRequest == null)
            {
                return new RestRequest(resource, method);
            }
            else
            {
                return _RestRequest;
            }
        }

        //Get
        public static T Get<T>(string resource, DataFormat dataFormat)
        {
            var response = RestClient.Execute(CreateRequest(resource, Method.Get));
            var responseBody = response.Content;
            return JsonConvert.DeserializeObject<T>(responseBody);
        }

        //Post
        public static T Post<T>(string resource, string payload, DataFormat dataFormat)
        {
            var response = RestClient.Execute(CreateRequest(resource, Method.Post).AddBody(payload));
            var responseBody = response.Content;
            return JsonConvert.DeserializeObject<T>(responseBody);
        }

        //Delete
        public static bool Delete(string resource, DataFormat dataFormat, HttpStatusCode expectedStatusCode)
        {
            var response = RestClient.Execute(CreateRequest(resource, Method.Delete));
            var responseCode = response.StatusCode.Equals(expectedStatusCode);
            return responseCode;
        }

        //Update
        public static T Patch<T>(string resource, string payload, DataFormat dataFormat)
        {
            var response = RestClient.Execute(CreateRequest(resource, Method.Patch).AddBody(payload));
            var responseBody = response.Content;
            return JsonConvert.DeserializeObject<T>(responseBody);
        }

        public static T Put<T>(string resource, string payload, DataFormat dataFormat)
        {
            var response = RestClient.Execute(CreateRequest(resource, Method.Put).AddBody(payload));
            var responseBody = response.Content;
            return JsonConvert.DeserializeObject<T>(responseBody);
        }
    }
}
