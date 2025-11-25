using System.Collections.Generic;
using TinyJSON;

public class ItemDescriptionCollection : Description
{
    public Dictionary<string, ItemDescription> Items { get; }

    public ItemDescriptionCollection(string id, Variant items) : base(id)
    {
        Items = new();
        foreach (var item in (ProxyObject)items)
        {
            Items.Add(item.Key, new ItemDescription(item.Key, item.Value));
        }
    }
}
