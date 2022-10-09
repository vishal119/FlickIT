using BusinessLogic.Flicker.Interfaces;
using Foundation.Core.Interfaces;
using Foundation.Core.Models;

namespace BusinessLogic.Flicker.Controller
{
    public class SearchParameterModelProvider : IModelProvider<SearchParameters>
    {
        private ISearchParameterDataStore _searchParameterDataStore;
        private bool _isDispose;

        public SearchParameterModelProvider(ISearchParameterDataStore searchParameterDataStore)
        {
            _searchParameterDataStore = searchParameterDataStore;
        }

        /// <summary>
        /// Gets the initial model
        /// </summary>
        /// <returns></returns>
        public SearchParameters GetInitialModel()
        {
            return _searchParameterDataStore.GetSearchParameters();
        }

        public void Dispose()
        {
            if (!_isDispose)
            {
                _searchParameterDataStore?.Dispose();
                _isDispose = true;
            }
        }
    }
}
