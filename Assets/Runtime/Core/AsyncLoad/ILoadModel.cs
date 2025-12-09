using Awaiter;

namespace Data.AsyncLoad
{
    public interface ILoadModel
    {
        public CustomAwaiter LoadAwaiter { get; }
        public string Key { get; }

        public ILoadPresenter CreatePresenter();
    }
}
