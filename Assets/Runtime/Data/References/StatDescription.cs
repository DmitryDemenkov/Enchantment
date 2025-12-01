using TinyJSON;

public class StatDescription : Description
{
    public int Value { get; }

    public StatDescription(string id, Variant variant) : base(id)
    {
        Value = (int)variant;
    }
}
