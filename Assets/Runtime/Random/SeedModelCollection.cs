using System;
using System.Collections.Generic;
using TinyJSON;

public class SeedModelCollection
{
    public Dictionary<string, SeedModel> Seeds { get; }

    public SeedModelCollection(Variant variant)
    {
        var seedId = (ProxyObject)variant;

        Seeds = new();
        foreach (var seed in seedId)
        {
            if (seed.Value != 0)
            {
                Seeds.Add(seed.Key, new SeedModel(seed.Value));
            }
            else
            {
                InitializeSeed(seed.Key);
            }
        }
    }

    private void InitializeSeed(string seed)
    {
        Seeds.Add(seed, new SeedModel((ulong)DateTime.UtcNow.Ticks));
    }
}
