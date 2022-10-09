using Newtonsoft.Json;
using System.Collections.Generic;

namespace APIServices.Flicker.Data
{
    public class Photos
    {
        /// <summary>
        /// List of Phtotos
        /// </summary>
        [JsonProperty(PropertyName = "photo")]
        public IEnumerable<Photo> ListOfPhotos { get; set; }
    }
}
