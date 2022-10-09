using Foundation.Core.Interfaces;
using Foundation.Core.Models;
using Microsoft.Practices.Unity;

namespace BusinessLogic.Flicker.Controller
{
    public class FeedModelProvider : IModelProvider<FeedModel>
    {
        private IFeedPopulator _feedPopulator;
        private bool _isDisposed;

        public FeedModelProvider(IUnityContainer container)
        {
            _feedPopulator = container.Resolve<IFeedPopulator>();
        }
        /// <summary>
        /// Get Intials feed model
        /// </summary>
        /// <returns><see cref="FeedModel"/></returns>
        public FeedModel GetInitialModel()
        {
            return _feedPopulator.GetFeedModel();
        }

        public void Dispose()
        {
            if (!_isDisposed)
            {
                _feedPopulator?.Dispose();
                _feedPopulator = null;
                _isDisposed = true;
            }

        }
    }
}
