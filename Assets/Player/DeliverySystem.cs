using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliverySystem : MonoBehaviour
{
    bool hasPackage = false;
    int deliveriesMade = 0;

    [SerializeField] int deliveriesToMake;

    GameObject activatedDeliveryZone = null;
    UIDriver uiDriver;

    [SerializeField] List<GameObject> deliveryZones = new List<GameObject>();
    [SerializeField] ParticleSystem deliveryParticles;
    [SerializeField] GameObject packageSpawn;
    [SerializeField] GameObject package;

    void Start()
    {
        uiDriver = FindObjectOfType<UIDriver>();
        SpawnPackage();    
    }

    void SpawnPackage()
    {
        Instantiate(package, packageSpawn.transform.position, transform.rotation);
    }

    void DeliveryWin()
    {
        Time.timeScale = 0f;
        uiDriver.DisplayWinCanvas();
        GameManager.Instance.SetHighScore(GameManager.Instance.GetCurrentScore());
    }

    public bool GetHasPackage()
    {
        return hasPackage;
    }

    public void SetHasPackage(bool packageAcquired)
    {
        hasPackage = packageAcquired;
    }

    public int GetDeliveriesMade()
    {
        return deliveriesMade;
    }

    public void ActivateDeliveryZone()
    {
        if (!hasPackage)
        {
            return;
        }

        activatedDeliveryZone = null;
        activatedDeliveryZone = deliveryZones[Random.Range(0, deliveryZones.Count)];
        activatedDeliveryZone.SetActive(true);
    }

    public void DeactivateDeliveryZone()
    {
        if (activatedDeliveryZone == null)
        {
            return;
        }

        activatedDeliveryZone.SetActive(false);
        deliveriesMade++;
        if(deliveriesMade >= deliveriesToMake)
        {
            DeliveryWin();
        }
        SpawnPackage();
    }

    public void PlayDeliveryParticles()
    {
        var particles = Instantiate(deliveryParticles, transform.position, transform.rotation);
        Destroy(particles, 1f);
    }
}
