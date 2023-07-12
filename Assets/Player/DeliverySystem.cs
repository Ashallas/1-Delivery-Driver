using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliverySystem : MonoBehaviour
{
    bool hasPackage = false;

    public void GainPackage()
    {
        hasPackage = true;
    }

    public void DeliverPackage()
    {
        hasPackage = false;
    }
}
