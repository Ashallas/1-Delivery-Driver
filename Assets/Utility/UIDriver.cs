using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIDriver : MonoBehaviour
{
    int currentScore = 0; 

    [SerializeField] Canvas gameCanvas;
    [SerializeField] Canvas gameOverCanvas;
    [SerializeField] Canvas winCanvas;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI finalScoreText;
    [SerializeField] TextMeshProUGUI winCanvasScoreText;

    void Start()
    {
        gameCanvas.gameObject.SetActive(true);
        gameOverCanvas.gameObject.SetActive(false);
        winCanvas.gameObject.SetActive(false);
    }

    void Update()
    {
        UpdateScore();
    }

    void UpdateScore()
    {
        currentScore = GameManager.Instance.GetCurrentScore();
        scoreText.text = "Score: " + currentScore;
    }

    public void DisplayGameOverCanvas()
    {
        gameCanvas.gameObject.SetActive(false);
        gameOverCanvas.gameObject.SetActive(true);
        finalScoreText.text = "Final Score: " + currentScore;
    }

    public void DisplayWinCanvas()
    {
        gameCanvas.gameObject.SetActive(false);
        gameOverCanvas.gameObject.SetActive(false);
        winCanvas.gameObject.SetActive(true);
        winCanvasScoreText.text = "Score: " + currentScore;

    }
} 
