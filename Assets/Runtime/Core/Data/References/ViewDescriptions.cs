using Data.References.Common;
using Data.References.Item;
using Data.References.Stat;
using TinyJSON;

namespace Data.References
{
    public class ViewDescriptions
    {
        public DescriptionCollection<StatViewDescription> StatViews { get; }
        public DescriptionCollection<ItemViewDescription> ItemViews { get; }

        public ViewDescriptions(Variant variant)
        {
            StatViews = new("stat_views", variant["stat_views"]);
            ItemViews = new("item_views", variant["item_views"]);
        }
    }
}
