using APIServices.Twitter.Interfaces;
using Foundation.Core.Models;
using Microsoft.Practices.Unity;
using System;
using System.Text;

namespace APIServices.Twitter.Services
{
    public class TwitterQueryManager : ITwitterQueryManager
    {
        public ITwitterQueryBuilder QueryBuilder { set => _queryBuilder = value; }

        public TwitterQueryManager(IUnityContainer container)
        {
            QueryBuilder = container.Resolve<ITwitterQueryBuilder>();
            _baseURL = "https://api.twitter.com/1.1/search/tweets.json";
        }
        public string GenerateBearerTokenCredentials(string consumerKey, string consumerSecretToken)
        {
            string BearerTokenCredentials =
              Convert.ToBase64String(
                  Encoding.ASCII.GetBytes(
                      string.Format("{0}:{1}",
                          Uri.EscapeUriString(consumerKey),
                          Uri.EscapeUriString(consumerSecretToken))));

            return BearerTokenCredentials;
        }

        public string GetBaseAddress()
        {
            return _baseURL;
        }

        public string GetSearchQuery(SearchParameters searchParameters)
        {

            string _apiQuery = string.Empty;
            try
            {
                _queryBuilder.SetSearchQuery(searchParameters.SearchTag);
                _queryBuilder.SetResultType(Data.ResultType.mixed);
                _queryBuilder.SetCount(15);
                _apiQuery = _queryBuilder.BuildQuery();
                _queryBuilder.ResetQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return _apiQuery;
        }

        private ITwitterQueryBuilder _queryBuilder;
        private readonly string _baseURL;
        private bool _isDisposed;

        #region Dispose Pattern
        public void Dispose()
        {
            if (!_isDisposed)
            {
                _queryBuilder.Dispose();
                _isDisposed = true;
            }

        }
        #endregion
    }
}
