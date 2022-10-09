using Newtonsoft.Json;

namespace APIServices.Twitter.Data
{

    public class Users
    {
        [JsonProperty(PropertyName = "name")]
        public string UserName { get; set; }

        [JsonProperty(PropertyName = "profile_image_url")]
        public string ProfileImageUrl { get; set; }
    }
}
