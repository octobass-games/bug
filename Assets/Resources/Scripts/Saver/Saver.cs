using System.IO;
using UnityEngine;

public class Saver : MonoBehaviour
{
    public Levels Levels;
    public Collectables Collectables;

    private readonly string SaveFilePath = Application.persistentDataPath + "/save-data.json";

    public void Save()
    {
        var saveData = new SaveData(Levels.LevelList, Collectables.CollectableList);
        var json = JsonUtility.ToJson(saveData);

        using var fileStream = new FileStream(SaveFilePath, FileMode.Create);
        using var streamWriter = new StreamWriter(fileStream);

        streamWriter.Write(json);
    }

    public void Load()
    {
        using var streamReader = new StreamReader(SaveFilePath);
        var json = streamReader.ReadToEnd();

        var saveData = JsonUtility.FromJson<SaveData>(json);

        Levels.LevelList = saveData.Levels;
        Collectables.CollectableList = saveData.Collectables;
    }
}