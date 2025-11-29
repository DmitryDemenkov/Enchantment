using System;
using System.Collections.Generic;
using System.Text;
using TinyJSON;

public class ItemModel
{
    public event Action<int> LevelChanged;

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

    public void Enchance()
    {
        var increaseStats = Item.IncreaseStats;
        foreach (var stat in increaseStats)
        {
            Stats[stat.Id].Add(stat.Value);
        }

        Level++;
        LevelChanged?.Invoke(Level);
    }

    public string Serialize()
    {
        StringBuilder statsbuilder = new StringBuilder("{");
        foreach(var stat in Stats)
        {
            statsbuilder = statsbuilder.Append($"{stat.Value.Serialize()},");
        }
        statsbuilder[^1] = '}';

        return $"{{\"item\":\"{Item.Id}\",\"level\":{Level},\"stats\":{statsbuilder}}}";
    }
}
