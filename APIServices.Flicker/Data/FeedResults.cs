using Newtonsoft.Json;

namespace APIServices.Flicker.Data
{
    /// <summary>
    /// Feed Results class containing API Response 
    /// </summary>
    public class FeedResults
    {
        /// <summary>
        /// Photos model of Flicker API
        /// </summary>
        [JsonProperty(PropertyName = "photos")]
        public Photos Photos { get; set; }
        /// <summary>
        /// Status of response
        /// </summary>
        [JsonProperty(PropertyName = "stat")]
        public string Status { get; set; }
        /// <summary>
        /// Message of response
        /// </summary>
        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }
    }
}
