using System;
using System.Collections.Generic;

public class EnchantmentTableModel
{
    public event Action<ItemModel> ItemChanged;
    public event Action<EnchantmentResult> Enchanted;

    private IReadOnlyList<float> _chances;
    private IReadOnlyDictionary<string, IReadOnlyDictionary<string, int>> _items;

    private int _maxLevel;

    private ItemModel _curentItem;
    public ItemModel CurrentItem { get { return _curentItem; } }

    public void Enchance()
    {
        if (_curentItem == null)
        {
            Enchanted?.Invoke(EnchantmentResult.FAILURE);
            return;
        }

        if (_curentItem.Level >= _maxLevel)
        {
            Enchanted?.Invoke(EnchantmentResult.MAXLEVEL);
            return;
        }

        bool isEnchanted = TryingToEnchant(_curentItem.Level);
        if (isEnchanted)
        {
            _curentItem.Modify(_items[_curentItem.Item]);
            Enchanted?.Invoke(EnchantmentResult.SUCCESS);
        }
        else
        {
            SetCurentItem(null);
            Enchanted?.Invoke(EnchantmentResult.FAILURE);
        }
    }

    private bool TryingToEnchant(int level)
    {
        float chances = UnityEngine.Random.Range(0f, 1f);
        return chances < _chances[level];
    }

    public void SetCurentItem(ItemModel curentItem)
    {
        _curentItem = curentItem;
        ItemChanged?.Invoke(_curentItem);
    }

    public void SetItems(IReadOnlyDictionary<string, IReadOnlyDictionary<string, int>> items)
    {
        _items = items;
    }

    public void SetChances(IReadOnlyList<float> chances)
    {
        _chances = chances;
        _maxLevel = _chances.Count; 
    }
}
