using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIDriver : MonoBehaviour
{
    int currentScore = 0;

    Car car;

    [SerializeField] Canvas gameCanvas;
    [SerializeField] Canvas gameOverCanvas;
    [SerializeField] Canvas winCanvas;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI finalScoreText;
    [SerializeField] TextMeshProUGUI winCanvasScoreText;
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] TextMeshProUGUI healthText;

    void Awake()
    {
        car = FindObjectOfType<Car>();    
    }

    void Start()
    {
        gameCanvas.gameObject.SetActive(true);
        gameOverCanvas.gameObject.SetActive(false);
        winCanvas.gameObject.SetActive(false);
    }

    void Update()
    {
        UpdateScore();
        UpdateTimer();
        UpdateHealth();
    }

    void UpdateScore()
    {
        currentScore = GameManager.Instance.GetCurrentScore();
        scoreText.text = "Score: " + currentScore;
    }

    void UpdateTimer()
    {
        timerText.text = "Remaining Time: " + Mathf.RoundToInt(car.GetRemainingTime());
    }

    void UpdateHealth()
    {
        healthText.text = "Car Health: " + car.GetCurrentHealth();
    }

    public void DisplayGameOverCanvas()
    {
        gameCanvas.gameObject.SetActive(false);
        gameOverCanvas.gameObject.SetActive(true);
        finalScoreText.text = "High Score: " + GameManager.Instance.GetHighScore();
    }

    public void DisplayWinCanvas()
    {
        gameCanvas.gameObject.SetActive(false);
        gameOverCanvas.gameObject.SetActive(false);
        winCanvas.gameObject.SetActive(true);
        winCanvasScoreText.text = "Score: " + currentScore;

    }


} 
