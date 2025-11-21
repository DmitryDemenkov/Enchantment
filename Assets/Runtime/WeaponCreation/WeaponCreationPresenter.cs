public class WeaponCreationPresenter
{
    private WeaponCreationModel _weaponCreationModel;
    private WeaponCreationView _weaponCreationView;

    private EnchanceTableModel _enchanceTableModel;

    public WeaponCreationPresenter(WeaponCreationModel weaponCreationModel, WeaponCreationView weaponCreationView, EnchanceTableModel enchanceTableModel)
    {
        _weaponCreationModel = weaponCreationModel;
        _weaponCreationView = weaponCreationView;
        _enchanceTableModel = enchanceTableModel;
    }

    private void OnCreationClicked()
    {
        WeaponModel weapon = _weaponCreationModel.CreateRandomWeapon();
        _enchanceTableModel.SetWeapon(weapon);
    }

    public void Enable()
    {
        _weaponCreationView.AddCreateClickedListener(OnCreationClicked);
    }

    public void Disable()
    {
        _weaponCreationView.RemoveCreateClickedListener(OnCreationClicked);
    }
}
