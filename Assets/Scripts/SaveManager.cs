using UnityEngine;
using System.IO;
using TMPro;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using System.Runtime.InteropServices;


public class SaveManager : MonoBehaviour
{
    private string savingPath;
    private string _fileName = "playerStats.json";

    [SerializeField] private TextMeshProUGUI nameField;

    [SerializeField] private bool isPersistentPath = true;

    private void GetSavePath()
    {
        Debug.Log(isPersistentPath);
        if (isPersistentPath)
        {
            savingPath = Application.persistentDataPath;
        }
        else
        {
            savingPath = Application.streamingAssetsPath;
        }
    }
     
    public void Save()
    {


        savingPath = Application.persistentDataPath;
        PlayerData player = new PlayerData(nameField.text);
        string savePlayerData = JsonUtility.ToJson(player);

        string path = Path.Combine(savingPath, _fileName);

        File.WriteAllText(path, savePlayerData);
    }
    
    public void Load() 
    {
        GetSavePath();
        string path = Path.Combine(savingPath, _fileName);

        if (File.Exists(path))
        {
            string loadPlayerData = File.ReadAllText(path);
            
            PlayerData deserializedPlayerData = JsonUtility.FromJson<PlayerData>(loadPlayerData);
            nameField.text = deserializedPlayerData._playerName; 
            Debug.Log(deserializedPlayerData._playerName);
        }
    }
}
