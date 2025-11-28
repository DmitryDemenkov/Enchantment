using TinyJSON;

public class PlayerModel
{
    public CurrentItemModel CurrentItem { get; }
    public SeedModelCollection Seeds { get; }

    public PlayerModel(Variant variant, Descriptions descriptions)
    {
        Seeds = new SeedModelCollection(variant["seeds"]);
        CurrentItem = new CurrentItemModel(variant["current_item"], descriptions, Seeds);
    }

    public PlayerModel()
    {
        CurrentItem = new();
    }
}
