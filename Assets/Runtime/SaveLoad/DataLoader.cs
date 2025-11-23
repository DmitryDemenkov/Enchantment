using System.IO;
using TinyJSON;
using UnityEngine;

public static class DataLoader
{
    private static string DataPath()
    {
        return Application.dataPath + "\\Content\\Data";
    }

    public static References LoadReferences()
    {
        string path = DataPath() + "\\references.json";
        string json = File.ReadAllText(path);
        return JSON.Load(json).Make<References>();
    }

    public static PlayerData LoadPlayerData()
    {
        PlayerData playerData = null;

        string path = DataPath() + "\\player.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            playerData = JSON.Load(json).Make<PlayerData>();
        }

        return playerData;
    }

    public static void SavePlayerData(PlayerData playerData)
    {
        string path = DataPath() + "\\player.json";

        if (playerData.CurrentItem == null)
        {
            File.Delete(path);
        }
        else
        {
            string json = JSON.Dump(playerData, EncodeOptions.NoTypeHints);
            File.WriteAllText(path, json);
        }
    }
}
