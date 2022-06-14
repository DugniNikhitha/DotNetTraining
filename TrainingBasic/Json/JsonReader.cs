using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Helpers.Json
{
    public class JsonReader
    {
        public JsonReader()
        {

        }

        public Property property { get; set; }

        public static async Task<Property> JsonDeserializeAsync<T>(string response)
        {
            return JsonConvert.DeserializeObject<Property>(response);
        }

        public async void extractData()
        {
            string myJsonString = File.ReadAllText("Json/Config.json");
            property = await JsonDeserializeAsync<Property>(myJsonString);
        }
    }
}
