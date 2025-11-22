public class EnchanceTablePresenter
{
    private EnchanceTableModel _enchanceTableModel;
    private EnchancerTableView _enchancerTableView;

    private WeaponView _weaponView;
    private ItemPresenter _weaponPresenter;

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

    private void OnItemChanged(ItemModel item)
    {
        DisableWeaponPresenter();
        _enchancerTableView.ClearResult();

        if (item != null)
        {
            _weaponPresenter = new ItemPresenter(item, _weaponView);
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
        _enchanceTableModel.WeaponChanged += OnItemChanged;
        _enchancerTableView.AddEnchanceClickedListener(OnEnchanceClicked);
    }

    public void Disable()
    {
        DisableWeaponPresenter();

        _enchancerTableView.RemoveEnchanceClickedListener(OnEnchanceClicked);
        _enchanceTableModel.WeaponChanged -= OnItemChanged;
    }
}
