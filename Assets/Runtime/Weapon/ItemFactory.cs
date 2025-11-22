using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ItemFactory
{
    private Dictionary<string, IReadOnlyDictionary<string, int>> _items;

    public ItemFactory(Dictionary<string, IReadOnlyDictionary<string, int>> items)
    {
        _items = items;
    }

    public ItemModel CreateItem(string item)
    {
        return new ItemModel(item, 0, _items[item]);
    }

    public ItemModel CreateRandomItem()
    {
        var items = _items.Keys.ToArray();
        string randomItems = items[Random.Range(0, items.Length - 1)];
        return CreateItem(randomItems);
    }
}
