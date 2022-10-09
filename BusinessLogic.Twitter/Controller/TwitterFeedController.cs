using BusinessLogic.Twitter.Interfaces;
using Foundation.Core.Interfaces;
using Foundation.Core.Models;
using Microsoft.Practices.Unity;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogic.Twitter.Controller
{
    public class TwitterFeedController : ITwitterFeedController
    {
        #region Public Methods and events
        public TwitterFeedController(IUnityContainer container)
        {
            _twitterFeedPopulator = container.Resolve<ITwitterFeedPopulator>();
            _twitterItemAccessor = container.Resolve<ITwitterItemAccessor>();
        }

        /// <summary>
        /// Update the feed
        /// </summary>
        /// <param name="searchParams"></param>
        /// <returns></returns>
        public async Task UpdateFeedAsync(SearchParameters searchParams)
        {
            _searchParameters =searchParams;
            _twitterFeedPopulator.ClearFeed();
            FeedLoading?.Invoke(this, EventArgs.Empty);
            try
            {
                var twitteritem = await _twitterItemAccessor.GetTwitterFeedItemsAsync(_searchParameters);
                _twitterFeedPopulator.AddTweetsToFeed(twitteritem.ToList());
                FeedLoaded?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception ex)
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
            _twitterFeedPopulator.ClearFeed();
            FeedCleared?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Load more images to the feed
        /// </summary>
        /// <returns></returns>
        public async Task LoadMore()
        {
            var twitteritem = await _twitterItemAccessor.GetTwitterFeedItemsAsync(_searchParameters);
             _twitterFeedPopulator.AddTweetsToFeed(twitteritem.ToList());
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
               
                _twitterFeedPopulator = null;
                _searchParameters = null;
                _isDisposed = true;
            }
        }

        
        #region Private members
        private ITwitterFeedPopulator _twitterFeedPopulator;
        private ITwitterItemAccessor _twitterItemAccessor;
        private SearchParameters _searchParameters;
        private bool _isDisposed;
        #endregion
    }
}
