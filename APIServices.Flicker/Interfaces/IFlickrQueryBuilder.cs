using System;
using System.Collections.Generic;

namespace APIServices.Flicker.Interfaces
{
    public interface IFlickrQueryBuilder : IDisposable
    {
        /// <summary>
        /// Adding method for image query
        /// </summary>
        void AddGetImageMethodQuery();
        /// <summary>
        /// Adding json call back
        /// </summary>
        void AddNoJsonCallBack();
        /// <summary>
        /// Sets extra parameters in api
        /// </summary>
        /// <param name="extras"></param>
        void SetExtras(string extras);
        /// <summary>
        /// Sets the API format
        /// </summary>
        /// <param name="format"></param>
        void SetFormat(string format);
        /// <summary>
        /// Sets the API key
        /// </summary>
        /// <param name="apiKey"></param>
        void SetApiKey(string apiKey);
        /// <summary>
        /// Sets the search tags
        /// </summary>
        /// <param name="tags"></param>
        void SetSearchTags(List<string> tags);
        /// <summary>
        /// Sets items per page 
        /// </summary>
        /// <param name="itemsPerPage"></param>
        void SetItemsPerPageQuery(int itemsPerPage);
        /// <summary>
        /// sets the number of current page in the api query
        /// </summary>
        /// <param name="currentPage"></param>
        void SetCurrentPageQuery(int currentPage);
        /// <summary>
        /// Sets number of safe search
        /// </summary>
        /// <param name="id"></param>
        void SetSafeSearchQuery(int id);
        /// <summary>
        /// Build the api query
        /// </summary>
        /// <returns></returns>
        string Build();
        /// <summary>
        /// Rest the query
        /// </summary>
        void Reset();
    }
}
