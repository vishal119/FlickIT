using Foundation.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Foundation.Core.Interfaces
{
    public interface IFeedItemAccessor : IDisposable
    {
        /// <summary>
        /// Gets the Feed Item
        /// </summary>
        /// <param name="searchParameters"></param>
        /// <returns></returns>
        Task<IEnumerable<FeedItem>> GetFeedItemsAsync(SearchParameters searchParameters);
    }
}
