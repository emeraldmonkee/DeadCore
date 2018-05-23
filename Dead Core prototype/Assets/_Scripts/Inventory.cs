using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private int _maxSize;


    private Weapon[] _inventory;
    private int _currentSlot;



    private void Start()
    {
        if (_inventory == null || _inventory.Length == 0)
        {
            _inventory = new Weapon[_maxSize];
            _currentSlot = 0;
        }
    }

    /// <summary>
    /// Adds the specified weapon to the inventory, providing that there is space.
    /// </summary>
    /// <param name="weapon"></param>
    public void AddWeapon(Weapon weapon)
    {
        // Finds the first available space.
        for (int i = 0; i < _maxSize; i++)
        {
            if (_inventory[i] == null)
            {
                _inventory[i] = weapon;
                return;
            }
        }

        Debug.Log("No space inside inventory to add the weapon.");
    }

    /// <summary>
    /// Removes the specified from the inventory, if it can be found.
    /// </summary>
    /// <param name="weapon"></param>
    public Weapon RemoveWeapon(Weapon weapon)
    {
        for (int i = 0; i < _maxSize; i++)
        {
            if (_inventory[i] == weapon)
            {
                Weapon w = _inventory[i];
                _inventory = null;
                return w;
            }
        }

        Debug.Log("Could not find the weapon inside the inventory.");
        return null;
    }

    /// <summary>
    /// Fires the currently active weapon.
    /// </summary>
    public void Fire()
    {
        if (_inventory[_currentSlot] != null)
        {
            _inventory[_currentSlot].Fire();
        }

        Debug.Log("Could not fire the weapon because it does not exist in the inventory.");
    }

    /// <summary>
    /// Adds ammo to the currently selected weapon.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="amount"></param>
    /// <returns></returns>
    public void AddAmmo(int amount, AmmoType type)
    {
        if (_inventory[_currentSlot] != null)
        {
            _inventory[_currentSlot].AddAmmo(amount, type);
        }
    }

    /// <summary>
    /// Increments the 'active' weapon.
    /// </summary>
    /// <param name="dir"></param>
    public void IncrementWeaponSlot(int dir)
    {
        // Increments the slot one to the right, wrapping around to the left-hand side.
        if (dir > 0)
        {
            _currentSlot++;

            if (_currentSlot >= _inventory.Length)
            {
                _currentSlot = 0;
            }
        }

        // Increments the slot one to the left, wrapping around to the right-hand side.
        else if (dir < 0)
        {
            _currentSlot--;

            if (_currentSlot < 0)
            {
                _currentSlot = _inventory.Length - 1;
            }
        }
    }

}
