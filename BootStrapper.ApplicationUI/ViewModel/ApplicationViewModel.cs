using Feed.Flicker.ViewModel;
using Feed.Tweets.ViewModel;
using Microsoft.Practices.Unity;
using Search.Flicker.ViewModel;
using Util.Common;

namespace BootStrapper.ApplicationUI.ViewModel
{
    public class ApplicationViewModel : NotifyPropertyChanged
    {
        /// <summary>
        /// Search view model
        /// </summary>
        public SearchViewModel SearchViewModel { get; set; }
        /// <summary>
        /// Photo Feed View model
        /// </summary>
        public PhotoFeedViewModel PhotoFeedViewModel { get; set; }

        public TwitterFeedViewModel TwitterFeedViewModel { get; set; }

        #region Constructor
        public ApplicationViewModel(IUnityContainer container)
        {
            PhotoFeedViewModel = container.Resolve<PhotoFeedViewModel>();
            SearchViewModel = container.Resolve<SearchViewModel>();
            TwitterFeedViewModel = container.Resolve<TwitterFeedViewModel>();
        }
        #endregion
    }
}
