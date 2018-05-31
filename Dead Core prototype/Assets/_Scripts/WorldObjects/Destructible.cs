using UnityEngine;

public class Destructible : MonoBehaviour, IDestroyable, IDamageable<float>
{
    public float StartHealth { get; set; }
    public float CurrentHealth { get; set; }

    private void Start()
    {
        CurrentHealth = StartHealth;
    }

    public virtual void TakeDamage(float amount)
    {
        CurrentHealth -= amount;
        if (CurrentHealth <= 0)
            Destroy();
    }

    public virtual void Destroy()
    {
        GameObject.Destroy(gameObject);
    }
}
