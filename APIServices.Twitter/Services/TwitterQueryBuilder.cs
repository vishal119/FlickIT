using APIServices.Twitter.Data;
using APIServices.Twitter.Interfaces;
using System.Collections.Generic;

namespace APIServices.Twitter.Services
{
    public class TwitterQueryBuilder : ITwitterQueryBuilder
    {
        private IList<string> _listOfParameters = new List<string>();
        private bool _isDisposed;

        public void SetCount(int type)
        {
            _listOfParameters.Add($"count={type}");
        }

        public void SetResultType(ResultType type)
        {
            _listOfParameters.Add($"result_type={type.ToString()}");
        }

        public void SetSearchQuery(string tags)
        {
            //Need to check auth issue
            if (tags != null)
            {
                _listOfParameters.Add($"q={tags}");
            }
        }
        public string BuildQuery()
        {
            string result = "?";
            if (_listOfParameters.Count > 0)
            {
                result += string.Join("&", _listOfParameters);
            }
            return result;
        }
        public void ResetQuery()
        {
            _listOfParameters.Clear();
        }
        public void Dispose()
        {
            if (!_isDisposed)
            {
                ResetQuery();
                _listOfParameters = null;
                _isDisposed = true;
            }
        }
    }
}
