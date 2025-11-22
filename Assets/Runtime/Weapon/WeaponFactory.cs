using System.Collections.Generic;

public class WeaponFactory
{
    private Dictionary<string, IReadOnlyDictionary<string, int>> _items;

    public WeaponFactory(Dictionary<string, IReadOnlyDictionary<string, int>> items)
    {
        _items = items;
    }

    public ItemModel CreateItem(string item)
    {
        return new ItemModel(item, 0, _items[item]);
    }
}
