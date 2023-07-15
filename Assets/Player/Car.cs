using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] float turnSpeed;
    [SerializeField] float moveSpeed;
    [SerializeField] float boostDuration;
    [SerializeField] float maxHealth;
    [SerializeField] float currentHealth;

    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        SetSprite();
    }

    void Update()
    {
        Drive();
    }

    void Drive()
    {
        //consider updating this to a more robust system using physics and forces to simulate actual acceleration and car physics (but it's just a silly 2D game so prob not)
        float steer = Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime;
        float acceleration = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        transform.Rotate(0f, 0f, -steer); //Negative steer so we rotate in the right direction
        transform.Translate(0f, acceleration, 0f);

        //consider checking if car is on road and applying a movement penalty if it isn't
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
    }

    public IEnumerator Boost(float boostAmount)
    {
        Debug.Log("Reached this point too.");
        moveSpeed += boostAmount;
        yield return new WaitForSeconds(boostDuration);
        moveSpeed -= boostAmount;
    }

    public void SetSprite()
    {
        spriteRenderer.sprite = GameManager.Instance.carSprite;
    }
}
