using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Data.Provider
{
    public class AddressableIconProvider
    {
        public async Task<IconHandle> LoadIconAsync(string viewId)
        {
            AsyncOperationHandle<Sprite> handle = Addressables.LoadAssetAsync<Sprite>(viewId);
            await handle.Task;

            if (handle.Status == AsyncOperationStatus.Failed || handle.Result == null)
            {
                Debug.LogError($"Failed to load icon {viewId}: {handle.OperationException}");
                Addressables.Release(handle);
                //throw new Exception($"Failed to load icon {viewId}: {handle.OperationException}");
                return null;
            }

            // Задержка для тестирования
            await Task.Delay(2000);

            return new IconHandle(handle);
        }

        public void ReleaseIcon(IconHandle iconHandle)
        {
            if (iconHandle?.Handle.IsValid() == true)
            {
                Addressables.Release(iconHandle.Handle);
            }
        }
    }
}
