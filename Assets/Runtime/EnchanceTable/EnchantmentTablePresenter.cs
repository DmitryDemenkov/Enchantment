public class EnchantmentTablePresenter
{
    private EnchantmentTableModel _enchantmentTableModel;
    private EnchantmentTableView _enchantmentTableView;

    private ItemView _itemView;
    private ItemPresenter _itemPresenter;

    public EnchantmentTablePresenter(EnchantmentTableModel enchantmentTableModel, EnchantmentTableView enchantmentTableView, ItemView itemView)
    {
        _enchantmentTableModel = enchantmentTableModel;
        _enchantmentTableView = enchantmentTableView;
        _itemView = itemView;
    }

    private void OnEnchanceClicked()
    {
        bool isEnchanted = _enchantmentTableModel.Enchance();
        _enchantmentTableView.ShowEnchanceResult(isEnchanted);
    }

    private void OnItemChanged(ItemModel item)
    {
        DisableItemPresenter();
        _enchantmentTableView.ClearResult();

        if (item != null)
        {
            _itemPresenter = new ItemPresenter(item, _itemView);
            _itemPresenter.Enable();
        }
    }

    private void DisableItemPresenter()
    {
        if (_itemPresenter != null)
        {
            _itemPresenter.Disable();
        }
        _itemPresenter = null;
    }

    public void Enable()
    {
        _enchantmentTableModel.ItemChanged += OnItemChanged;
        _enchantmentTableView.AddEnchanceClickedListener(OnEnchanceClicked);
    }

    public void Disable()
    {
        DisableItemPresenter();

        _enchantmentTableView.RemoveEnchanceClickedListener(OnEnchanceClicked);
        _enchantmentTableModel.ItemChanged -= OnItemChanged;
    }
}
