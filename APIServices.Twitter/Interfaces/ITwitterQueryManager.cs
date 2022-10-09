using Foundation.Core.Models;
using System;

namespace APIServices.Twitter.Interfaces
{
    public interface ITwitterQueryManager : IDisposable
    {
        /// <summary>
        /// Instance of IQueryBuilder
        /// </summary>
        ITwitterQueryBuilder QueryBuilder { set; }
        /// <summary>
        /// Gets Base Address
        /// </summary>
        /// <returns></returns>
        string GetBaseAddress();
        /// <summary>
        /// Gets final query generated for Get Image
        /// </summary>
        /// <param name="apiKey"></param>
        /// <param name="searchParameters"></param>
        /// <returns></returns>
        string GetSearchQuery(SearchParameters searchParameters);
        /// <summary>
        /// Generaters token credentials
        /// </summary>
        /// <param name="consumerKey"></param>
        /// <param name="consumerSecretToken"></param>
        /// <returns></returns>
        string GenerateBearerTokenCredentials(string consumerKey, string consumerSecretToken);
    }
}
