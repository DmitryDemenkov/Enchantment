using System;
using System.Collections.Generic;

namespace Data.Provider
{
    public class ReactiveCollection<TKey, TValue> : IReactiveCollection<TValue>
    {
        public event Action<TValue> Added;
        public event Action<TValue> Removed;

        public Dictionary<TKey, TValue> Models { get; } = new();

        public TValue Get(TKey id)
        {
            return Models[id];
        }

        public void Add(TKey key, TValue model)
        {
            Models.Add(key, model);
            Added?.Invoke(model);
        }

        public void Remove(TKey id)
        {
            var model = Models[id];
            Models.Remove(id);
            Removed?.Invoke(model);
        }

        public void Clear()
        {
            var models = new Dictionary<TKey, TValue>(Models);

            Models.Clear();

            foreach (var model in models.Values)
            {
                Removed?.Invoke(model);
            }
        }
    }
}
