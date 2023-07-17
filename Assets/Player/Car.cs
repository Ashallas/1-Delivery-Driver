using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] float turnSpeed;
    [SerializeField] float moveSpeed;
    [SerializeField] float roadSpeed;
    [SerializeField] float offRoadSpeed;
    [SerializeField] float boostDuration;
    [SerializeField] float maxHealth;
    [SerializeField] float currentHealth;
    [SerializeField] float crashDamage;
    [SerializeField] float levelTimer;

    SpriteRenderer spriteRenderer;
    UIDriver uiDriver;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        uiDriver = FindObjectOfType<UIDriver>();

        SetSprite();
        currentHealth = maxHealth;
    }

    void Update()
    {
        Drive();
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Road")
        {
            moveSpeed = roadSpeed;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Road")
        {
            moveSpeed = offRoadSpeed;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Road")
        {
            moveSpeed = roadSpeed;
        }
    }

    void Drive()
    {
        float steer = Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime;
        float acceleration = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        transform.Rotate(0f, 0f, -steer); //Negative steer so we rotate in the right direction
        transform.Translate(0f, acceleration, 0f);
    }

    void EndGame()
    {
        uiDriver.DisplayGameOverCanvas();
        Time.timeScale = 0;
    }

    public void TakeDamage()
    {
        currentHealth -= crashDamage;
        if(currentHealth <= 0f)
        {
            EndGame();
        }
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
