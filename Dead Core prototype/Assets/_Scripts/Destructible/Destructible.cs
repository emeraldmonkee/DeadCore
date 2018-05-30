using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    [SerializeField] private float health;
    [SerializeField] private float startHealth = 50.0f;

    private void Start()
    {
        health = startHealth;
    }

    public virtual void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0)
            Destroy();
    }

    public virtual void Destroy()
    {
        GameObject.Destroy(this.gameObject);
    }
}
