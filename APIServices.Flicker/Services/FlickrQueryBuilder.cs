using APIServices.Flicker.Interfaces;
using System.Collections.Generic;

namespace APIServices.Flicker.Services
{
    public class FlickrQueryBuilder : IFlickrQueryBuilder
    {

        #region Public Methods

        /// <summary>
        /// Sets search tag
        /// </summary>
        /// <param name="tags"></param>
        public void SetSearchTags(List<string> tags)
        {
            if (tags != null && tags.Count > 0)
            {
                var values = string.Join(",", tags);
                _listOfParameters.Add($"tags={values}");
            }
        }
        /// <summary>
        /// Sets items per page
        /// </summary>
        /// <param name="itemsPerPage"></param>
        public void SetItemsPerPageQuery(int itemsPerPage)
        {
            if (itemsPerPage > 0)
            {
                _listOfParameters.Add($"per_page={itemsPerPage}");
            }
        }
        /// <summary>
        /// Sets current page value 
        /// </summary>
        /// <param name="currentPage"></param>
        public void SetCurrentPageQuery(int currentPage)
        {
            if (currentPage > 1)
            {
                _listOfParameters.Add($"page={currentPage}");
            }
        }
        /// <summary>
        /// Adding safe search query values
        /// </summary>
        /// <param name="id"></param>
        public void SetSafeSearchQuery(int id)
        {
            _listOfParameters.Add($"safe_search={id}");
        }
        /// <summary>
        /// Builds the API query
        /// </summary>
        /// <returns></returns>
        public string Build()
        {
            string result = "rest/?";
            if (_listOfParameters.Count > 0)
            {
                result += string.Join("&", _listOfParameters);
            }
            return result;
        }
        /// <summary>
        /// Clear the parameter list
        /// </summary>
        public void Reset()
        {
            _listOfParameters.Clear();
        }
        /// <summary>
        /// Method to query images
        /// </summary>
        public void AddGetImageMethodQuery()
        {
            _listOfParameters.Add("method=flickr.photos.search");
        }
        /// <summary>
        /// Adding json call back
        /// </summary>
        public void AddNoJsonCallBack()
        {
            _listOfParameters.Add("nojsoncallback=1");
        }
        /// <summary>
        /// Sets extra parameters in api
        /// </summary>
        /// <param name="extras"></param>
        public void SetExtras(string extras)
        {
            if (!string.IsNullOrEmpty(extras))
            {
                _listOfParameters.Add($"extras={extras}");
            }
        }
        /// <summary>
        /// Sets Api format
        /// </summary>
        /// <param name="format"></param>
        public void SetFormat(string format)
        {
            _listOfParameters.Add($"format={format}");
        }
        /// <summary>
        /// Sets Api Key
        /// </summary>
        /// <param name="apiKey"></param>
        public void SetApiKey(string apiKey)
        {
            _listOfParameters.Add($"api_key={apiKey}");
        }

        #endregion

        #region Dispose 

        public void Dispose()
        {
            if (!_isDisposed)
            {
                Reset();
                _listOfParameters = null;
                _isDisposed = true;
            }
        }
        #endregion
        #region Private members
        private IList<string> _listOfParameters = new List<string>();
        private bool _isDisposed;
        #endregion
    }
}
