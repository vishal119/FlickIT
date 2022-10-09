using System;

namespace Util.Common
{
    public abstract class BaseModel : NotifyPropertyChanged
    {
        /// <summary>
        /// A unique identifier for the Item.
        /// </summary>
        public string Id { get; } = Guid.NewGuid().ToString();

        protected BaseModel()
        {
        }

        /// <summary>
        ///     Check for equality of the models
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return obj is BaseModel comparingModel && comparingModel.Id.Equals(Id);
        }

        /// <summary>
        ///  Overrides the hashcode and provide the default implementation
        /// </summary>
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
