namespace Util.Common.Interfaces
{
    public interface IInMemoryCache
    {
        /// <summary>
        /// Get the value of item
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        bool TryGetValue<T>(string key, out T value);
        /// <summary>
        /// Set the value of item
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        void SetValue<T>(string key, T value);
    }
}
