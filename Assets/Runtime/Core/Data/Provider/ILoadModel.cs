using Awaiter;

namespace Data.Provider
{
    public interface ILoadModel
    {
        public CustomAwaiter LoadAwaiter { get; }
        public string Key { get; }

        public ILoadPresenter CreatePresenter();
    }
}
