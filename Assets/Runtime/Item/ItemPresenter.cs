using System.Collections.Generic;

public class ItemPresenter
{
    private ItemModel _itemModel;
    private ItemView _itemView;
    private List<StatPresenter> _statPresenters = new List<StatPresenter>();

    public ItemPresenter(ItemModel model, ItemView view)
    {
        _itemModel = model;
        _itemView = view;
    }

    private void OnItemLevelChanged(int level)
    {
        _itemView.UpdateLevel(level);
    }

    public void Enable()
    {
        _itemModel.LevelChanged += OnItemLevelChanged;

        _itemView.UpdateInformation(_itemModel.Level, _itemModel.Item.Id);

        foreach (var pair in _itemModel.Stats)
        {
            StatView statView = _itemView.CreateStatView();
            var statPresenter = new StatPresenter(pair.Value, statView);
            statPresenter.Enable();
            _statPresenters.Add(statPresenter);
        }
    }

    public void Disable()
    {
        foreach (var statPresenter in _statPresenters)
        {
            statPresenter.Disable();
        }
        _statPresenters.Clear();

        _itemModel.LevelChanged -= OnItemLevelChanged;

        _itemView.Destroy();
    }
}
