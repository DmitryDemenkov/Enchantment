using System.Collections.Generic;
using TinyJSON;

public class Descriptions
{
    public ItemDescriptionCollection Items { get; }

    [Include]
    [DecodeAlias("chances")]
    private List<float> _chances;

    public Descriptions(Variant variant)
    {
        var v_items = (ProxyObject)variant["items"];
        Items = new ItemDescriptionCollection("items", v_items);
    }

    public IReadOnlyList<float> GetChances()
    {
        return _chances;
    }
}
