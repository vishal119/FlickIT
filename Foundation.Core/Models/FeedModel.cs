using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util.Common;

namespace Foundation.Core.Models
{
    public class FeedModel : BaseModel
    {

        #region Public Properties

        /// <summary>
        /// Feed items to be viewed on the feed
        /// </summary>
        public ObservableCollection<FeedItem> FeedItems
        {
            get => _feedItems;
            set => SetField(ref _feedItems, value);
        }

        /// <summary>
        /// The tag for which the feed items are generated
        /// </summary>
        public string SearchTag
        {
            get => _searchTag;
            set => SetField(ref _searchTag, value);
        }

        #endregion

        #region Private Properties

        private ObservableCollection<FeedItem> _feedItems;
        private string _searchTag;

        #endregion
    }
}
