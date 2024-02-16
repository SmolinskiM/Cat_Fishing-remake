using System;
using UnityEngine;
using System.IO;

[Serializable]
public class FileHandrel<T> : MonoBehaviour
{
    public void SaveData(string savePath, object objectToJson)
    {
        string jsonContent = JsonUtility.ToJson(objectToJson, true);

        FileStream fileStream = new FileStream(savePath, FileMode.Create);

        using (StreamWriter writer = new StreamWriter(fileStream))
        {
            writer.Write(jsonContent);
        }
    }

    public T LoadData(string savePath)
    {
        StreamReader reader = new StreamReader(savePath);

        string jsonContent = reader.ReadToEnd();

        return JsonUtility.FromJson<T>(jsonContent);
    }
}
