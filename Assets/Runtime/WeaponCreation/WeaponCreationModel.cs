using System.Collections.Generic;

public class WeaponCreationModel
{
    private IReadOnlyDictionary<WeaponType, Dictionary<string, int>> _defaultProperties;
    private WeaponFactory _factory;

    private System.Random _random = new System.Random();

    public WeaponCreationModel(IReadOnlyDictionary<WeaponType, Dictionary<string, int>> defaultProperties, WeaponFactory factory)
    {
        _defaultProperties = defaultProperties;
        _factory = factory;
    }

    public WeaponModel CreateRandomWeapon()
    {
        WeaponType type = (WeaponType)_random.Next(0, System.Enum.GetValues(typeof(WeaponType)).Length);
        return _factory.CreateWeapon(type, 0, _defaultProperties[type]);
    }
}
