using System.IO;
using UnityEngine;

public class DataBase
{
    private static string saveFile;

    internal static PlayerData GetData()
    {
        if (!File.Exists($"{Application.dataPath} save.txt"))
        {
            return new PlayerData();
        }
        return LoadData();
    }

    internal static PlayerData LoadData()
    {
        saveFile = File.ReadAllText($"{Application.dataPath} save.txt");

        PlayerData playerData = JsonUtility.FromJson<PlayerData>(saveFile);

        return playerData;
    }
    internal static void SaveData(PlayerData playerData)
    {
        PlayerData dataToSave = new();
        dataToSave.Scores = playerData.Scores;
        saveFile = JsonUtility.ToJson(dataToSave);

        File.WriteAllText($"{Application.dataPath} save.txt", saveFile);
    }
}
