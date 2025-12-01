using System.Collections.Generic;
using TinyJSON;

public class Descriptions
{
    public DescriptionCollection<ItemDescription> Items { get; private set; }

    public List<float> Chances { get; private set; }

    public void SetData(Variant variant)
    {
        Items = new DescriptionCollection<ItemDescription>("items", variant["items"]);

        Chances = variant["chances"].Make<List<float>>();
    }
}
