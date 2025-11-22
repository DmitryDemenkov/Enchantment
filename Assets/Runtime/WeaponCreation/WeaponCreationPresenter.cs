public class WeaponCreationPresenter
{
    private ItemFactory _factory;
    private WeaponCreationView _weaponCreationView;

    private EnchanceTableModel _enchanceTableModel;

    public WeaponCreationPresenter(ItemFactory factory, WeaponCreationView weaponCreationView, EnchanceTableModel enchanceTableModel)
    {
        _factory = factory;
        _weaponCreationView = weaponCreationView;
        _enchanceTableModel = enchanceTableModel;
    }

    private void OnCreationClicked()
    {
        ItemModel item = _factory.CreateRandomItem();
        _enchanceTableModel.SetCurentItem(item);
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
