using Data.Model.Item;
using Data.Provider;
using Data.References;
using Enchantment.Item;

namespace Enchantment.EnchanceTable
{
    public class EnchantmentTablePresenter
    {
        private CurrentItemModel _currentItem;
        private EnchantmentTableView _enchantmentTableView;
        private ItemPresenter _itemPresenter;
        private AddressableModel _addressableIconProvider;
        private ViewDescriptions _viewDescriptions;

        public EnchantmentTablePresenter(CurrentItemModel currentItem, EnchantmentTableView enchantmentTableView, AddressableModel addressableIconProvider, ViewDescriptions viewDescriptions)
        {
            _currentItem = currentItem;
            _enchantmentTableView = enchantmentTableView;
            _addressableIconProvider = addressableIconProvider;
            _viewDescriptions = viewDescriptions;
        }

        public void Enable()
        {
            _currentItem.Changed += OnItemChanged;
            _currentItem.Enchanted += OnEnchanted;
            _enchantmentTableView.AddEnchanceClickedListener(OnEnchanceClicked);

            OnItemChanged(_currentItem.Current);
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
                _itemPresenter = new ItemPresenter(item, itemView, _addressableIconProvider, _viewDescriptions);
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
}
