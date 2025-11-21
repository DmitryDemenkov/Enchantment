using System.Collections.Generic;

public class WeaponFactory
{
    public WeaponModel CreateWeapon(WeaponType type, int level, IReadOnlyDictionary<string, int> weaponProperties)
    {
        return new WeaponModel(type, level, weaponProperties);
    }
}
