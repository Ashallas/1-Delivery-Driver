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
        car.TakeDamage();
        
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
                Boost boost = collision.GetComponent<Boost>();

                if (!boost.IsOnCooldown())
                {
                    Debug.Log("Reached this point");
                    StartCoroutine(car.Boost(boost.SpeedBoost()));
                    StartCoroutine(boost.BoostCooldown());
                }
                break;
            case "Delivery Zone":
                deliverySystem.DeactivateDeliveryZone();
                deliverySystem.SetHasPackage(false);
                GameManager.Instance.IncreaseCurrentScore(50);
                deliverySystem.PlayDeliveryParticles();
                break;
            default:
                Debug.LogError("Unknown Pickup type! What the heck?!");
                break;
        }
    }
}
