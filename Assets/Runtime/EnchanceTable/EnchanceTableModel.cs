using System;
using System.Collections.Generic;

public class EnchanceTableModel
{
    public event Action<WeaponModel> WeaponChanged;
    private Dictionary<int, float> _chances;
    private WeaponFactory _factory = new WeaponFactory();
    private WeaponModel _weapon;
    private ScrollModel _scroll;

    public void Enchance()
    {
        if (TryingToEnchant(_weapon.Level))
        {
            var newProperties = _scroll.Modify(_weapon.Properties);
            WeaponModel newWapeon = _factory.CreateWeapon(_weapon.Type, _weapon.Level + 1, newProperties);
            SetWeapon(newWapeon);
        }
    }

    private bool TryingToEnchant(int level)
    {
        float chances = UnityEngine.Random.Range(0f, 1);
        if (chances < _chances[level])
        {
            return true;
        }
        return false;
    }

    public void SetWeapon(WeaponModel weapon)
    {
        _weapon = weapon;
        WeaponChanged?.Invoke(_weapon);
    }

    public void SetScroll(ScrollModel scroll)
    {
        _scroll = scroll;
    }

    public void SetChances(Dictionary<int, float> chances)
    {
        _chances = chances;
    }
}
