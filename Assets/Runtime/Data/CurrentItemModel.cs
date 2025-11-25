using System;
using System.Linq;
using TinyJSON;

public class CurrentItemModel
{
    public event Action<ItemModel> Changed;

    public ItemModel Current { get; private set; }

    private ItemDescriptionCollection _itemDescriptionCollection;

    public CurrentItemModel(Variant variant, ItemDescriptionCollection itemDescriptionCollection)
    {
        _itemDescriptionCollection = itemDescriptionCollection;
        Current = new ItemModel(variant, itemDescriptionCollection);
    }

    public CurrentItemModel()
    {
        Current = null;
    }

    public void Change()
    {
        int randomIndex = UnityEngine.Random.Range(0, _itemDescriptionCollection.Items.Count);
        //TODO: change random
        var itemDescription = _itemDescriptionCollection.Items.ElementAt(randomIndex).Value;

        Current = new ItemModel(itemDescription);
        Changed?.Invoke(Current);
    }
}

