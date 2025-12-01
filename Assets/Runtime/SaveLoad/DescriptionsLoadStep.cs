using System.IO;
using TinyJSON;
using UnityEngine;

public class DescriptionsLoadStep : IStep
{
    private Descriptions _descriptions;

    public DescriptionsLoadStep(Descriptions descriptions)
    {
        _descriptions = descriptions;
    }

    public void Execute()
    {
        string descriptionsPath = DataPath() + "\\references.json";
        string descriptionsJson = File.ReadAllText(descriptionsPath);

        var descriptionsJsonData = JSON.Load(descriptionsJson);
        _descriptions.SetData(descriptionsJsonData);
    }

    private static string DataPath()
    {
        return Application.dataPath + "\\Content\\Data";
    }
}

