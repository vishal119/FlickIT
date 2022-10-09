using System.Runtime.Serialization;

namespace APIServices.Twitter.Data
{
    [DataContract]
    public class BearerToken
    {
        [DataMember]
        public string token_type { get; set; }
        [DataMember]
        public string access_token { get; set; }
    }
}
