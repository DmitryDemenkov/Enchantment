using Data.Model.Item;
using Data.Provider;
using Data.References;
using Enchantment.Stat;
using System.Collections.Generic;
using UnityEngine;

namespace Enchantment.Item
{
    public class ItemPresenter
    {
        private ItemModel _itemModel;
        private ItemView _itemView;
        private List<StatPresenter> _statPresenters = new List<StatPresenter>();
        private AddressableModel _addressableIconProvider;
        private ViewDescriptions _viewDescriptions;

        private LoadModel<Sprite> _loadModel;

        public ItemPresenter(ItemModel model, ItemView view, AddressableModel addressableIconProvider, ViewDescriptions viewDescriptions)
        {
            _itemModel = model;
            _itemView = view;
            _addressableIconProvider = addressableIconProvider;
            _viewDescriptions = viewDescriptions;
        }

        private void OnItemLevelChanged(int level)
        {
            _itemView.UpdateLevel(level);
        }

        public async void Enable()
        {
            _itemModel.LevelChanged += OnItemLevelChanged;

            var name = _viewDescriptions.ItemViews[_itemModel.Item.Id].Name;
            _itemView.UpdateInformation(_itemModel.Level, name);

            var icon = _viewDescriptions.ItemViews[_itemModel.Item.Id].Icon;
            _loadModel = _addressableIconProvider.Load<Sprite>(icon);

            foreach (var pair in _itemModel.Stats)
            {
                StatView statView = _itemView.CreateStatView();
                var statPresenter = new StatPresenter(pair.Value, statView, _addressableIconProvider, _viewDescriptions);
                statPresenter.Enable();
                _statPresenters.Add(statPresenter);
            }

            await _loadModel.LoadAwaiter;
            _itemView.SetIcon(_loadModel.Result);
        }

        public void Disable()
        {
            _itemModel.LevelChanged -= OnItemLevelChanged;

            foreach (var statPresenter in _statPresenters)
            {
                statPresenter.Disable();
            }
            _statPresenters.Clear();

            _itemView.Destroy();
            // TODO _addressableIconProvider.Unload(_loadModel);
        }
    }
}
