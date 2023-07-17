using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class GameManager : MonoBehaviour
{
    int lastSceneIndex = 1;
    int currentScore = 0;
    int highScore = 0;

    public Sprite carSprite;
    public Sprite defaultCarSprite;

    public static GameManager Instance;

    void Start()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadPlayerData();
    }

    void OnApplicationQuit()
    {
        SavePlayerData();    
    }

    public int GetCurrentScore()
    {
        return currentScore;
    }

    public void IncreaseCurrentScore(int increment)
    {
        currentScore += increment;
    }

    //This is the method the play button calls at the moment
    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1;
    }

    public void LoadScene(int buildIndex)
    {
        SceneManager.LoadScene(buildIndex);
        Time.timeScale = 1;
    }

    //This is the method the play button will call in future
    public void LoadLastScene(int lastSceneIndex)
    {
        if(lastSceneIndex == 0)
        {
            lastSceneIndex = 1;
        }

        SceneManager.LoadScene(lastSceneIndex);
        Time.timeScale = 1;
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        SavePlayerData();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); 
#endif
    }

    [System.Serializable]
    class SaveData
    {
        public Sprite carSprite;
        public int lastSceneIndex;
    }

    public void SavePlayerData()
    {
        SaveData data = new SaveData();
        data.carSprite = carSprite;
        data.lastSceneIndex = SceneManager.GetActiveScene().buildIndex;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);

    }

    public void LoadPlayerData()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            carSprite = data.carSprite;
            lastSceneIndex = data.lastSceneIndex;
        }

        if(carSprite == null) 
        {
            carSprite = defaultCarSprite;
        }
    }
}
