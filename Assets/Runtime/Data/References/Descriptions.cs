using System.Collections.Generic;
using TinyJSON;

public class Descriptions
{
    public ItemDescriptionCollection Items { get; private set; }

    public List<float> Chances { get; private set; }

    public void SetData(Variant variant)
    {
        var v_items = (ProxyObject)variant["items"];
        Items = new ItemDescriptionCollection("items", v_items);

        Chances = variant["chances"].Make<List<float>>();
    }
}
