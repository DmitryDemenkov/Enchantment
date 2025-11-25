using TinyJSON;

public class ItemDescription : Description
{
    public StatDescriptionCollection StartStats { get; }

    public StatDescriptionCollection IncreaseStats { get; }

    public ItemDescription(string id, Variant variant) : base(id)
    {
        StartStats = new StatDescriptionCollection("start_stats", variant["start_stats"]);
        IncreaseStats = new StatDescriptionCollection("increase_starts", variant["increase_stats"]);
    }
}
