using BusinessLogic.Flicker.Interfaces;
using Foundation.Core.Interfaces;
using Microsoft.Practices.Unity;
using System.Threading.Tasks;

namespace BusinessLogic.Flicker.Controller
{
    public class SearchController : ISearchController
    {
        #region Private members
        private ISearchParameterDataStore _searchParameterDataStore;
        private IFeedController _feedController;
        private ITwitterFeedController _twitterFeedController;
        #endregion

        public SearchController(IUnityContainer container)
        {
            _searchParameterDataStore = container.Resolve<ISearchParameterDataStore>();
            _feedController = container.Resolve<IFeedController>();
            _twitterFeedController = container.Resolve<ITwitterFeedController>();
        }

        public async Task Search()
        {
            var searchParam = _searchParameterDataStore.GetSearchParameters();
            await _feedController.UpdateFeedAsync(searchParam);
            await _twitterFeedController.UpdateFeedAsync(searchParam);
        }

    }
}
