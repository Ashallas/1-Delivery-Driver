using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuDriver : MonoBehaviour
{
    [SerializeField] Canvas mainCanvas;
    [SerializeField] Canvas optionCanvas;
    [SerializeField] Canvas creditsCanvas;

    public void SwapToOptions()
    {
        mainCanvas.gameObject.SetActive(false);
        creditsCanvas.gameObject.SetActive(false);
        optionCanvas.gameObject.SetActive(true);
    }
    
    public void SwapToCredits()
    {
        optionCanvas.gameObject.SetActive(false);
        mainCanvas.gameObject.SetActive(false);
        creditsCanvas.gameObject.SetActive(true);
    }

    public void SwapToMainMenu()
    {
        optionCanvas.gameObject.SetActive(false);
        creditsCanvas.gameObject.SetActive(false);
        mainCanvas.gameObject.SetActive(true);
    }

}
