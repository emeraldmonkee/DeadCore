using UnityEngine;

public class Destructible : MonoBehaviour, IDestroyable, IDamageable<float>
{
    [SerializeField] private float startHealth;
    [SerializeField] private float currentHealth;

    private void Start()
    {
        currentHealth = startHealth;
    }

    public virtual void TakeDamage(float amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
            Destroy();
    }

    public virtual void Destroy()
    {
        GameObject.Destroy(gameObject);
    }
}
