using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Sprite carSprite;
    public Sprite defaultCarSprite;

    void Start()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadCarSprite();
    }

    //This is the method the play button calls at the moment
    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadScene(int buildIndex)
    {
        SceneManager.LoadScene(buildIndex);
    }

    //This is the method the play button will call in future
    public void LoadLastScene(int lastSceneIndex)
    {
        SceneManager.LoadScene(lastSceneIndex);
    }

    public void QuitGame()
    {
        SaveCarSprite();
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
    }

    public void SaveCarSprite()
    {
        SaveData data = new SaveData();
        data.carSprite = carSprite;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);

    }

    public void LoadCarSprite()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            carSprite = data.carSprite;
        }

        if(carSprite == null) 
        {
            carSprite = defaultCarSprite;
        }
    }
}
