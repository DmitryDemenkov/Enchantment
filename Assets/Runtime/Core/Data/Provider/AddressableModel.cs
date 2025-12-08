using System;
using System.Collections.Generic;

namespace Data.Provider
{
    public class AddressableModel
    {
       
        // TODO реактивная коллекция моделей
        private ReactiveCollection<string, ILoadModel> _loadModels = new ReactiveCollection<string, ILoadModel>();

        public IReactiveCollection<ILoadModel> LoadModels { get { return _loadModels; } }

        public LoadModel<T> Load<T>(string key)
        {
            var model = new LoadModel<T>(key);

            _loadModels.Add(key, model);           

            return model;
        }

        // TODO Unload
        public void Unload<T>(LoadModel<T> loadModel)
        {
            _loadModels.Remove(loadModel.Key);            
        }

        public void UnloadAll()
        {
            _loadModels.Clear();
        }
    }
}


