using BusinessLogic.Twitter.Interfaces;
using Foundation.Core.Interfaces;
using Foundation.Core.Models;
using Microsoft.Practices.Unity;

namespace BusinessLogic.Twitter.Controller
{
    public class TwitterModelProvider : IModelProvider<TwitterFeedModel>
    {
        private ITwitterFeedPopulator _feedPopulator;
        private bool _isDisposed;

        public TwitterModelProvider(IUnityContainer container)
        {
            _feedPopulator = container.Resolve<ITwitterFeedPopulator>();
        }
        /// <summary>
        /// Get Intials feed model
        /// </summary>
        /// <returns><see cref="TwitterFeedModel"/></returns>
        public TwitterFeedModel GetInitialModel()
        {
            return _feedPopulator.GetTwitterFeedModel();
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
