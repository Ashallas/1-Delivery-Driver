using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Package : Pickup //INHERITANCE
{
    [SerializeField]string instructions;

    void Start()
    {
        Type = "Package"; //POLYMORPHISM
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
