using APIServices.Twitter.Data;
using System;

namespace APIServices.Twitter.Interfaces
{
    public interface ITwitterQueryBuilder : IDisposable
    {
        /// <summary>
        /// Set the search Parameter
        /// </summary>
        /// <param name="parameter"></param>
        void SetSearchQuery(string parameter);
        /// <summary>
        /// Type of result
        /// </summary>
        /// <param name="type"></param>
        void SetResultType(ResultType type);
       /// <summary>
       /// Set count of tweets
       /// </summary>
       /// <param name="type"></param>
        void SetCount(int type);
        /// <summary>
        /// Build the search query
        /// </summary>
        string BuildQuery();
        /// <summary>
        /// Reset query values
        /// </summary>
        void ResetQuery();
    }
}
