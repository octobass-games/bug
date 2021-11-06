using System.IO;
using UnityEngine;

public class Saver : MonoBehaviour
{
    public Levels Levels;
    public Collectables Collectables;

    public void Save()
    {
        var saveData = new SaveData(Levels.LevelList, Collectables.CollectableList);
        var json = JsonUtility.ToJson(saveData);

        var fileStream = new FileStream(Application.persistentDataPath + "/save-data.json", FileMode.OpenOrCreate);
        var streamWriter = new StreamWriter(fileStream);

        streamWriter.Write(json);
        streamWriter.Close();
        fileStream.Close();
    }
}