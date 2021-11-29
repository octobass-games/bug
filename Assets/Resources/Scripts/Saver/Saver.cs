using System.IO;
using UnityEngine;

public class Saver : MonoBehaviour
{
    public Levels Levels;
    public Collectables Collectables;

    private string SaveFilePath;

    void Awake() => SaveFilePath = Application.persistentDataPath + "/save-data.json";

    public void Save()
    {
        var saveData = new SaveData(Levels.LevelList, Collectables.CollectableList);
        var json = JsonUtility.ToJson(saveData);

        if (Application.platform != RuntimePlatform.WebGLPlayer)
        {
            using var fileStream = new FileStream(SaveFilePath, FileMode.Create);
            using var streamWriter = new StreamWriter(fileStream);

            streamWriter.Write(json);
        }
        else
        {
            PlayerPrefs.SetString("save-data", json);
            PlayerPrefs.Save();
        }
    }

    public void Load()
    {
        string json;

        if (Application.platform != RuntimePlatform.WebGLPlayer)
        {
            using var streamReader = new StreamReader(SaveFilePath);
            json = streamReader.ReadToEnd();
        }
        else
        {
            json = PlayerPrefs.GetString("save-data");
        }

        var saveData = JsonUtility.FromJson<SaveData>(json);

        Levels.OnLoad(saveData);
        Collectables.OnLoad(saveData);
    }

    public static bool HasSaveData()
    {
        if (Application.platform != RuntimePlatform.WebGLPlayer)
        {
            return File.Exists(Application.persistentDataPath + "/save-data.json");
        }
        else
        {
            return PlayerPrefs.GetString("save-data") != "";
        }
    }
}