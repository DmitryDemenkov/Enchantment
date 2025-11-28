public class EnchantmentTablePresenter
{
    private CurrentItemModel _currentItem;
    private EnchantmentTableView _enchantmentTableView;
    private ItemPresenter _itemPresenter;

    public EnchantmentTablePresenter(CurrentItemModel currentItem, EnchantmentTableView enchantmentTableView)
    {
        _currentItem = currentItem;
        _enchantmentTableView = enchantmentTableView;
    }

    public void Enable()
    {
        _currentItem.Changed += OnItemChanged;
        _currentItem.Enchanted += OnEnchanted;
        _enchantmentTableView.AddEnchanceClickedListener(OnEnchanceClicked);
    }

    public void Disable()
    {
        DisableItemPresenter();

        _enchantmentTableView.RemoveEnchanceClickedListener(OnEnchanceClicked);
        _currentItem.Enchanted -= OnEnchanted;
        _currentItem.Changed -= OnItemChanged;
    }

    private void OnEnchanceClicked()
    {
        _currentItem.Enchance();
    }

    private void OnEnchanted(EnchantmentResult result)
    {
        _enchantmentTableView.ShowEnchanceResult(result);
    }

    private void OnItemChanged(ItemModel item)
    {
        DisableItemPresenter();
        _enchantmentTableView.ClearResult();

        if (item != null)
        {
            ItemView itemView = _enchantmentTableView.CreateItemView();
            _itemPresenter = new ItemPresenter(item, itemView);
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
}
