using System;
using Util.Common;

namespace Foundation.Core.Interfaces
{
    public interface IModelProvider<out T> : IDisposable where T : NotifyPropertyChanged
    {
        /// <summary>
        /// Gets inital model
        /// </summary>
        /// <returns></returns>
        T GetInitialModel();

    }
}
