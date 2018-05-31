using UnityEngine;

public class ExplodingBarrel : Destructible
{
    [SerializeField] private float blastRadius;
    [SerializeField] private float damageAmount;

    public override void TakeDamage(float amount)
    {
        base.TakeDamage(amount);
    }

    public override void Destroy()
    {
        base.Destroy();
        DamageNearbyEntities();
    }

    private void DamageNearbyEntities()
    {
        Collider[] entityColliders = Physics.OverlapSphere(transform.position, blastRadius);
        for (int i = 0; i < entityColliders.Length; i++)
        {
            // check if nearby entities are an enemy
            if (entityColliders[i].GetComponent<Enemy_Health>())
                entityColliders[i].GetComponent<Enemy_Health>().TakeDamage(damageAmount);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, blastRadius);
    }
}
