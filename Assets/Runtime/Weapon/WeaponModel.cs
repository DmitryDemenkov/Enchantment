using System.Collections.Generic;

public class WeaponModel
{
    private WeaponType _type;
    public WeaponType Type { get { return _type; } }

    private int _level;
    public int Level { get { return _level; } }

    private Dictionary<string, int> _properties;
    public IReadOnlyDictionary<string, int> Properties { get { return _properties; } }


    public WeaponModel(WeaponType weaponType, int weaponLevel, Dictionary<string, int> weaponProperties)
    {
        _type = weaponType;
        _level = weaponLevel;
        _properties = weaponProperties;
    }
}
