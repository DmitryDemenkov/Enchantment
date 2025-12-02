using Data.Model.Item;

namespace Enchantment.ItemCreation
{
    public class ItemСreationPresenter
    {
        private ItemСreationView _itemCreationView;
        private CurrentItemModel _currentItem;

        public ItemСreationPresenter(ItemСreationView itemCreationView, CurrentItemModel currentItem)
        {
            _itemCreationView = itemCreationView;
            _currentItem = currentItem;
        }

        private void OnCreationClicked()
        {
            _currentItem.Change();
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
}
