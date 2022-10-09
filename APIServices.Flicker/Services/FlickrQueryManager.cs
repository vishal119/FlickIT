using APIServices.Flicker.Interfaces;
using Foundation.Core.Models;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;

namespace APIServices.Flicker.Services
{
    public class FlickrQueryManager : IFlickrQueryManager
    {
        
        public IFlickrQueryBuilder QueryBuilder
        {
            set => _queryBuilder = value;
        }
        #region Constructor
        public FlickrQueryManager(IUnityContainer container)
        {
            QueryBuilder = container.Resolve<IFlickrQueryBuilder>();
            _baseURL = "https://api.flickr.com/services/";
        }
        #endregion
        #region Public methods
        /// <summary>
        /// Get flickr base address
        /// </summary>
        /// <returns></returns>
        public string GetBaseAddress()
        {
            return _baseURL;
        }
        /// <summary>
        /// Get Images query
        /// </summary>
        /// <param name="apiKey"></param>
        /// <param name="searchParameters"></param>
        /// <returns></returns>
        public string GetImageQuery(string apiKey, SearchParameters searchParameters)
        {
            string _apiQuery = string.Empty;
            try
            {
                _queryBuilder.SetApiKey(apiKey);
                _queryBuilder.AddGetImageMethodQuery();
                _queryBuilder.SetSearchTags(new List<string> { searchParameters.SearchTag });
                _queryBuilder.SetItemsPerPageQuery(searchParameters.ItemsPerPage);
                _queryBuilder.SetCurrentPageQuery(searchParameters.CurrentPage);
                _queryBuilder.SetSafeSearchQuery(1);
                _queryBuilder.SetExtras("url_t");
                _queryBuilder.SetFormat("json");
                _queryBuilder.AddNoJsonCallBack();
                 _apiQuery = _queryBuilder.Build();
                _queryBuilder.Reset();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
            return _apiQuery;
        }

        #endregion

        #region Private Properties

        private IFlickrQueryBuilder _queryBuilder;
        private readonly string _baseURL;
        private bool _isDisposed;

        #endregion
        #region Dispose Pattern

        public void Dispose()
        {
            if (!_isDisposed)
            {
                _queryBuilder.Dispose();
                _isDisposed = true;
            }

        }

        #endregion
    }
}
