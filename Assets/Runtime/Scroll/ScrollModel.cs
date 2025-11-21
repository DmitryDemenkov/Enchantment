using System.Collections.Generic;

public class ScrollModel
{
    private Dictionary<string, int> _scrollProperties;

    public ScrollModel(Dictionary<string, int> properties)
    {
        _scrollProperties = properties;
    }

    public Dictionary<string, int> Modify(IReadOnlyDictionary<string, int> properties)
    {
        Dictionary<string, int> modifyProperties = new Dictionary<string, int>();

        foreach (var pair in properties)
            modifyProperties[pair.Key] = pair.Value;

        foreach (var pair in _scrollProperties)
        {
            modifyProperties[pair.Key] += pair.Value;
        }

        return modifyProperties;
    }
}
