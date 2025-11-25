using System.Collections.Generic;
using TinyJSON;

public class ItemModel
{
    [Include][DecodeAlias("item")][EncodeAlias("item")]
    public ItemDescription Item { get; private set; }

    [Include][DecodeAlias("level")][EncodeAlias("level")]
    public int Level { get; private set; }

    [Include][DecodeAlias("stats")][EncodeAlias("stats")]
    public Dictionary<string, StatModel> Stats { get; set; }

    public ItemModel(Variant variant, ItemDescriptionCollection itemDescriptionCollection)
    {
        string itemId = (string)variant["item"];
        Item = itemDescriptionCollection.Items[itemId];

        Level = (int)variant["level"];

        var stats = (ProxyObject)variant["stats"];
        Stats = new Dictionary<string, StatModel>();
        foreach(var stat in stats)
        {
            Stats.Add(stat.Key, new StatModel(stat.Key, (int)stat.Value));
        }
    }

    public ItemModel(ItemDescription itemDescription)
    {
        Item = itemDescription;
        Level = 0;

        Stats = new Dictionary<string, StatModel>();
        foreach(var statDescription in itemDescription.StartStats)
        {
            Stats.Add(statDescription.Id, new StatModel(statDescription.Id, statDescription.Value));
        }
    }
}
