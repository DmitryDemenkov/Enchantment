public class ItemPresenter
{
    private ItemModel _itemModel;
    private ItemView _itemView;

    public ItemPresenter(ItemModel model, ItemView view)
    {
        _itemModel = model;
        _itemView = view;
    }

    private void OnItemStatsChanged()
    {
        int level = _itemModel.Level;
        string itemId = _itemModel.Item.Id;
        var properties = _itemModel.Stats;
    }

    public void Enable()
    {

        OnItemStatsChanged();
    }

    public void Disable()
    {
        _itemView.ClearTable();
    }
}
