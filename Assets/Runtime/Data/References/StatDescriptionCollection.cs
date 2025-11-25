using System.Collections;
using System.Collections.Generic;
using TinyJSON;

public class StatDescriptionCollection : Description, IEnumerable<StatDescription>
{
    public Dictionary<string, StatDescription> Items { get; }

    public StatDescriptionCollection(string id, Variant data) : base(id)
    {
        Items = new Dictionary<string, StatDescription>();

        foreach(var item in (ProxyObject)data)
        {
            Items.Add(item.Key, new StatDescription(item.Key, (int)item.Value));
        }
    }

    public StatDescription this[string key]
    {
        get { return Items[key]; }
    }

    public IEnumerator<StatDescription> GetEnumerator()
    {
        return Items.Values.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
