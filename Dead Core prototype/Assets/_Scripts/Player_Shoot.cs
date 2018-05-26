using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Shoot : MonoBehaviour
{
    public float damage = 10;

    public GameObject muzzle;

	void Start ()
    {
		
	}
	
	void Update ()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
	}

    void Shoot()
    {
        RaycastHit hit;
        if(Physics.Raycast(muzzle.transform.position, muzzle.transform.forward, out hit))
        {
            if(hit.transform.tag == "Enemy")
            {
                Debug.Log("You hit the enemy");
                hit.transform.GetComponent<Health>().TakeDamage(damage);
            }
            else
            {
                Debug.Log("You missed the enemy"); //This isnt displaying, probably because it's not hitting anything, nothing to compare against
            }
        }
    }
}
