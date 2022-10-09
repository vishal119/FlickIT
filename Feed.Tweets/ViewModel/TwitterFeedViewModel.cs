using BusinessLogic.Twitter.Controller;
using Foundation.Core.Interfaces;
using Foundation.Core.Models;
using Microsoft.Practices.Unity;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Util.Common;

namespace Feed.Tweets.ViewModel
{
    public class TwitterFeedViewModel : NotifyPropertyChanged
    {
        #region Public members

        /// <summary>
        /// ICommand for loading more feed items
        /// </summary>
        public ICommand LoadMoreCommand { get; set; }
        /// <summary>
        /// Icommand for clearing feed
        /// </summary>
        public ICommand ClearFeedCommand { get; set; }
        public TwitterFeedModel Feed
        {
            get => _feed;
            set => SetField(ref _feed, value);
        }

        public ObservableCollection<TwitterFeedItem> FeedItemCollection
        {
            get => _feedItemsCollection;
            set => SetField(ref _feedItemsCollection, value);
        }

        public bool IsTweetsNotAvailable
        {
            get => _isImageNotAvailable;
            set => SetField(ref _isImageNotAvailable, value);
        }
        public bool IsLoading
        {
            get => _isLoading;
            set => SetField(ref _isLoading, value);
        }
        public bool IsContentLoaded
        {
            get => _isContentLoaded;
            set => SetField(ref _isContentLoaded, value);
        }
        #endregion
        #region Constructor
        public TwitterFeedViewModel(IUnityContainer container)
        {
            IsTweetsNotAvailable = false;
            IsLoading = false;
            IsContentLoaded = false;
            _twitterFeedController = container.Resolve<ITwitterFeedController>();
            _modelProvider = container.Resolve<IModelProvider<TwitterFeedModel>>();
            Feed = _modelProvider.GetInitialModel();
            _twitterFeedController.FeedLoading += OnFeedLoading;
            _twitterFeedController.FeedLoaded += OnFeedLoaded;
            _twitterFeedController.FeedCleared += OnFeedCleared;
            LoadMoreCommand = new Command(OnLoadMore);
            ClearFeedCommand = new Command(OnClearFeed);
            FeedItemCollection = Feed?.TwitterFeedCollection;
        }

        private void OnFeedCleared(object sender, EventArgs e)
        {
            IsContentLoaded = false;
            IsTweetsNotAvailable = false;
        }

        private void OnFeedLoaded(object sender, EventArgs e)
        {
            IsLoading = false;
            IsContentLoaded = true;
            IsTweetsNotAvailable = FeedItemCollection.Count == 0;
        }

        private void OnFeedLoading(object sender, EventArgs e)
        {
            IsTweetsNotAvailable = false;
            IsLoading = true;
            IsContentLoaded = false;
        }
        /// <summary>
        /// Clear feed
        /// </summary>
        /// <param name="obj"></param>
        private void OnClearFeed(object obj)
        {
            _twitterFeedController.ClearFeed();
        }
        /// <summary>
        /// Load more item to feed
        /// </summary>
        /// <param name="obj"></param>
        private async void OnLoadMore(object obj)
        {
            try
            {
                IsLoading = true;
                IsContentLoaded = false;
                await _twitterFeedController.LoadMore();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                IsLoading = false;
                IsContentLoaded = true;
            }
        }
        #endregion

        #region Private Members
        private TwitterFeedModel _feed;
        private ITwitterFeedController _twitterFeedController;
        private IModelProvider<TwitterFeedModel> _modelProvider;
        private ObservableCollection<TwitterFeedItem> _feedItemsCollection;
        private bool _isImageNotAvailable;
        private bool _isLoading;
        private bool _isContentLoaded;
        #endregion
    }
}
