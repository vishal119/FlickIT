using Foundation.Core.Models;
using System;
using System.Threading.Tasks;

namespace Foundation.Core.Interfaces
{
   public interface ITwitterFeedController : IDisposable
    {

        #region Events

        /// <summary>
        /// Event when Feed is loading
        /// </summary>
        event EventHandler FeedLoading;

        /// <summary>
        /// Event when Feed is loaded
        /// </summary>
        event EventHandler FeedLoaded;

        /// <summary>
        /// Event when Feed is cleared
        /// </summary>
        event EventHandler FeedCleared;

        #endregion

        #region Methods

        /// <summary>
        /// Updates the Feed
        /// </summary>
        /// <param name="searchParams"></param>
        /// <returns></returns>
        Task UpdateFeedAsync(SearchParameters searchParams);

        /// <summary>
        /// Clears the feed
        /// </summary>
        void ClearFeed();

        /// <summary>
        /// Load more item to the feed
        /// </summary>
        /// <returns></returns>
        Task LoadMore();

        #endregion
    }
}
