using System;

namespace Data.Provider
{
    public interface IReactiveCollection<out T>
    {
        public event Action<T> Added;
        public event Action<T> Removed;
    }
}
