using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance = null;

    public Save CurrentSave { get; set; }
    public string SavePath = "EnterGameSavePath";

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }

        CurrentSave = SaveUtility.LoadGame(SavePath);
    }

    public void Save()
    {
        CurrentSave.SaveGame(SavePath);
    }

    public void Save(Save save)
    {
        save.SaveGame(SavePath);
    }

    public Save Load()
    {
        CurrentSave = SaveUtility.LoadGame(SavePath);
        return CurrentSave;
    }

    private Save Load(string path)
    {
        return SaveUtility.LoadGame(path);
    }
}