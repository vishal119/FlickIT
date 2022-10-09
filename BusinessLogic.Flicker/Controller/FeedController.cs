using Foundation.Core.Interfaces;
using Foundation.Core.Models;
using Microsoft.Practices.Unity;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogic.Flicker.Controller
{
    public class FeedController : IFeedController
    {
        #region Public Methods and events
        public FeedController(IUnityContainer container)
        {
            _feedItemAccessor = container.Resolve<IFeedItemAccessor>();
            _feedPopulator = container.Resolve<IFeedPopulator>();
        }

        /// <summary>
        /// Update the feed
        /// </summary>
        /// <param name="searchParams"></param>
        /// <returns></returns>
        public async Task UpdateFeedAsync(SearchParameters searchParams)
        {
            _searchParameters = searchParams;
            _feedPopulator.ClearFeed();
            FeedLoading?.Invoke(this, EventArgs.Empty);
            try
            {
                var feedItems = await _feedItemAccessor.GetFeedItemsAsync(_searchParameters);
                _feedPopulator.ClearFeed();
                _feedPopulator.UpdateSearchTag(_searchParameters.SearchTag);
                _feedPopulator.AddToFeed(feedItems.ToList());
                FeedLoaded?.Invoke(this, EventArgs.Empty);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                throw new Exception(ex.ToString());
            }
            finally
            {
                FeedLoaded?.Invoke(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Clears the feed
        /// </summary>
        public void ClearFeed()
        {
            _feedPopulator.ClearFeed();
            FeedCleared?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Load more images to the feed
        /// </summary>
        /// <returns></returns>
        public async Task LoadMore()
        {
            _searchParameters.CurrentPage += 1;
            var feedItems = await _feedItemAccessor.GetFeedItemsAsync(_searchParameters);
            _feedPopulator.AddToFeed(feedItems.ToList());
         //   var twitteritem = await _twitterItemAccessor.GetTwitterFeedItemsAsync(_searchParameters);
         //   _feedPopulator.AddTweetsToFeed(twitteritem.ToList());
        }

        public event EventHandler FeedLoading;
        public event EventHandler FeedLoaded;
        public event EventHandler FeedCleared;

        #endregion

        /// <summary>
        /// Dispose 
        /// </summary>
        public void Dispose()
        {
            if (_isDisposed)
            {
                _feedItemAccessor = null;
                _feedPopulator = null;
                _searchParameters = null;
                _isDisposed = true;
            }
        }
        #region Private members

        private IFeedItemAccessor _feedItemAccessor;
        private IFeedPopulator _feedPopulator;
        private SearchParameters _searchParameters;
        private bool _isDisposed;

        #endregion
    }
}
