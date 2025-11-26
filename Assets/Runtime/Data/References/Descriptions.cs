using System.Collections.Generic;
using TinyJSON;

public class Descriptions
{
    public ItemDescriptionCollection Items { get; }

    public List<float> Chances { get; }

    public Descriptions(Variant variant)
    {
        var v_items = (ProxyObject)variant["items"];
        Items = new ItemDescriptionCollection("items", v_items);

        Chances = variant["chances"].Make<List<float>>();
    }

    public IReadOnlyList<float> GetChances()
    {
        return Chances;
    }
}
