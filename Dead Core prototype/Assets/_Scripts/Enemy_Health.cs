using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_Health : HealthComponent
{
    [Header("Display"), SerializeField]
    private GameObject enemyCanvas;
    //[SerializeField, ReadOnly]
    //private float _HPFlash = 0;


    private void Awake()
    {
        //enemyCanvas.SetActive(false);
    }

    public override sealed void TakeDamage(float amount)
    {
        base.TakeDamage(amount);

        GetComponent<Zombie_Sleeper_Navigation>().detected = true;
        //_HPFlash = 1f;
    }

    /*
    private void Update()
    {
        _HPFlash -= Time.deltaTime;
        if (_HPFlash > 0f)
        {
            enemyCanvas.SetActive(true);
        }
        else
        {
            _HPFlash < 0f;
            enemyCanvas.SetActive(false);
        }
    }
    */
}
