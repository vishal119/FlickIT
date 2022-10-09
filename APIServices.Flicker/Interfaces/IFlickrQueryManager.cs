using Foundation.Core.Models;
using System;

namespace APIServices.Flicker.Interfaces
{
    public interface IFlickrQueryManager : IDisposable
    {
        /// <summary>
        /// Instance of IQueryBuilder
        /// </summary>
        IFlickrQueryBuilder QueryBuilder { set; }
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
        string GetImageQuery(string apiKey, SearchParameters searchParameters);

    }
}
