using System.Collections.Generic;
using TinyJSON;

public class ItemData
{
    [Include][DecodeAlias("item")][EncodeAlias("item")]
    public string Item { get; private set; }

    [Include][DecodeAlias("level")][EncodeAlias("level")]
    public int Level { get; private set; }

    [Include][DecodeAlias("stats")][EncodeAlias("stats")]
    public Dictionary<string, int> Stats { get; set; }

    public ItemData() { }

    public ItemData(ItemModel itemModel)
    {
        Item = itemModel.Item;
        Level = itemModel.Level;
        Stats = new(itemModel.Stats);
    }
}
