using Foundation.Core.Models;
using System;
using System.Collections.Generic;

namespace Foundation.Core.Interfaces
{
    public interface IFeedPopulator : IDisposable
    {
        /// <summary>
        /// Gets the Flickr Feed Model
        /// </summary>
        /// <returns></returns>
        FeedModel GetFeedModel();
        /// <summary>
        /// Add items to the model
        /// </summary>
        /// <param name="item"></param>
        void AddToFeed(IList<FeedItem> item);
        /// <summary>
        /// Clears the items in the list
        /// </summary>
        void ClearFeed();
        /// <summary>
        /// Update the search tag
        /// </summary>
        /// <param name="searchTag"></param>
        void UpdateSearchTag(string searchTag);
    }
}
