using Data.References.Common;
using Data.References.Item;
using System.Collections.Generic;
using TinyJSON;

namespace Data.References
{
    public class Descriptions
    {
        public DescriptionCollection<ItemDescription> Items { get; private set; }
        public ViewDescriptions ViewDescriptions { get; private set; }

        public List<float> Chances { get; private set; }

        public void SetData(Variant variant)
        {
            Items = new DescriptionCollection<ItemDescription>("items", variant["items"]);
            ViewDescriptions = new ViewDescriptions(variant["views"]);

            Chances = variant["chances"].Make<List<float>>();
        }
    }
}
