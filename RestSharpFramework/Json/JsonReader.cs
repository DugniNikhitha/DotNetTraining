using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RestSharpAutomationFramework.Json
{
    public class JsonReader
    {
        public JsonReader()
        {
            extractData();
        }

        public Property property { get; set; }

        private static async Task<Property> JsonDeserializeAsync<T>(string response)
        {
            return JsonConvert.DeserializeObject<Property>(response);
        }

        private async void extractData()
        {
            string myJsonString = File.ReadAllText("C:\\work\\Training\\RestSharpFramework\\Json\\Config.json");
            property = await JsonDeserializeAsync<Property>(myJsonString);
        }
    }
}
