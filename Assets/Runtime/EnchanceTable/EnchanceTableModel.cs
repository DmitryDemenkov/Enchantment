using System;
using System.Collections.Generic;

public class EnchanceTableModel
{
    public event Action<WeaponModel> WeaponChanged;
    private Dictionary<int, float> _chances;
    private WeaponFactory _factory = new WeaponFactory();
    private WeaponModel _weapon;
    private ScrollModel _scroll;

    public bool Enchance()
    {
        if (_weapon == null || _weapon.Level >= 20)
            return false;

        WeaponModel newWapeon = null;

        bool isEnchanted = TryingToEnchant(_weapon.Level + 1);
        if (isEnchanted)
        {
            var newProperties = _scroll.Modify(_weapon.Properties);
            newWapeon = _factory.CreateWeapon(_weapon.Type, _weapon.Level + 1, newProperties);
        }

        SetWeapon(newWapeon);
        return isEnchanted;
    }

    private bool TryingToEnchant(int level)
    {
        float chances = UnityEngine.Random.Range(0f, 1f);
        return chances < _chances[level];
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
