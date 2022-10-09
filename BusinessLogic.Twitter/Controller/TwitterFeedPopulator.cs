using BusinessLogic.Twitter.Interfaces;
using Foundation.Core.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BusinessLogic.Twitter.Controller
{
    public class TwitterFeedPopulator : ITwitterFeedPopulator
    {
        public TwitterFeedModel TwitterFeedModel { get; }

        public TwitterFeedPopulator()
        {
            TwitterFeedModel = new TwitterFeedModel
            {
                TwitterFeedCollection = new ObservableCollection<TwitterFeedItem>()
            };
        }

        public TwitterFeedModel GetTwitterFeedModel()
        {
            return TwitterFeedModel;
        }

        public void AddTweetsToFeed(IList<TwitterFeedItem> items)
        {
            try
            {
                if (items != null)
                {
                    foreach (var twitterItem in items)
                    {
                        if (twitterItem != null)
                        {
                            TwitterFeedModel.TwitterFeedCollection.Add(twitterItem);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void ClearFeed()
        {
            TwitterFeedModel.TwitterFeedCollection.Clear();
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
