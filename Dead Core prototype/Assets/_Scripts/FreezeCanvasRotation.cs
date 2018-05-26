using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeCanvasRotation : MonoBehaviour
{
    //Script to stop the health bar rotating with the enemy/player
    private Quaternion rotation;

	void Awake()
    {
        rotation = transform.rotation;
	}
	
	void FixedUpdate()
    {
        transform.rotation = rotation;
        transform.position = gameObject.transform.parent.position;
	}
}
