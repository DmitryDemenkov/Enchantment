using System;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Data.Provider
{
    public class AddressableModel
    {
        // TODO реактивная коллекция моделей

        public LoadModel<T> Load<T>(string key)
        {
            var model = new LoadModel<T>(key);
            var presenter = new LoadPresenter<T>(model);

            presenter.Enable();
            return model;
        }

        // TODO Unload
    }
}


