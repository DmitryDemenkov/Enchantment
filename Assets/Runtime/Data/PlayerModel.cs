using TinyJSON;

public class PlayerModel
{
    public CurrentItemModel CurrentItem { get; }

    public PlayerModel(Variant variant, Descriptions descriptions)
    {
        CurrentItem = new CurrentItemModel(variant["current_item"], descriptions.Items);
    }

    public PlayerModel()
    {
        CurrentItem = new();
    }
}
