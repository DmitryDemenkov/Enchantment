public class SaveLoadPresenter
{
    private EnchantmentTableModel _enchanceTableModel;
    private ItemFactory _itemFactory;

    public SaveLoadPresenter(EnchantmentTableModel enchanceTableModel, ItemFactory itemFactory)
    {
        _enchanceTableModel = enchanceTableModel;
        _itemFactory = itemFactory;
    }

    private void OnItemChanged(ItemModel itemModel)
    {
        PlayerData playerData = new PlayerData();
        if (itemModel != null)
        {
            playerData.CurrentItem = new ItemData(itemModel);
        }
        DataLoader.SavePlayerData(playerData);
    }

    private void LoadPlayerData()
    {
        PlayerData playerData = DataLoader.LoadPlayerData();
        if (playerData != null)
        {
            ItemModel itemModel = _itemFactory.CreateItem(playerData.CurrentItem);
            _enchanceTableModel.SetCurentItem(itemModel);
        }
    }

    public void Enable()
    {
        _enchanceTableModel.ItemChanged += OnItemChanged;

        LoadPlayerData();
    }

    public void Disable()
    {
        _enchanceTableModel.ItemChanged -= OnItemChanged;
    }
}
