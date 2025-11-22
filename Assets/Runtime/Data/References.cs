using System.Collections.Generic;
using TinyJSON;

public class References
{
    [Include][DecodeAlias("items")]
    private Dictionary<string, Dictionary<string, Dictionary<string, int>>> _items;

    [Include][DecodeAlias("chances")]
    private List<float> _chances;

    public IReadOnlyList<float> GetChances()
    {
        return _chances;
    }

    public IReadOnlyDictionary<string, IReadOnlyDictionary<string, int>> GetDefaultStats()
    {
        return UnwrapItems("start_stats");
    }

    public IReadOnlyDictionary<string, IReadOnlyDictionary<string, int>> GetIncreaseStats()
    {
        return UnwrapItems("increase_stats");
    }

    private IReadOnlyDictionary<string, IReadOnlyDictionary<string, int>> UnwrapItems(string key)
    {
        Dictionary<string, IReadOnlyDictionary<string, int>> stats = new();

        foreach (var pair in _items)
        {
            stats[pair.Key] = pair.Value[key];
        }

        return stats;
    }
}
