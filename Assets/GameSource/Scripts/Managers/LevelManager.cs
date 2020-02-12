using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;
    public Level[] Levels;
    
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
    }
    
    /// <summary>
    /// Returns a active level from level database.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Level LoadCurrentLevel()
    {
        var save = SaveManager.Instance.Load();
        var id = save.CurrentLevel;
        
        var level = new Level();
        if (id > Levels.Length)
        {
            id = save.RandomLoadedLevel;
        }

        foreach (var t in Levels)
        {
            if (t.Id == id)
            {
                level = t;
            }
        }
        return level;
    }

    /// <summary>
    /// Select a level from level database.
    /// If there is no new level, returns random level.
    /// </summary>
    /// <returns></returns>
    public Level SelectNextLevel()
    {
        var save = SaveManager.Instance.Load();
        var id = save.CurrentLevel;

        if (id > Levels.Length )
        {
            var random = Random.Range(0, Levels.Length);
            while (random == save.RandomLoadedLevel)
            {
                random = Random.Range(0, Levels.Length );
            }

            save.RandomLoadedLevel = random;
            SaveManager.Instance.Save(save);
        }

        return LoadCurrentLevel();
    }
    
    
}
