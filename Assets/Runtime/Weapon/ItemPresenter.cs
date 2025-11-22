using System;

public class ItemPresenter
{
    private ItemModel _itemModel;
    private WeaponView _weaponView;

    public ItemPresenter(ItemModel model, WeaponView view)
    {
        _itemModel = model;
        _weaponView = view;
    }

    public void Enable()
    {
        int level = _itemModel.Level;
        string weaponType = _itemModel.Item;
        var properties = _itemModel.States;

        _weaponView.UpdateInformation(level, weaponType, properties);
    }

    public void Disable()
    {
        _weaponView.ClearTable();
    }
}
