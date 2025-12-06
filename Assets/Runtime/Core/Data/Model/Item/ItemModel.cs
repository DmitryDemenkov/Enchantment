using Data.References.Common;
using Data.References.Item;
using System;
using System.Collections.Generic;
using System.Text;
using TinyJSON;

namespace Data.Model.Item
{
    public class ItemModel
    {
        public event Action<int> LevelChanged;

        public ItemDescription Item { get; private set; }

        public int Level { get; private set; }

        public Dictionary<string, StatModel> Stats { get; set; }

        public ItemModel(Variant variant, DescriptionCollection<ItemDescription> itemDescriptionCollection)
        {
            string itemId = variant["item"];
            Item = itemDescriptionCollection.Items[itemId];

            Level = variant["level"];

            var stats = (ProxyObject)variant["stats"];
            Stats = new Dictionary<string, StatModel>();
            foreach (var stat in stats)
            {
                Stats.Add(stat.Key, new StatModel(stat.Key, stat.Value));
            }
        }

        public ItemModel(ItemDescription itemDescription)
        {
            Item = itemDescription;
            Level = 0;

            Stats = new Dictionary<string, StatModel>();
            foreach (var statDescription in itemDescription.StartStats)
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
            foreach (var stat in Stats)
            {
                statsbuilder = statsbuilder.Append($"{stat.Value.Serialize()},");
            }
            statsbuilder[^1] = '}';

            return $"{{\"item\":\"{Item.Id}\",\"level\":{Level},\"stats\":{statsbuilder}}}";
        }
    }
}
