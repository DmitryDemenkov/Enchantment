using TinyJSON;

public class ItemDescription : Description
{
    public DescriptionCollection<StatDescription> StartStats { get; }

    public DescriptionCollection<StatDescription> IncreaseStats { get; }

    public ItemDescription(string id, Variant variant) : base(id)
    {
        StartStats = new DescriptionCollection<StatDescription>("start_stats", variant["start_stats"]);
        IncreaseStats = new DescriptionCollection<StatDescription>("increase_starts", variant["increase_stats"]);
    }
}
