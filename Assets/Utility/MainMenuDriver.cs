using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuDriver : MonoBehaviour
{
    [SerializeField] Canvas mainCanvas;
    [SerializeField] Canvas optionCanvas;
    [SerializeField] Canvas creditsCanvas;
    [SerializeField] Canvas controlsCanvas;

    public void SwapToOptions()
    {
        mainCanvas.gameObject.SetActive(false);
        creditsCanvas.gameObject.SetActive(false);
        controlsCanvas.gameObject.SetActive(false); 
        optionCanvas.gameObject.SetActive(true);
    }
    
    public void SwapToCredits()
    {
        optionCanvas.gameObject.SetActive(false);
        mainCanvas.gameObject.SetActive(false);
        controlsCanvas.gameObject.SetActive(false);
        creditsCanvas.gameObject.SetActive(true);
    }

    public void SwapToMainMenu()
    {
        optionCanvas.gameObject.SetActive(false);
        creditsCanvas.gameObject.SetActive(false);
        controlsCanvas.gameObject.SetActive(false);
        mainCanvas.gameObject.SetActive(true);
    }

    public void SwapToControls()
    {
        mainCanvas.gameObject.SetActive(false);
        creditsCanvas.gameObject.SetActive(false);
        optionCanvas.gameObject.SetActive(false);
        controlsCanvas.gameObject.SetActive(true);
    }

}
