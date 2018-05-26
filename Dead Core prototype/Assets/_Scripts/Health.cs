﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    //TODO
    //Figure out a way to stop canvas rotating - Sort of done but not perfect yet, perhaps find altrnative or updated solution - see FreezeCanvasRotation script
    //Add health pickup, remember to call the function below
    //Figure out why player isn't taking damage

    public float startHealth = 50f;
    private float health;

    public Image healthBar;

    public void Start()
    {
        health = startHealth;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        UpdateHealthBar();
        if (health <= 0)
        {
            Die();
        }
    }

    public void IncreaseHealth(float amount) //Call this when health pickup is collided
    {
        health += amount;
        UpdateHealthBar();
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
