using Data.Model.Item;
using Data.AsyncLoad;
using Data.References;
using UnityEngine;

namespace Enchantment.Stat
{
    public class StatPresenter
    {
        private readonly StatModel _statModel;
        private readonly StatView _statView;
        private AddressableModel _addressableIconProvider;
        private ViewDescriptions _viewDescriptions;

        private LoadModel<Sprite> _loadModel;

        public StatPresenter(StatModel statModel, StatView statView, AddressableModel addressableIconProvider, ViewDescriptions viewDescriptions)
        {
            _statModel = statModel;
            _statView = statView;
            _addressableIconProvider = addressableIconProvider;
            _viewDescriptions = viewDescriptions;
        }

        public async void Enable()
        {
            _statModel.Changed += OnStatChanged;

            var name = _viewDescriptions.StatViews[_statModel.Id].Name;
            _statView.SetName(name);
            _statView.SetValue(_statModel.Value);

            var icon = _viewDescriptions.StatViews[_statModel.Id].Icon;
            _loadModel = _addressableIconProvider.Load<Sprite>(icon);
            await _loadModel.LoadAwaiter;
            _statView.SetIcon(_loadModel.Result);
        }

        public void Disable()
        {
            _statModel.Changed -= OnStatChanged;
            _statView.Destroy();
            _addressableIconProvider.Unload(_loadModel);
        }

        private void OnStatChanged(int value)
        {
            _statView.SetValue(value);
        }
    }
}
