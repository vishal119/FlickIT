using Newtonsoft.Json;

namespace APIServices.Twitter.Data
{
    public class TweetDetails
    {
        [JsonProperty(PropertyName = "id")]
        public string ID { get; set; }
        [JsonProperty(PropertyName = "text")]
        public string TweetDescription { get; set; }
        [JsonProperty(PropertyName = "user")]
        public Users Users { get; set; }
    }
}
