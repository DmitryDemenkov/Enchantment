using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;

public class IconHandle
{
    public AsyncOperationHandle<Sprite> Handle { get; }

    public Sprite Sprite => Handle.Result;

    public IconHandle(AsyncOperationHandle<Sprite> handle)
    {
        Handle = handle;
    }
}
