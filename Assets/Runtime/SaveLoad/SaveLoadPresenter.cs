public class SaveLoadPresenter
{
    private EnchantmentTableModel _enchanceTableModel;
    private ItemFactory _itemFactory;

    public SaveLoadPresenter(EnchantmentTableModel enchanceTableModel, ItemFactory itemFactory)
    {
        _enchanceTableModel = enchanceTableModel;
        _itemFactory = itemFactory;
    }

    private void OnEnchanted(EnchantmentResult result)
    {
        SavePlayerData();
    }

    private void OnItemChanged(ItemModel itemModel)
    {
        SavePlayerData();
    }

    private void SavePlayerData()
    {
        ItemModel itemModel = _enchanceTableModel.CurrentItem;
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
        if (playerData.CurrentItem != null)
        {
            ItemModel itemModel = _itemFactory.CreateItem(playerData.CurrentItem);
            _enchanceTableModel.SetCurentItem(itemModel);
        }
    }

    public void Enable()
    {
        LoadPlayerData();

        _enchanceTableModel.Enchanted += OnEnchanted;
        _enchanceTableModel.ItemChanged += OnItemChanged;
    }

    public void Disable()
    {
        _enchanceTableModel.ItemChanged -= OnItemChanged;
        _enchanceTableModel.Enchanted -= OnEnchanted;
    }
}
