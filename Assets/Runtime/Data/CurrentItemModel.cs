using System;
using System.Collections.Generic;
using System.Linq;
using TinyJSON;

public class CurrentItemModel
{
    public event Action<ItemModel> Changed;
    public event Action<EnchantmentResult> Enchanted;

    public ItemModel Current { get; private set; } = null;

    private ItemDescriptionCollection _itemDescriptionCollection;
    private List<float> _chances;

    private SeedModelCollection _seedsModelCollection;

    public CurrentItemModel(Variant variant, Descriptions descriptions, SeedModelCollection seeds) : this(descriptions, seeds)
    {
        if (variant != null)
        {
            Current = new ItemModel(variant, _itemDescriptionCollection);
        }
    }

    public CurrentItemModel(Descriptions descriptions, SeedModelCollection seeds)
    {
        _chances = descriptions.Chances;
        _seedsModelCollection = seeds;
        _itemDescriptionCollection = descriptions.Items;
    }

    public void Change()
    {
        var seed = _seedsModelCollection["change_seed"].IncrementSeed();
        var random = new Random(seed);
        
        int randomIndex = random.Range(0, _itemDescriptionCollection.Items.Count - 1);
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

        var seed = _seedsModelCollection["enchance_seed"].IncrementSeed();
        var random = new Random(seed);

        double chance = random.Chance();
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

    public string Serialize()
    {
        if (Current != null)
        {
            return Current.Serialize();
        }
        return "null";
    }
}

