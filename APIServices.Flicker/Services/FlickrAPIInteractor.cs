using APIServices.Flicker.Data;
using APIServices.Flicker.Interfaces;
using Foundation.Core.Models;
using Microsoft.Practices.Unity;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Util.Common.Interfaces;

namespace APIServices.Flicker.Services
{
    /// <summary>
    /// API interactor class
    /// </summary>
    public class FlickrAPIInteractor : IFlickrAPIService
    {
        
        #region Constructor
        public FlickrAPIInteractor(IUnityContainer container)
        {
            _queryManager = container.Resolve<IFlickrQueryManager>();
            _inMemoryCache = container.Resolve<IInMemoryCache>();
            var baseAddress = _queryManager.GetBaseAddress();
            Initialize(baseAddress);
        }
        #endregion
        #region Public Methods
        /// <summary>
        /// Intialize the client 
        /// </summary>
        /// <param name="baseAdderess"></param>
        public void Initialize(string baseAdderess)
        {
            _client = new HttpClient();
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _client.BaseAddress = new Uri(baseAdderess);
        }
        /// <summary>
        /// Sets the API key 
        /// </summary>
        /// <param name="apiKey"></param>
        public void SetApiKey(string apiKey)
        {
            _apiKey = apiKey;
        }
        /// <summary>
        /// Gets Images/Photos
        /// </summary>
        /// <param name="searchParameters"></param>
        /// <returns><see cref="Photos"/></returns>
        public async Task<Photos> GetImagesAsync(SearchParameters searchParameters)
        {
            string query = _queryManager.GetImageQuery(_apiKey, searchParameters);
          
            if (_inMemoryCache.TryGetValue(query, out FeedResults feedResults))
            {
                if (feedResults != null)
                {
                    return feedResults.Photos;
                }
            }

            using (HttpResponseMessage response = await _client.GetAsync(query))
            {
                try
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadAsAsync<FeedResults>();

                        if (result.Status == "fail")
                        {
                            throw new Exception(result.Message);
                        }
                        _inMemoryCache.SetValue(query, result);
                        return result.Photos;
                    }
                    else
                    {
                        throw new Exception(response.ReasonPhrase);

                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex);
                    throw new Exception(ex.ToString());
                }
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
        #region Private Methods
        private void Dispose(bool disposing)
        {
            if (!_isDisposed)
            {
                if (disposing)
                {
                    _queryManager.Dispose();
                    _queryManager = null;
                }
                _isDisposed = true;
            }
        }
        #endregion
        #region Private Members
        private HttpClient _client;
        private IFlickrQueryManager _queryManager;
        private string _apiKey;
        private bool _isDisposed;
        private IInMemoryCache _inMemoryCache;
        #endregion
    }
}
