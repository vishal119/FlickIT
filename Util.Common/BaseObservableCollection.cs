using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;

namespace Util.Common
{
    public class BaseObservableCollection : ObservableCollection<BaseModel>
    {
        /// <summary>
        ///  A unique identifier for the Item.
        /// </summary>
        public string Id { get; } = Guid.NewGuid().ToString();

        /// <summary>
        ///     Type of Collection Items
        /// </summary>
        public Type Type { get; } = typeof(BaseModel);

        /// <summary>
        ///  Constructor
        /// </summary>
        /// <param name="type">
        public BaseObservableCollection(Type type)
        {
            if (!typeof(BaseModel).IsAssignableFrom(type))
            {
                throw new ArgumentException($"Passed Type {type} is not derived from {typeof(BaseModel)}");
            }

            Type = type;
        }

        /// <summary>
        ///  Default Constructor
        /// </summary>
        [Obsolete("Do not use default constructor. Use TypeSafe constructor", true)]
        public BaseObservableCollection()
        {
        }

        /// <summary>
        ///  Adds the range.
        /// </summary>
        /// <param name="range">The range.</param>
        /// <exception cref="ArgumentNullException">range</exception>
        public void AddRange<T>(IEnumerable<T> range) where T : BaseModel
        {
            if (range == null)
            {
                throw new ArgumentNullException(nameof(range));
            }

            var items = range.ToList();
            var index = Items.Count;
            foreach (var item in items)
            {
                Items.Add(item);
            }

            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, items, index));
        }

        /// <summary>
        /// Pre-Event to notify clearing of collection
        /// </summary>
        [field: NonSerialized]
        public event EventHandler<EventArgs> Clearing;

        /// <summary>
        /// Removes the range.
        /// </summary>
        /// <param name="startIndex">The start index.</param>
        /// <param name="count">The count.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// startIndex
        /// or
        /// count
        /// </exception>
        public void RemoveRange(int startIndex, int count)
        {
            if (startIndex < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex));
            }

            if (count <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }

            var items = (List<BaseModel>)Items;
            var removedItems = items.GetRange(startIndex, count);
            items.RemoveRange(startIndex, count);
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, removedItems, startIndex));
        }

        /// <summary>
        /// </summary>
        protected override void ClearItems()
        {
            OnClearing(EventArgs.Empty);
            base.ClearItems();
        }

        /// <summary>
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnClearing(EventArgs e)
        {
            Clearing?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the CollectionChanged event with the provided arguments.
        /// </summary>
        /// <param name="e">
        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                var newItems = e.NewItems.Cast<BaseModel>().ToList();
                if (newItems.Any(item => !Type.IsInstanceOfType(item)))
                {
                    var incorrectTypes = newItems.Where(x => !Type.IsInstanceOfType(x))
                        .Select(y => y?.GetType().ToString());
                    throw new ArgumentException(
                        $"Collection<{Type}> was modified with items {string.Join(",", incorrectTypes)} that are not derived from {Type}");
                }
            }

            base.OnCollectionChanged(e);
        }
    }
}
