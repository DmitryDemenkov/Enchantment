using System.Collections.Generic;

public class ItemModel
{
    private string _item;
    public string Item { get { return _item; } }

    private int _level;
    public int Level { get { return _level; } }

    private IReadOnlyDictionary<string, int> _states;
    public IReadOnlyDictionary<string, int> States { get { return _states; } }


    public ItemModel(string itemType, int itemLevel, IReadOnlyDictionary<string, int> itemProperties)
    {
        _item = itemType;
        _level = itemLevel;
        _states = itemProperties;
    }

    public void Modify(IReadOnlyDictionary<string, int> itemProperties)
    {
        var modifyItemProperties = new Dictionary<string, int>(itemProperties);

        foreach (var pair in _states)
            modifyItemProperties[pair.Key] = modifyItemProperties.GetValueOrDefault(pair.Key) + pair.Value;

        _states = modifyItemProperties;
        _level++;
    }
}
