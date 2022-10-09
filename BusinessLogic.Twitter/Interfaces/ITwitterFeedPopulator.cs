using Foundation.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Twitter.Interfaces
{
   public interface ITwitterFeedPopulator : IDisposable
    {
        /// <summary>
        /// Gets the Flickr Feed Model
        /// </summary>
        /// <returns></returns>
        TwitterFeedModel GetTwitterFeedModel();
        /// <summary>
        /// Add tweets to feed
        /// </summary>
        /// <param name="items"></param>
        void AddTweetsToFeed(IList<TwitterFeedItem> items);
        /// <summary>
        /// Clears the items in the list
        /// </summary>
        void ClearFeed();
    }
}
