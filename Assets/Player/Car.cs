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

    SpriteRenderer spriteRenderer;
    BoxCollider2D boxCollider;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();    

        SetSprite();
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
