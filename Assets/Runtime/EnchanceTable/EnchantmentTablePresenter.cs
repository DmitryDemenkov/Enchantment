public class EnchantmentTablePresenter
{
    private CurrentItemModel _currentItem;
    private EnchantmentTableView _enchantmentTableView;

    private ItemView _itemView;
    private ItemPresenter _itemPresenter;

    public EnchantmentTablePresenter(CurrentItemModel currentItem, EnchantmentTableView enchantmentTableView, ItemView itemView)
    {
        _currentItem = currentItem;
        _enchantmentTableView = enchantmentTableView;
        _itemView = itemView;
    }

    public void Enable()
    {
        _currentItem.Changed += OnItemChanged;
        _enchantmentTableView.AddEnchanceClickedListener(OnEnchanceClicked);
    }

    public void Disable()
    {
        DisableItemPresenter();

        _enchantmentTableView.RemoveEnchanceClickedListener(OnEnchanceClicked);
        _currentItem.Changed -= OnItemChanged;
    }

    private void OnEnchanceClicked()
    {
        
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
}
