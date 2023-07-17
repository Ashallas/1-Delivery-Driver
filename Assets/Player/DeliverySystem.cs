using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliverySystem : MonoBehaviour
{
    bool hasPackage = false;

    GameObject activatedDeliveryZone = null;

    [SerializeField] List<GameObject> deliveryZones = new List<GameObject>();
    [SerializeField] ParticleSystem deliveryParticles;

    public bool GetHasPackage()
    {
        return hasPackage;
    }

    public void SetHasPackage(bool packageAcquired)
    {
        hasPackage = packageAcquired;
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

    public void PlayDeliveryParticles()
    {
        var particles = Instantiate(deliveryParticles, transform.position, transform.rotation);
        Destroy(particles, 1f);
    }
}
