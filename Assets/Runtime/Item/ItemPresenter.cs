using UnityEngine;

public class ItemPresenter
{
    private ItemModel _itemModel;
    private ItemView _itemView;

    public ItemPresenter(ItemModel model, ItemView view)
    {
        _itemModel = model;
        _itemView = view;
    }

    private void OnItemStatsChanged(int level)
    {
        Debug.Log(level);
    }

    public void Enable()
    {
        _itemModel.LevelChanged += OnItemStatsChanged;

        OnItemStatsChanged(_itemModel.Level);
    }

    public void Disable()
    {
        _itemView.ClearTable();

        _itemModel.LevelChanged -= OnItemStatsChanged;
    }
}
