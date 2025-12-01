using System.Collections.Generic;

public class ItemPresenter
{
    private ItemModel _itemModel;
    private ItemView _itemView;
    private List<StatPresenter> _statPresenters = new List<StatPresenter>();
    private AddressableIconProvider _addressableIconProvider;
    private ViewDescriptions _viewDescriptions;

    private IconHandle _iconHandle;
    private int _iconLoadVersion;

    public ItemPresenter(ItemModel model, ItemView view, AddressableIconProvider addressableIconProvider, ViewDescriptions viewDescriptions)
    {
        _itemModel = model;
        _itemView = view;
        _addressableIconProvider = addressableIconProvider;
        _viewDescriptions = viewDescriptions;
    }

    private void OnItemLevelChanged(int level)
    {
        _itemView.UpdateLevel(level);
    }

    public void Enable()
    {
        _itemModel.LevelChanged += OnItemLevelChanged;

        var name = _viewDescriptions.ItemViews[_itemModel.Item.Id].Name;
        _itemView.UpdateInformation(_itemModel.Level, name);

        _iconLoadVersion++;
        int currentVersion = _iconLoadVersion;
        LoadIconAsync(currentVersion);

        foreach (var pair in _itemModel.Stats)
        {
            StatView statView = _itemView.CreateStatView();
            var statPresenter = new StatPresenter(pair.Value, statView, _addressableIconProvider, _viewDescriptions);
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

        _iconLoadVersion++;

        if (_iconHandle != null)
        {
            _addressableIconProvider.ReleaseIcon(_iconHandle);
            _iconHandle = null;
        }

        _itemView.Destroy();
    }

    private async void LoadIconAsync(int version)
    {
        var icon = _viewDescriptions.ItemViews[_itemModel.Item.Id].Icon;
        IconHandle handle = await _addressableIconProvider.LoadIconAsync(icon);
       
        if (version == _iconLoadVersion)
        {
            _iconHandle = handle;

            if (_iconHandle != null && _iconHandle.Sprite != null)
            {
                _itemView.SetIcon(_iconHandle.Sprite);
            }
        }
        else
        {
            if (handle != null)
            {
                _addressableIconProvider.ReleaseIcon(handle);
            }
        }
    }
}
