using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Autodeath : MonoBehaviour
{
    [SerializeField] private float timeTilDeath;
    private float timeLeft;

    private void Awake()
    {
        timeLeft = timeTilDeath;
    }

    private void Update()
    {
        timeLeft -= Time.deltaTime;

        if (timeLeft <= 0)
        {
            Destroy(gameObject);
        }
    }
}
