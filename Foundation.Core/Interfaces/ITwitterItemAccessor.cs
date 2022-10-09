using Foundation.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foundation.Core.Interfaces
{
    public interface ITwitterItemAccessor : IDisposable
    {
        /// <summary>
        /// Gets the Feed Item
        /// </summary>
        /// <param name="searchParameters"></param>
        /// <returns></returns>
        Task<IEnumerable<TwitterFeedItem>> GetTwitterFeedItemsAsync(SearchParameters searchParameters);
    }
}
