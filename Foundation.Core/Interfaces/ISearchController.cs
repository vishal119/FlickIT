using System.Threading.Tasks;

namespace Foundation.Core.Interfaces
{
    public interface ISearchController
    {
        /// <summary>
        /// Search the tag
        /// </summary>
        /// <returns></returns>
        Task Search();
    }
}
