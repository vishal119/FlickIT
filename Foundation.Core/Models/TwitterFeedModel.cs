using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util.Common;

namespace Foundation.Core.Models
{
   public class TwitterFeedModel : BaseModel
    {
        #region Public Properties

        /// <summary>
        /// Feed items to be viewed on the feed
        /// </summary>
        public ObservableCollection<TwitterFeedItem> TwitterFeedCollection
        {
            get => _twitterFeedCollection;
            set => SetField(ref _twitterFeedCollection, value);
        }
        #endregion

        #region Private Properties
        private ObservableCollection<TwitterFeedItem> _twitterFeedCollection;
        #endregion
    }
}
