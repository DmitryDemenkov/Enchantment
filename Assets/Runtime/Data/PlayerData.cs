using TinyJSON;
using UnityEngine;

public class PlayerData
{
    [Include]
    [DecodeAlias("current_item")]
    [EncodeAlias("current_item")]
    private ItemData _currentItem;
    public ItemData CurrentItem { get { return _currentItem; } set { _currentItem = value; } }
}
