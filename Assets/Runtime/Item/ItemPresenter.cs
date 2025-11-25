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
        string itemType = _itemModel.Item;
        var properties = _itemModel.Stats;

        _itemView.UpdateInformation(level, itemType, properties);
    }

    public void Enable()
    {
        _itemModel.StatsChanged += OnItemStatsChanged;

        OnItemStatsChanged();
    }

    public void Disable()
    {
        _itemModel.StatsChanged -= OnItemStatsChanged;
        _itemView.ClearTable();
    }
}
