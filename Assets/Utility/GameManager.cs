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

    public int GetHighScore()
    {
        return highScore;
    }

    public void SetHighScore(int score)
    {
        if(score < highScore)
        {
            return;
        }
        highScore = score;
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
        public int highScore;
    }

    public void SavePlayerData()
    {
        SaveData data = new SaveData();
        data.carSprite = carSprite;
        data.lastSceneIndex = SceneManager.GetActiveScene().buildIndex;
        data.highScore = highScore;

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
            highScore = data.highScore; 
        }

        if(carSprite == null) 
        {
            carSprite = defaultCarSprite;
        }
    }
}
