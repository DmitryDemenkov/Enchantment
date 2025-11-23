using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ItemFactory
{
    private IReadOnlyDictionary<string, IReadOnlyDictionary<string, int>> _items;

    public ItemFactory(IReadOnlyDictionary<string, IReadOnlyDictionary<string, int>> items)
    {
        _items = items;
    }

    public ItemModel CreateItem(string item)
    {
        return new ItemModel(item, 0, _items[item]);
    }

    public ItemModel CreateItem(ItemData itemData)
    {
        return new ItemModel(itemData.Item, itemData.Level, itemData.Stats);
    }

    public ItemModel CreateRandomItem()
    {
        var items = _items.Keys.ToArray();
        string randomItems = items[Random.Range(0, items.Length)];
        return CreateItem(randomItems);
    }
}
