using System.Collections.Generic;

namespace Data.AsyncLoad
{
    public class AddressablePresenter
    {
        private AddressableModel _addressablModel;
        private Dictionary<ILoadModel, ILoadPresenter> _loadPresenters = new();

        public AddressablePresenter(AddressableModel addressablModel)
        {
            _addressablModel = addressablModel;
        }

        public void Enable()
        {
            _addressablModel.LoadModels.Added += OnModelAdded;
            _addressablModel.LoadModels.Removed += OnModelRemoved;
        }

        public void Disable()
        {
            _addressablModel.UnloadAll();
            _addressablModel.LoadModels.Added -= OnModelAdded;
            _addressablModel.LoadModels.Removed -= OnModelRemoved;
        }

        public void OnModelAdded(ILoadModel loadModel)
        {
            var presenter = loadModel.CreatePresenter();

            _loadPresenters.Add(loadModel, presenter);
            presenter.Enable();
        }

        public void OnModelRemoved(ILoadModel loadModel)
        {
            if (_loadPresenters.TryGetValue(loadModel, out var presenter))
            {
                presenter.Disable();
                _loadPresenters.Remove(loadModel);
            }
        }
    }
}
