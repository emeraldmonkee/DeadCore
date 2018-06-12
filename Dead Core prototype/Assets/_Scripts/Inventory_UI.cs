using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_UI : MonoBehaviour 
{
    public GameObject inventoryUI;
    public static bool inventoryIsActive;

    /*TODO: prevent the enemy from overlapping with the player when the inventory is active.
    have it so it simply attacks the player from its damage radius instead.*/

	// Use this for initialization
	void Start () 
    {
        inventoryIsActive = false;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if(Pause_Menu_Script.isPaused == false)
        {
            if(Input.GetKeyDown(KeyCode.I))
            {
                if (inventoryIsActive)
                {
                    DisableInventory();
                }
                else
                {
                    EnableInventory();
                }
            }
        }
	}

    void EnableInventory()
    {
        inventoryUI.SetActive(true);
        inventoryIsActive = true;
    }

    void DisableInventory()
    {
        inventoryUI.SetActive(false);
        inventoryIsActive = false;
    }
}
