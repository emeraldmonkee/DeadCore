using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Shoot : MonoBehaviour
{
    public float damage = 10;

    public GameObject muzzle;
    public GameObject impact_Prefab;

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

            Instantiate(impact_Prefab, hit.point, Quaternion.identity);
            if(hit.transform.tag == "Enemy")
            {
                Debug.Log("You hit the enemy");
                hit.transform.GetComponent<Enemy_Health>().TakeDamage(damage);
                //used to make the enemy, that has been hit, aware of the player.
                hit.transform.GetComponent<Basic_Enemy_Navigation>().detected = true;
            }
            else if (hit.transform.tag == "Barrel") // FIXME: temporary implementation
            {
                hit.transform.GetComponent<ExplodingBarrel>().TakeDamage(damage);
            }
            else
            {
                Debug.Log("You missed the enemy"); //This isnt displaying, probably because it's not hitting anything, nothing to compare against (EDIT: I knew that, i was just putting in a fit just incase)
            }
        }
    }
}
