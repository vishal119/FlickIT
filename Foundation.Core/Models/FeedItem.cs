using Util.Common;

namespace Foundation.Core.Models
{
    public class FeedItem : BaseModel
    {

        #region Public Properties

        public string ItemId
        {
            get => _itemId;
            set => SetField(ref _itemId, value);
        }

        public string Title
        {
            get => _title;
            set => SetField(ref _title, value);
        }

        public string Owner
        {
            get => _owner;
            set => SetField(ref _owner, value);
        }

        public string Url
        {
            get => _url;
            set => SetField(ref _url, value);
        }

        #endregion

        #region Private Properties
        private string _itemId;
        private string _title;
        private string _owner;
        private string _url;
        #endregion
    }
}
