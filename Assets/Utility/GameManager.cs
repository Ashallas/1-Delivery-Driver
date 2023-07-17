using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using TMPro;


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
