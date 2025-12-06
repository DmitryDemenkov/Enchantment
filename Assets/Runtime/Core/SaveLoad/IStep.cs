using System.Threading.Tasks;

namespace SaveLoad
{
    public interface IStep
    {
        public Task Execute();
    }
}
