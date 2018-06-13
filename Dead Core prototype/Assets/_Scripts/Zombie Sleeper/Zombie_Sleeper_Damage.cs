using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie_Sleeper_Damage : MonoBehaviour
{
    private GameObject thisGameObject;
    private GameObject player;
    private float distance;
    private int hitReset;

    public float damageToPlayer;
    public int secondsToWait;
    public bool canDamage;
    public float damageRadius;

    private void Start()
    {
        hitReset = 1;
        thisGameObject = this.gameObject;
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        if (player == null)
        {
            return;
        }

        distance = Vector3.Distance(thisGameObject.transform.position, player.transform.position);
        if (distance < damageRadius)
        {
            canDamage = true;
        }
        else
        {
            canDamage = false;
        }
    }
    private void FixedUpdate()
    {
        if (canDamage == true)
        {
            if (hitReset == 1)
            {
                StartCoroutine(DamageRateWait());
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(this.gameObject.transform.position, damageRadius);
    }

    public IEnumerator DamageRateWait()
    {
        hitReset = 0;
        player.GetComponent<Player_Health>().TakeDamage(damageToPlayer);
        yield return new WaitForSeconds(secondsToWait);
        hitReset = 1;
    }
}
