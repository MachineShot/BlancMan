using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Platformer.Mechanics;

public static class SaveSystem
{
    public static bool isScenebeingLoaded = false;
    public static PlayerData copyData;

    public static void SavePlayer(GameController gc)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.isgay";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(gc);

        formatter.Serialize(stream, data);
        stream.Close();

        Debug.Log("Saved game in " + path);
    }

    public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/player.isgay";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            copyData = data;
            stream.Close();
            
            Debug.Log("Loaded game data");
            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}
