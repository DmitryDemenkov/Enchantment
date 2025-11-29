using System;
using System.Collections.Generic;
using TinyJSON;

public class SeedModelCollection
{
    public Dictionary<string, SeedModel> Seeds { get; } = new();

    public SeedModelCollection(Variant variant)
    {
        var seedsData = (ProxyObject)variant;

        foreach (var pair in seedsData)
        {
            ulong value = pair.Value;
            Seeds[pair.Key] = new SeedModel(value);
        }
    }

    public SeedModel this[string key]
    {
        get
        {
            if (!Seeds.ContainsKey(key))
            {
                var model = InitializeSeed();
                Seeds[key] = model;
            }
            return Seeds[key];
        }
    }

    private SeedModel InitializeSeed() => new SeedModel((ulong)DateTime.UtcNow.Ticks);
}
