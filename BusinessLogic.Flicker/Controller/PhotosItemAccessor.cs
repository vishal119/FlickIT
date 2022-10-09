using APIServices.Flicker.Data;
using APIServices.Flicker.Interfaces;
using Foundation.Core.Interfaces;
using Foundation.Core.Models;
using Microsoft.Practices.Unity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Flicker.Controller
{
    public class PhotosItemAccessor : IFeedItemAccessor
    {
        #region Public method and Constructor

        public PhotosItemAccessor(IUnityContainer container)
        {
            _apiService = container.Resolve<IFlickrAPIService>();
        }

        /// <summary>
        /// To get the feed item 
        /// </summary>
        /// <param name="searchParamters"></param>
        /// <returns><see cref="FeedItem"/></returns>
        public async Task<IEnumerable<FeedItem>> GetFeedItemsAsync(SearchParameters searchParamters)
        {
            var photos = await _apiService.GetImagesAsync(searchParamters);
            return ProcessPhotos(photos);
        }

        #endregion

        #region Private Methods

        private IEnumerable<FeedItem> ProcessPhotos(Photos photoList)
        {
            if (photoList != null)
            {
                foreach (var photo in photoList.ListOfPhotos)
                {
                    if (photo != null)
                    {
                        yield return CreateFeedItemFromPhoto(photo);
                    }
                }
            }
        }

        private FeedItem CreateFeedItemFromPhoto(Photo photo)
        {
            return new FeedItem
            {
                ItemId = photo.ID,
                Title = photo.Title,
                Url = photo.Url,
                Owner = photo.Owner
            };
        }

        #endregion

        public void Dispose()
        {
            if (!_disposed)
            {
                _apiService.Dispose();
                _apiService = null;
                _disposed = true;
            }
        }

        #region Private memenbers
        private IFlickrAPIService _apiService;
        private bool _disposed;
        #endregion
    }
}
