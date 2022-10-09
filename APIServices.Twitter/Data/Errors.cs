using Newtonsoft.Json;

namespace APIServices.Twitter.Data
{
    public class Errors
    {
        [JsonProperty(PropertyName = "messages")]
        public string Messages { get; set; }
    }
}
