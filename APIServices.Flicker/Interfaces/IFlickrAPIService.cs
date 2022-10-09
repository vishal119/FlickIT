using APIServices.Flicker.Data;
using Foundation.Core.Models;
using System;
using System.Threading.Tasks;

namespace APIServices.Flicker.Interfaces
{
    public interface IFlickrAPIService : IDisposable
    {
        /// <summary>
        /// Sets the API key(Required Parameter)
        /// </summary>
        /// <param name="apiKey"></param>
        void SetApiKey(string apiKey);
        /// <summary>
        /// Gets images
        /// </summary>
        /// <param name="SearchParameters"></param>
        /// <returns><see cref="Photos"/></returns>
        Task<Photos> GetImagesAsync(SearchParameters SearchParameters);
    }
}
