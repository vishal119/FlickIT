using BusinessLogic.Flicker.Interfaces;
using Foundation.Core.Models;

namespace BusinessLogic.Flicker.Controller
{
    public class SearchParameterDataStore : ISearchParameterDataStore
    {
        private bool _isDisposed;

        #region Public Methods

        public SearchParameters SearchParameters { get; private set; }

        public SearchParameterDataStore()
        {
            SearchParameters = new SearchParameters
            {
                CurrentPage = 1,
                ItemsPerPage = 25,
                SearchTag = string.Empty
            };
        }

        /// <summary>
        /// Gets search paramters
        /// </summary>
        /// <returns><see cref="SearchParameters"/></returns>
        public SearchParameters GetSearchParameters()
        {
            return SearchParameters;
        }

        #endregion

        public void Dispose()
        {
            if (!_isDisposed)
            {
                SearchParameters.ItemsPerPage = 0;
                SearchParameters.CurrentPage = 0;
                SearchParameters = null;
                _isDisposed = true;
            }
        }
    }
}
