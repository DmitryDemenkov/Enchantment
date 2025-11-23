public class ItemСreationPresenter
{
    private ItemFactory _factory;
    private ItemСreationView _itemCreationView;

    private EnchantmentTableModel _enchantmentTableModel;

    public ItemСreationPresenter(ItemFactory factory, ItemСreationView itemCreationView, EnchantmentTableModel enchantmentTableModel)
    {
        _factory = factory;
        _itemCreationView = itemCreationView;
        _enchantmentTableModel = enchantmentTableModel;
    }

    private void OnCreationClicked()
    {
        ItemModel item = _factory.CreateRandomItem();
        _enchantmentTableModel.SetCurentItem(item);
    }

    public void Enable()
    {
        _itemCreationView.AddCreateClickedListener(OnCreationClicked);
    }

    public void Disable()
    {
        _itemCreationView.RemoveCreateClickedListener(OnCreationClicked);
    }
}
