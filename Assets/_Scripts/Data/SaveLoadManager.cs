using System.IO;
using UnityEngine;
using Newtonsoft.Json;

public static class SaveLoadManager
{
    public static void SaveData(Data data)
    {
        string path = Application.persistentDataPath + "/GameData.txt";
        Debug.Log(Application.persistentDataPath + "/GameData.txt");
        string jsonData = JsonUtility.ToJson(data, true);
        File.WriteAllText(path, jsonData);
    }

    public static Data LoadData()
    {
        string path = Application.persistentDataPath + "/GameData.txt";
        Debug.Log(Application.persistentDataPath + "/GameData.txt");

        if (File.Exists(path))
        {
            string jsonString = File.ReadAllText(path);
            Data data = JsonConvert.DeserializeObject<Data>(jsonString);
            return data;
        }

        return null;
    }
}