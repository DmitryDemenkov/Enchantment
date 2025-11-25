using System;
using System.Collections.Generic;

public class ItemModel
{
    public event Action StatsChanged;

    private string _item;
    public string Item { get { return _item; } }

    private int _level;
    public int Level { get { return _level; } }

    private IReadOnlyDictionary<string, int> _stats;
    public IReadOnlyDictionary<string, int> Stats { get { return _stats; } }


    public ItemModel(string itemType, int itemLevel, IReadOnlyDictionary<string, int> itemProperties)
    {
        _item = itemType;
        _level = itemLevel;
        _stats = itemProperties;
    }

    public void Modify(IReadOnlyDictionary<string, int> itemProperties)
    {
        var modifyItemProperties = new Dictionary<string, int>(itemProperties);

        foreach (var pair in _stats)
            modifyItemProperties[pair.Key] = modifyItemProperties.GetValueOrDefault(pair.Key) + pair.Value;

        _stats = modifyItemProperties;
        _level++;

        StatsChanged?.Invoke();
    }
}
