using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Package : Pickup
{
    [SerializeField]string instructions;

    void Start()
    {
        Type = "Package";
    }

    public void DisplayInstructions()
    {
        //Send Instructions to UI element that will display them
    }

    public void SelfDestruct()
    {
        Destroy(gameObject);
    }
}
