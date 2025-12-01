using System;
using System.Collections;
using System.Collections.Generic;
using TinyJSON;

public class DescriptionCollection<T> : Description, IEnumerable<T> where T: Description
{
    public Dictionary<string, T> Items { get; }

    public DescriptionCollection(string id, Variant data) : base(id)
    {
        Items = new Dictionary<string, T>();

        foreach(var item in (ProxyObject)data)
        {
            object[] parameters = {item.Key, item.Value };
            Items.Add(item.Key, (T)Activator.CreateInstance(typeof(T), parameters));
        }
    }

    public T this[string key]
    {
        get { return Items[key]; }
    }

    public IEnumerator<T> GetEnumerator()
    {
        return Items.Values.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
