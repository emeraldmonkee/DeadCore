using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Autodeath : MonoBehaviour
{
    [SerializeField] private float timeTilDeath;
    [SerializeField] private bool _destroyOnDie = true;
    [SerializeField, ReadOnly] private float timeLeft;

    private void Awake()
    {
        timeLeft = timeTilDeath;
    }

    private void Update()
    {
        timeLeft -= Time.deltaTime;

        if (timeLeft <= 0)
        {
            if (_destroyOnDie)
            {
                Destroy(gameObject);
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
    }

    private void OnEnable()
    {
        timeLeft = timeTilDeath;
    }
}
