using System;
using System.Collections.Generic;

public class EnchanceTableModel
{
    public event Action<ItemModel> WeaponChanged;
    private List<float> _chances;
    private ItemModel _curentItem;
    private Dictionary<string, Dictionary<string, int>> _items;
    private int _maxLevel;

    public bool Enchance()
    {
        if (_curentItem == null || _curentItem.Level >= _maxLevel)
            return false;

        bool isEnchanted = TryingToEnchant(_curentItem.Level + 1);
        if (isEnchanted)
        {
            _curentItem.Modify(_items[_curentItem.Item]);
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
        WeaponChanged?.Invoke(_curentItem);
    }

    public void SetItems(Dictionary<string, Dictionary<string, int>> items)
    {
        _items = items;
    }

    public void SetChances(List<float> chances)
    {
        _chances = chances;
        _maxLevel = _chances.Count - 1; 
    }
}
