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
            Debug.Log("");
        }
	}

    void Shoot()
    {
        RaycastHit hit;
        if(Physics.Raycast(muzzle.transform.position, muzzle.transform.forward, out hit))
        {
            Debug.Log(hit.transform.name);
        }
    }
}
