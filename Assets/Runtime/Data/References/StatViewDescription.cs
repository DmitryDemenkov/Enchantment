using TinyJSON;

public class StatViewDescription : Description
{
    public string Name { get; }
    public string Icon { get; }

    public StatViewDescription(string id, Variant variant) : base(id)
    {
        Name = variant["name"];
        Icon = variant["icon"];
    }
}
