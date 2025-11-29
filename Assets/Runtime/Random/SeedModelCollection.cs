using System;
using System.Collections.Generic;
using TinyJSON;

public class SeedModelCollection
{
    public Dictionary<string, SeedModel> Seeds { get; } = new();

    public SeedModelCollection(Variant variant)
    {
        var seedId = (ProxyObject)variant;

        foreach (var pair in seedId)
        {
            ulong value = pair.Value;
            if (value != 0)
                Seeds[pair.Key] = new SeedModel(value);
        }
    }

    public SeedModel this[string key]
    {
        get
        {
            if (!Seeds.TryGetValue(key, out var model))
            {
                model = InitializeSeed();
                Seeds[key] = model;
            }
            return model;
        }
    }

    private SeedModel InitializeSeed() => new SeedModel((ulong)DateTime.UtcNow.Ticks);
}
