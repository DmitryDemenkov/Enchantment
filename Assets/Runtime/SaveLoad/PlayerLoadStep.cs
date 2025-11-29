using System.IO;
using TinyJSON;
using UnityEngine;

public class PlayerLoadStep : IStep
{
    private PlayerModel _player;

    public PlayerLoadStep(PlayerModel player)
    {
        _player = player;
    }

    public void Execute()
    {
        string descriptionsPath = DataPath() + "\\references.json";
        string descriptionsJson = File.ReadAllText(descriptionsPath);

        var descriptionsJsonData = JSON.Load(descriptionsJson);
        var descriptions = new Descriptions(descriptionsJsonData);

        string playerPath = DataPath() + "\\player.json";
        if (File.Exists(playerPath))
        {
            string playerJson = File.ReadAllText(playerPath);
            _player.SetData(JSON.Load(playerJson), descriptions);
        }
        else
        {
            _player.SetData(descriptions);
        }
    }

    private static string DataPath()
    {
        return Application.dataPath + "\\Content\\Data";
    }
}

