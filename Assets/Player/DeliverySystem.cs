using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliverySystem : MonoBehaviour
{
    bool hasPackage = false;
    int successfulDeliveries = 0;

    GameObject activatedDeliveryZone = null;

    [SerializeField] List<GameObject> deliveryZones = new List<GameObject>();

    public bool GetHasPackage()
    {
        return hasPackage;
    }

    public void SetHasPackage(bool packageAcquired)
    {
        hasPackage = packageAcquired;
    }

    public int GetSuccessfulDeliveries()
    {
        return successfulDeliveries;
    }

    public void IncreaseSuccessfulDeliveries(int increment)
    {
        successfulDeliveries += increment;
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
    }
}
