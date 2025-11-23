using System.Collections.Generic;
using TinyJSON;

public class ItemData
{
    [Include]
    [DecodeAlias("item")]
    [EncodeAlias("item")]
    private string _item;
    public string Item { get { return _item; } }

    [Include]
    [DecodeAlias("level")]
    [EncodeAlias("level")]
    private int _level;
    public int Level { get { return _level; } }

    [Include]
    [DecodeAlias("stats")]
    [EncodeAlias("stats")]
    private Dictionary<string, int> _stats;
    public Dictionary<string, int> Stats { get { return _stats; } }

    public ItemData() { }

    public ItemData(ItemModel itemModel)
    {
        _item = itemModel.Item;
        _level = itemModel.Level;
        _stats = new(itemModel.States);
    }
}
