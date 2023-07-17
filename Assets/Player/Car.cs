using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    float levelTimer; 

    [SerializeField] float turnSpeed;
    [SerializeField] float moveSpeed;
    [SerializeField] float roadSpeed;
    [SerializeField] float offRoadSpeed;
    [SerializeField] float boostDuration;
    [SerializeField] float maxHealth;
    [SerializeField] float currentHealth;
    [SerializeField] float crashDamage;
    [SerializeField] float levelTime;

    SpriteRenderer spriteRenderer;
    UIDriver uiDriver;

    void Awake()
    {
        levelTimer = levelTime;
        currentHealth = maxHealth;
    }

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        uiDriver = FindObjectOfType<UIDriver>();

        SetSprite();
    }

    void Update()
    {
        Drive(); //ABSTRACTION
        Timer();
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

    void Timer()
    {
        if(levelTimer > 0)
        {
            levelTimer -= Time.deltaTime;
        }
        else
        {
            EndGame();
        }
    }

    void EndGame()
    {
        uiDriver.DisplayGameOverCanvas();
        GameManager.Instance.SetHighScore(GameManager.Instance.GetCurrentScore());
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
        if (GameManager.Instance.carSprite == null) 
        { 
            return; 
        }

        spriteRenderer.sprite = GameManager.Instance.carSprite;
    }

    public float GetRemainingTime() //ENCAPSULATION
    {
        return levelTimer;
    }

    public float GetCurrentHealth()
    {
        return currentHealth;
    }
}
