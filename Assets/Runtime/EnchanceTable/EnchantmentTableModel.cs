using System;
using System.Collections.Generic;

public class EnchantmentTableModel
{
    public event Action<ItemModel> ItemChanged;
    private IReadOnlyList<float> _chances;
    private ItemModel _curentItem;
    private IReadOnlyDictionary<string, IReadOnlyDictionary<string, int>> _items;
    private int _maxLevel;

    public bool Enchance()
    {
        if (_curentItem == null || _curentItem.Level >= _maxLevel)
            return false;

        bool isEnchanted = TryingToEnchant(_curentItem.Level);
        if (isEnchanted)
        {
            _curentItem.Modify(_items[_curentItem.Item]);
        }
        else
        {
            _curentItem = null;
        }

        SetCurentItem(_curentItem);
        return isEnchanted;
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
        _maxLevel = _chances.Count - 1; 
    }
}
