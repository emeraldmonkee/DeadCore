﻿using System.Collections;
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

    // TODO Change this to FixedUpdate to have that weird wobble.
    void LateUpdate()
    {
        transform.rotation = rotation;
        transform.position = gameObject.transform.parent.position + new Vector3(0, 1, 0);
    }
}
