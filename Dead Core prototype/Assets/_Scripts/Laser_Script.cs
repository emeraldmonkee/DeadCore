using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser_Script : MonoBehaviour
{

    private LineRenderer lr;

	void Start ()
    {
        lr = GetComponent<LineRenderer>();
	}

	void Update ()
    {
        RaycastHit hit;

        if(Physics.Raycast(transform.position,transform.forward, out hit))
        {
            lr.SetPosition(1, new Vector3(0, 0, hit.distance));
        }
        else
        {
            lr.SetPosition(1, new Vector3(0, 0, 5000));
        }

	}
}
