using System;

public class WeaponPresenter
{
    private WeaponModel _weaponModel;
    private WeaponView _weaponView;

    public WeaponPresenter(WeaponModel model, WeaponView view)
    {
        _weaponModel = model;
        _weaponView = view;
    }

    public void Enable()
    {
        int level = _weaponModel.Level;
        string weaponType = Enum.GetName(typeof(WeaponType), _weaponModel.Type);
        var properties = _weaponModel.Properties;

        _weaponView.UpdateInformation(level, weaponType, properties);
    }

    public void Disable()
    {
        _weaponView.ClearTable();
    }
}
