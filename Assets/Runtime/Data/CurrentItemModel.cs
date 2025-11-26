using System;
using System.Collections.Generic;
using System.Linq;
using TinyJSON;

public class CurrentItemModel
{
    public event Action<ItemModel> Changed;
    public event Action<EnchantmentResult> Enchanted;

    public ItemModel Current { get; private set; }

    private ItemDescriptionCollection _itemDescriptionCollection;
    private List<float> _chances; 

    public CurrentItemModel(Variant variant, Descriptions descriptions)
    {
        _chances = descriptions.Chances;
        _itemDescriptionCollection = descriptions.Items;
        Current = new ItemModel(variant, _itemDescriptionCollection);
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

    public void Enchance()
    {
        if (Current == null)
        {
            Enchanted?.Invoke(EnchantmentResult.FAILURE);
            return;
        }

        if (Current.Level >= _chances.Count)
        {
            Enchanted?.Invoke(EnchantmentResult.MAXLEVEL);
            return;
        }

        float chance = UnityEngine.Random.Range(0f, 1f);
        if (chance < _chances[Current.Level])
        {
            Current.Enchance();
            Enchanted?.Invoke(EnchantmentResult.SUCCESS);
        }
        else
        {
            Current = null;
            Changed?.Invoke(Current);
            Enchanted?.Invoke(EnchantmentResult.FAILURE);
        }
    }
}

