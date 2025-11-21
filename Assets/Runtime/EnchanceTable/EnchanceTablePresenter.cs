public class EnchanceTablePresenter
{
    private EnchanceTableModel _enchanceTableModel;
    private EnchancerTableView _enchancerTableView;

    private WeaponView _weaponView;
    private WeaponPresenter _weaponPresenter;

    public EnchanceTablePresenter(EnchanceTableModel enchanceTableModel, EnchancerTableView enchancerTableView, WeaponView weaponView)
    {
        _enchanceTableModel = enchanceTableModel;
        _enchancerTableView = enchancerTableView;
        _weaponView = weaponView;
    }

    private void OnEnchanceClicked()
    {
        bool isEnchanted = _enchanceTableModel.Enchance();
        _enchancerTableView.ShowEnchanceResult(isEnchanted);
    }

    private void OnWeaponChanged(WeaponModel weapon)
    {
        DisableWeaponPresenter();
        _enchancerTableView.ClearResult();

        if (weapon != null)
        {
            _weaponPresenter = new WeaponPresenter(weapon, _weaponView);
            _weaponPresenter.Enable();
        }
    }

    private void DisableWeaponPresenter()
    {
        if (_weaponPresenter != null)
        {
            _weaponPresenter.Disable();
        }
        _weaponPresenter = null;
    }

    public void Enable()
    {
        _enchanceTableModel.WeaponChanged += OnWeaponChanged;
        _enchancerTableView.AddEnchanceClickedListener(OnEnchanceClicked);
    }

    public void Disable()
    {
        DisableWeaponPresenter();

        _enchancerTableView.RemoveEnchanceClickedListener(OnEnchanceClicked);
        _enchanceTableModel.WeaponChanged -= OnWeaponChanged;
    }
}
