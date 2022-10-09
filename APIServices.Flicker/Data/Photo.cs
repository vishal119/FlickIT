using Newtonsoft.Json;

namespace APIServices.Flicker.Data
{
    /// <summary>
    /// Flckr Photo model
    /// </summary>
    public class Photo
    {
        [JsonProperty(PropertyName = "url_t")]
        public string Url { get; set; }
        /// <summary>
        /// ID property
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string ID { get; set; }
        /// <summary>
        /// Owner of photo
        /// </summary>
        [JsonProperty(PropertyName = "owner")]
        public string Owner { get; set; }
        
        /// <summary>
        /// Title of Photo
        /// </summary>
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }
    }
}
