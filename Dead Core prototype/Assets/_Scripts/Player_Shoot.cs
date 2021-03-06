﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Shoot : MonoBehaviour
{
    public float damage = 10;

    public GameObject muzzle;
    public GameObject impact_Prefab;

    [SerializeField]
    private Inventory _inventory;

    void Update()
    {
        if (Pause_Menu_Script.isPaused == false)
        {
            if (Inventory_UI.inventoryIsActive == false)
            {
                if (Input.GetButton("Fire1"))
                {
                    _inventory.Fire();
                }
                else if (Input.GetKeyDown(KeyCode.J))
                {
                    _inventory.Reload();
                }
            }

        }
    }
}
