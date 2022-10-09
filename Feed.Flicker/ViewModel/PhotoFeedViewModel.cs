
using Foundation.Core.Interfaces;
using Foundation.Core.Models;
using Microsoft.Practices.Unity;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Util.Common;

namespace Feed.Flicker.ViewModel
{
    public class PhotoFeedViewModel : NotifyPropertyChanged
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

        public bool IsImageNotAvailable
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

        public FeedModel Feed
        {
            get => _feed;
            set => SetField(ref _feed, value);
        }

        public ObservableCollection<FeedItem> FeedItemCollection
        {
            get => _feedItemsCollection;
            set => SetField(ref _feedItemsCollection, value);
        }
        #endregion
        #region Constructor
        public PhotoFeedViewModel(IUnityContainer container)
        {
            IsImageNotAvailable = false;
            IsLoading = false;
            IsContentLoaded = false;
            _modelProvider = container.Resolve<IModelProvider<FeedModel>>();
            _feedController = container.Resolve<IFeedController>();
            _feedController.FeedLoading += OnFeedLoading;
            _feedController.FeedLoaded += OnFeedLoaded;
            _feedController.FeedCleared += OnFeedCleared;

            LoadMoreCommand = new Command(OnLoadMore);
            ClearFeedCommand = new Command(OnClearFeed);

            Feed = _modelProvider.GetInitialModel();
            FeedItemCollection = Feed?.FeedItems;
        }
        #endregion
        /// <summary>
        /// Clear feed
        /// </summary>
        /// <param name="obj"></param>
        private void OnClearFeed(object obj)
        {
            _feedController.ClearFeed();
        }
        /// <summary>
        /// Feed is cleared
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnFeedCleared(object sender, EventArgs e)
        {
            IsContentLoaded = false;
            IsImageNotAvailable = false;
        }
        /// <summary>
        ///  feed is loaded
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnFeedLoaded(object sender, EventArgs e)
        {
            IsLoading = false;
            IsContentLoaded = true;
            IsImageNotAvailable = FeedItemCollection.Count == 0;
        }
        /// <summary>
        /// loading the feed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnFeedLoading(object sender, EventArgs e)
        {
            IsImageNotAvailable = false;
            IsLoading = true;
            IsContentLoaded = false;
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
                await _feedController.LoadMore();
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
        #region Private Members
        private FeedModel _feed;
        private IModelProvider<FeedModel> _modelProvider;
        private IFeedController _feedController;
        private ObservableCollection<FeedItem> _feedItemsCollection;
        private bool _isLoading;
        private bool _isContentLoaded;
        private bool _isImageNotAvailable;
        #endregion
    }
}
