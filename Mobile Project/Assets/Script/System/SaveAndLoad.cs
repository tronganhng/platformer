using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class SaveAndLoad {
    public static void save(GameData gameData)
    {
        Debug.Log("Saving...");
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/GameData.fun";
        FileStream stream = new FileStream(path, FileMode.Create);

        IntermediaryData data = new IntermediaryData(gameData);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static IntermediaryData load()
    {
        string path = Application.persistentDataPath + "/GameData.fun";
        if(File.Exists(path))
        {
            Debug.Log("Loading...");
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            IntermediaryData data = formatter.Deserialize(stream) as IntermediaryData;
            stream.Close();
            return data;
        }
        else
        {
            Debug.LogError("Canot find Data file!!");
            return null;
        }
    }
}
