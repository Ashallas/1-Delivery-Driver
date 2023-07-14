using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boost : Pickup
{
    bool onCooldown = false;

    [SerializeField] float speedIncrease = 10f;
    [SerializeField] float cooldownPeriod = 30f;
    void Start()
    {
        Type = "Boost";
    }

    public IEnumerator BoostCooldown()
    {
        onCooldown = true;
        yield return new WaitForSeconds(cooldownPeriod);
        onCooldown = false;
    }

    public float SpeedBoost()
    {
        return speedIncrease;
    }

    public bool IsOnCooldown()
    {
        return onCooldown;
    }
}
