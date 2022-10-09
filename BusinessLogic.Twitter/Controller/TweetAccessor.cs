using APIServices.Twitter.Data;
using APIServices.Twitter.Interfaces;
using Foundation.Core.Interfaces;
using Foundation.Core.Models;
using Microsoft.Practices.Unity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Twitter.Controller
{
    public class TweetAccessor : ITwitterItemAccessor
    {
        #region Public method and Constructor

        public TweetAccessor(IUnityContainer container)
        {
            _apiService = container.Resolve<ITwitterAPIServices>();
        }

        /// <summary>
        /// To get the feed item 
        /// </summary>
        /// <param name="searchParamters"></param>
        /// <returns><see cref="FeedItem"/></returns>
        public async Task<IEnumerable<TwitterFeedItem>> GetTwitterFeedItemsAsync(SearchParameters searchParamters)
        {
            var twitterResponse = await _apiService.GetTweetsAsync(searchParamters);
            return ProcessTweetResponse(twitterResponse);
        }

        #endregion

        #region Private Methods

        private IEnumerable<TwitterFeedItem> ProcessTweetResponse(TwitterResponse twitterResponse)
        {
            if (twitterResponse != null)
            {
                foreach (var tweets in twitterResponse.TweetsDetails)
                {
                    if (tweets != null)
                    {
                        yield return CreateTwitterFeedFromResponse(tweets);
                    }
                }
            }
        }

        private TwitterFeedItem CreateTwitterFeedFromResponse(TweetDetails tweet)
        {
            return new TwitterFeedItem
            {
                Username = tweet.Users.UserName,
                ID = tweet.ID,
                Text = tweet.TweetDescription,
                ProfileImageUrl = tweet.Users.ProfileImageUrl

            };
        }

        #endregion

        public void Dispose()
        {
            if (!_disposed)
            {
                _apiService.Dispose();
                _apiService = null;
                _disposed = true;
            }
        }

        #region Private memenbers
        private ITwitterAPIServices _apiService;
        private bool _disposed;
        #endregion
    }
}
