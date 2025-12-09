using System;

namespace Data.AsyncLoad
{
    public interface IReactiveCollection<out T>
    {
        public event Action<T> Added;
        public event Action<T> Removed;
    }
}
