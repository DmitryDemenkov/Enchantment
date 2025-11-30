using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class AddressableIconProvider
{
    public async Task<IconHandle> LoadIconAsync(string viewId)
    {
        string address = viewId;
        AsyncOperationHandle<Sprite> handle = Addressables.LoadAssetAsync<Sprite>(address);

        // Имитируем задержку сети
        await Task.Delay(2000);

        Sprite sprite = await handle.Task;
        if (handle.Status == AsyncOperationStatus.Failed || sprite == null)
        {
            Addressables.Release(handle);
            return null;
        }

        return new IconHandle(handle);
    }

    public void ReleaseIcon(IconHandle iconHandle)
    {
        if (iconHandle.Handle.IsValid())
        {
            Addressables.Release(iconHandle.Handle);
        }
    }
}
