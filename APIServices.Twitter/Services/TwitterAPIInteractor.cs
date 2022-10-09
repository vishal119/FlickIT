using APIServices.Twitter.Data;
using APIServices.Twitter.Interfaces;
using Foundation.Core.Models;
using Microsoft.Practices.Unity;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Util.Common.Interfaces;

namespace APIServices.Twitter.Services
{
    public class TwitterAPIInteractor : ITwitterAPIServices
    {
        private IInMemoryCache _inMemoryCache;
        public BearerToken BearerToken { get; set; }
        public TwitterAPIInteractor(IUnityContainer container)
        {
            _queryManager = container.Resolve<ITwitterQueryManager>();
            var baseAddress = _queryManager.GetBaseAddress();
            _inMemoryCache = container.Resolve<IInMemoryCache>();
            Initialize(baseAddress);
        }
        public void SetApiKey(string consumerkey, string consumerSecretToken)
        {
            _consumerKey = consumerkey;
            _consumerSecretKey = consumerSecretToken;
            GetBearerToken();
        }
        public void Initialize(string baseAdderess)
        {
            _client = new HttpClient();
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _client.BaseAddress = new Uri(baseAdderess);
        }
        public void GetBearerToken()
        {
            _request = WebRequest.Create(baseAuthUrl) as HttpWebRequest;
            _request.KeepAlive = false;
            _request.Method = "POST";
            _request.Headers.Add("Authorization", string.Format("Basic {0}", _queryManager.GenerateBearerTokenCredentials(_consumerKey,_consumerSecretKey)));
            _request.ContentType = "application/x-www-form-urlencoded;charset=UTF-8";

            byte[] _Content = Encoding.ASCII.GetBytes("grant_type=client_credentials");
            using (Stream _Stream = _request.GetRequestStream())
                _Stream.Write(_Content, 0, _Content.Length);
            try
            {
                HttpWebResponse response = _request.GetResponse() as HttpWebResponse;

                DataContractJsonSerializer accessToken = new DataContractJsonSerializer(typeof(BearerToken));
                BearerToken = (BearerToken)accessToken.ReadObject(response.GetResponseStream());
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public async Task<TwitterResponse> GetTweetsAsync(SearchParameters searchParameters)
        {
            TwitterResponse twitterResponse = null;
            string query = string.Empty;
            try
            {
                 query = _queryManager.GetSearchQuery(searchParameters);
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue($"Bearer", $"{BearerToken.access_token}");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
            if (_inMemoryCache.TryGetValue(query, out TwitterResponse inMemoryValue))
            {
                if (inMemoryValue != null)
                {
                    return inMemoryValue;
                }
            }
            var result = new TwitterResponse();
            using (HttpResponseMessage response = await _client.GetAsync(query))
            {
                try
                {
                    if (response.IsSuccessStatusCode)
                    {
                         result = await response.Content.ReadAsAsync<TwitterResponse>();
                        _inMemoryCache.SetValue(query, result);
                        return result;
                    }
                    else
                    {
                        throw new Exception(response.ReasonPhrase);

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            return twitterResponse;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #region Private region
        private void Dispose(bool disposing)
        {
            if (!_isDisposed)
            {
                if (disposing)
                {
                    _queryManager.Dispose();
                    _queryManager = null;
                }
                _isDisposed = true;
            }
        }
        private HttpClient _client;
        private HttpWebRequest _request;
        private ITwitterQueryManager _queryManager;
        private string _consumerKey;
        private string _consumerSecretKey;
        private bool _isDisposed;
        private const string baseAuthUrl = "https://api.twitter.com/oauth2/token";
        #endregion
    }
}
