using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCollisionHandler : MonoBehaviour
{
    Car car;
    DeliverySystem deliverySystem;

    void Awake()
    {
        car = GetComponent<Car>();    
        deliverySystem = GetComponent<DeliverySystem>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag != "Obstacle")
        {
            return;
        }
        //TakeDamage logic can probably just be static damage based on obstacle for our purposes
        Debug.Log("car took some damage");
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Pickup>() == null)
        {
            return;
        }
        
        Pickup pickup = collision.gameObject.GetComponent<Pickup>();
        
        switch(pickup.Type)
        {
            case "Package":
                Package package = collision.GetComponent<Package>();

                Debug.Log("Package Acquired!");
                package.DisplayInstructions();
                package.SelfDestruct();
                deliverySystem.SetHasPackage(true);
                deliverySystem.ActivateDeliveryZone();
                break;
            case "Boost":
                //do something
                break;
            case "Delivery Zone":
                deliverySystem.DeactivateDeliveryZone();
                deliverySystem.SetHasPackage(false);
                deliverySystem.IncreaseSuccessfulDeliveries(1);
                Debug.Log("You did it!");
                break;
            default:
                break;
        }
    }
}
