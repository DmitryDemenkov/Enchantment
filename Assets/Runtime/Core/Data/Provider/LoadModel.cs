using Awaiter;

namespace Data.Provider
{
    public class LoadModel<T>
    {
        public CustomAwaiter LoadAwaiter { get; } = new CustomAwaiter();

        public T Result { get; set; }

        public string Key { get; }

        public LoadModel(string key)
        {
            Key = key;
        }
                 
        public void CompleteLoad()
        {
            LoadAwaiter.Complete();
        }
    }
}
