using APIServices.Twitter.Data;
using Foundation.Core.Models;
using System;
using System.Threading.Tasks;

namespace APIServices.Twitter.Interfaces
{
    public interface ITwitterAPIServices : IDisposable
    {
        /// <summary>
        /// Sets APi Keys
        /// </summary>
        /// <param name="consumerkey"></param>
        /// <param name="consumerSecretToken"></param>
        void SetApiKey(string consumerkey,string consumerSecretToken);
        /// <summary>
        /// Get the Auth token
        /// </summary>
        void GetBearerToken();
        /// <summary>
        /// Gets the tweets async 
        /// </summary>
        /// <param name="searchParameters"></param>
        /// <returns></returns>
        Task<TwitterResponse> GetTweetsAsync(SearchParameters searchParameters);
    }
}
