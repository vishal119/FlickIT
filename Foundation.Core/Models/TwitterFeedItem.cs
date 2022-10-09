using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util.Common;

namespace Foundation.Core.Models
{
   public class TwitterFeedItem : BaseModel
    {
        #region Public Properties

        public string Username
        {
            get => _userName;
            set => SetField(ref _userName, value);
        }

        public string Text
        {
            get => _text;
            set => SetField(ref _text, value);
        }

        public string ID
        {
            get => _id;
            set => SetField(ref _id, value);
        }

        public string ProfileImageUrl
        {
            get => _profileImageUrl;
            set => SetField(ref _profileImageUrl, value);
        }

        #endregion

        #region Private Properties
        private string _userName;
        private string _text;
        private string _id;
        private string _profileImageUrl;
        #endregion
    }
}
