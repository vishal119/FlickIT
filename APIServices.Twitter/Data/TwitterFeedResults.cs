using Newtonsoft.Json;
using System.Collections.Generic;

namespace APIServices.Twitter.Data
{
    public class TwitterFeedResults // not usable anymore 
    {
        [JsonProperty(PropertyName = "statuses")]
        public IEnumerable<TweetDetails> TweetsDetails { get; set; }
        [JsonProperty(PropertyName = "errors")]
         public Errors Error { get; set; }
    }
}
