using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float Range { get { return _range; } }

    [Header("References")]
    [SerializeField] private GameObject _muzzle;
    [SerializeField] private GameObject _hitPrefab;


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
    [SerializeField] private AudioSource _source;
    [SerializeField] private AudioClip _fireAudio;
    [SerializeField] private AudioClip _reloadAudio;
    [SerializeField] private AudioClip _emptyClipAudio;


    [Header("Debugging")]
    [SerializeField, ReadOnly] private int _currentAmmo;
    [SerializeField, ReadOnly] private int _amountLeftInClip;
    [SerializeField, ReadOnly] private float _timeBetweenShots;
    [SerializeField, ReadOnly] private float _timeSinceLastFired;
    [SerializeField, ReadOnly] private bool _isReloading;


    private void Start()
    {
        _timeBetweenShots = 1f / _fireRate;

        _currentAmmo = _maxAmmo;
        Reload(true);

        // Will attempt to find an attached AudioSource if none was given.
        if (_source == null)
        {
            _source = GetComponent<AudioSource>();
        }
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
                if (!Input.GetButton("Fire1"))
                    return;
                break;

            case FireMode.Semi_Automatic:
                if (!Input.GetButtonDown("Fire1"))
                    return;
                break;
        }

        // Checks to make sure the player can fire.
        if (_timeSinceLastFired >= _timeBetweenShots && _amountLeftInClip > 0)
        {
            _timeSinceLastFired = 0f;
            _amountLeftInClip--;

            // Attacks what is in the LOS (Line of sight).
            RaycastHit hit;
            if (Physics.Raycast(_muzzle.transform.position, _muzzle.transform.forward, out hit))
            {
                if (hit.distance <= _range)
                {
                    Instantiate(_hitPrefab, hit.point, Quaternion.identity);

                    IDamageable<float> target = hit.transform.GetComponent<IDamageable<float>>();
                    if (target != null)
                    {
                        target.TakeDamage(_damage);
                    }
                }
            }
            else
            {
                Instantiate(_hitPrefab, _muzzle.transform.position + (_muzzle.transform.forward * _range), Quaternion.identity);
            }

            PlaySound(_fireAudio);
        }
        else if (_amountLeftInClip == 0)
        {
            PlaySound(_emptyClipAudio);
            Debug.Log("Empty clip");
        }
        else
        {
            Debug.Log("Failed to fire");
        }
    }

    /// <summary>
    /// Reloads the weapon.
    /// </summary>
    public void Reload(bool instant)
    {
        Debug.Log("Reloading...");
        StartCoroutine(ReloadMe(instant));
    }

    /// <summary>
    /// Reloads the weapon.
    /// </summary>
    /// <returns></returns>
    private IEnumerator ReloadMe(bool instant)
    {
        if (!_isReloading && _amountLeftInClip != _clipCapacity)
        {
            _isReloading = true;
            PlaySound(_reloadAudio);

            if (!instant)
                yield return new WaitForSeconds(_reloadTime);

            // Swaps out the clip.
            if (_currentAmmo >= _clipCapacity)
            {
                _currentAmmo -= (_clipCapacity - _amountLeftInClip);
                _amountLeftInClip = _clipCapacity;
            }
            else
            {
                _amountLeftInClip = _currentAmmo;
                _currentAmmo = 0;
            }

            _isReloading = false;
        }


        Debug.Log("... Reloaded");
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
        if (clip != null && _source != null)
        {
            _source.PlayOneShot(clip);
        }
    }
}


public enum AmmoType
{
    Pistol,
    AK,
    Pump_Shotgun,
    Auto_Shotgun,
    Sniper
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