using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util.Common;

namespace Foundation.Core.Models
{
    public class SearchParameters : NotifyPropertyChanged
    {

        #region Public Properties

        public string SearchTag
        {
            get => _searchTag;
            set => SetField(ref _searchTag, value);
        }


        public int ItemsPerPage
        {
            get => _itemsPerPage;
            set => SetField(ref _itemsPerPage, value);
        }

        public int CurrentPage
        {
            get => _currentPage;
            set => SetField(ref _currentPage, value);
        }

        #endregion

        #region Private Properties

        private string _searchTag;
        private int _itemsPerPage;
        private int _currentPage;

        #endregion
    }
}
