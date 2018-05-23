using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [Header("Firing")]
    [SerializeField, Tooltip("Bullets / Second")] private float _fireRate;
    [SerializeField] private FireMode _fireMode;
    [SerializeField] private float _reloadTime;


    [Header("Ammo")]
    [SerializeField, Tooltip("Damage / Bullet")] private int _damage;
    [SerializeField] private int _range;

    [SerializeField] private AmmoType _ammoType;
    [SerializeField] private int _maxAmmo;
    [SerializeField] private int _clipCapacity;


    [Header("Audio Feedback")]
    [SerializeField] private AudioClip _fireAudio;
    [SerializeField] private AudioClip _reloadAudio;
    [SerializeField] private AudioClip _emptyClipAudio;


    private float _timeBetweenShots;
    private float _timeSinceLastFired;
    private int _currentAmmo;
    private int _amountLeftInClip;
    private bool _isReloading;



    private void Start()
    {
        _timeBetweenShots = 1f / _fireRate;
    }

    private void Update()
    {
        _timeSinceLastFired += Time.deltaTime;
    }

    /// <summary>
    /// Fires the weapon.
    /// </summary>
    public void Fire()
    {
        if (_isReloading)
            return;

        // Checks the current input is the correct input for the weapon's fire mode.
        switch (_fireMode)
        {
            case FireMode.Automatic:
                if (!Input.GetButton("Fire")) // TODO Replace with actual FIRE button name.
                    return;
                break;

            case FireMode.Semi_Automatic:
                if (!Input.GetButtonDown("Fire")) // TODO Replace with actual FIRE button name.
                    return;
                break;
        }

        // Checks to make sure the player can fire.
        if (_timeSinceLastFired >= _timeBetweenShots && _amountLeftInClip > 0)
        {
            _timeSinceLastFired = 0f;
            _amountLeftInClip--;

            PlaySound(_fireAudio);
            // TODO Attack the first thing that is in range.


        }
        // Out of ammo.
        else if (_timeSinceLastFired >= _timeBetweenShots && _amountLeftInClip == 0)
        {
            PlaySound(_emptyClipAudio);
        }
    }

    /// <summary>
    /// Reloads the weapon.
    /// </summary>
    public void Reload()
    {
        StartCoroutine(ReloadMe());
    }

    /// <summary>
    /// Reloads the weapon.
    /// </summary>
    /// <returns></returns>
    private IEnumerator ReloadMe()
    {
        if (_isReloading && _amountLeftInClip != _clipCapacity)
        {
            _isReloading = true;
            PlaySound(_reloadAudio);

            yield return new WaitForSeconds(_reloadTime);

            // Swaps out the clip.
            if (_currentAmmo >= _clipCapacity)
            {
                _amountLeftInClip = _clipCapacity;
                _currentAmmo -= _clipCapacity;
            }
            else
            {
                _amountLeftInClip = _currentAmmo;
                _currentAmmo = 0;
            }

            _isReloading = false;
        }

        yield return null;
    }

    public void AddAmmo(int amount, AmmoType type)
    {
        if (type == _ammoType)
        {
            _currentAmmo += amount;

            if (_currentAmmo > _maxAmmo)
            {
                _currentAmmo = _maxAmmo;
            }
        }
    }

    public void ChangeFireMode(FireMode newMode)
    {
        _fireMode = newMode;
    }

    public void PlaySound(AudioClip clip)
    {
        // TODO Implement PlaySound() 
    }
}


public enum AmmoType
{
    Pistol,
    AK,
    Pump_Shotgun,
    Auto_Shotgun
}

public enum FireMode
{
    /// <summary>
    /// One bullet per click
    /// </summary>
    Semi_Automatic,

    /// <summary>
    /// Fires while trigger is held
    /// </summary>
    Automatic
}