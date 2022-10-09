using Foundation.Core.Models;
using System;

namespace BusinessLogic.Flicker.Interfaces
{

    public interface ISearchParameterDataStore : IDisposable
    {
        /// <summary>
        /// Gets the Search Parameter
        /// </summary>
        /// <returns></returns>
        SearchParameters GetSearchParameters();
    }

}
