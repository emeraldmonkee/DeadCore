using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_Health : MonoBehaviour
{
    //TODO Figure out a way to stop canvas rotating - Sort of done but not perfect yet, perhaps find alternative or updated solution - see FreezeCanvasRotation script
    //TODO Add health pickup, remember to call the function below

    public float startHealth;
    private float health;

    [SerializeField]
    private float hp_Flash = 0;

    public Image healthBar;
    public GameObject enemyCanvas;

    public void Start()
    {
        enemyCanvas.SetActive(false);
        health = startHealth;
    }

    public void TakeDamage(float amount)
    {
        hp_Flash = 3;
        health -= amount;
        UpdateHealthBar();
        if (health <= 0)
        {
            Die();
        }
    }

    void Update()
    {
        hp_Flash -= Time.deltaTime;
        if (hp_Flash > 0)
        {
            enemyCanvas.SetActive(true);
        }
        else
        {
            hp_Flash = 0;
            enemyCanvas.SetActive(false);
        }
    }

    void Die()
    {
        Destroy(this.gameObject);
    }

    private void UpdateHealthBar() //Call this whenever the health is affected, from damage or health increases
    {
        healthBar.fillAmount = health / startHealth;

        if (healthBar.fillAmount >= 0.5)
        {
            healthBar.color = Color.green;
        }

        if (healthBar.fillAmount > 0.25 && healthBar.fillAmount < 0.5)
        {
            healthBar.color = Color.yellow;
        }

        if (healthBar.fillAmount <= 0.25)
        {
            healthBar.color = Color.red;
        }
    }
}
