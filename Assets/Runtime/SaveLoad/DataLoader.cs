using System.IO;
using TinyJSON;
using UnityEngine;

public static class DataLoader
{
    private static string DataPath()
    {
        return Application.dataPath + "\\Content\\Data";
    }

    public static Descriptions LoadReferences(out Variant variant)
    {
        string path = DataPath() + "\\references.json";
        string json = File.ReadAllText(path);

        variant = JSON.Load(json);


        return new Descriptions(variant);
    }

    public static PlayerModel LoadPlayerData()
    {
        PlayerModel player = new PlayerModel();

        string path = DataPath() + "\\player.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            player = new PlayerModel(JSON.Load(json), LoadReferences(out Variant variant));
        }

        return player;
    }

    public static void SavePlayerData(PlayerModel playerData)
    {
        string path = DataPath() + "\\player.json";
        string json = JSON.Dump(playerData, EncodeOptions.NoTypeHints);
        File.WriteAllText(path, json);
    }
}
