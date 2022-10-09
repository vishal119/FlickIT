using Foundation.Core.Interfaces;
using Foundation.Core.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BusinessLogic.Flicker.Controller
{
    public class FeedPopulator : IFeedPopulator
    {
        public FeedModel FeedModel { get; }

        public FeedPopulator()
        {
            FeedModel = new FeedModel
            {
                FeedItems = new ObservableCollection<FeedItem>(),
                SearchTag = "",
            };
        }

        /// <summary>
        /// Adding items to feed
        /// </summary>
        /// <param name="items"></param>
        public void AddToFeed(IList<FeedItem> items)
        {
            try
            {
                if (items != null)
                {
                    foreach (var feedItem in items)
                    {
                        if (feedItem != null)
                        {
                            FeedModel.FeedItems.Add(feedItem);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }


        /// <summary>
        /// Clear the feed
        /// </summary>
        public void ClearFeed()
        {
            FeedModel.FeedItems.Clear();
            FeedModel.SearchTag = string.Empty;

        }
        /// <summary>
        /// Get feed model
        /// </summary>
        /// <returns><see cref="FeedModel"/></returns>
        public FeedModel GetFeedModel()
        {
            return FeedModel;
        }

        /// <summary>
        /// Update search tag
        /// </summary>
        /// <param name="searchTag"></param>
        public void UpdateSearchTag(string searchTag)
        {
            FeedModel.SearchTag = searchTag;
        }

        public void Dispose()
        {
            if (!_isDisposed)
            {
                ClearFeed();
                _isDisposed = true;
            }
        }
        private bool _isDisposed;
    }
}
