using Data.References.Common;
using TinyJSON;

namespace Data.References.Item
{
    public class ItemViewDescription : Description
    {
        public string Name { get; }
        public string Icon { get; }

        public ItemViewDescription(string id, Variant variant) : base(id)
        {
            Name = variant["name"];
            Icon = variant["icon"];
        }
    }
}
