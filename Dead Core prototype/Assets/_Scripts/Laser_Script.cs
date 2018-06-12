using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser_Script : MonoBehaviour
{
    [SerializeField] private Weapon _weapon;
    private float _range;

    private LineRenderer lr;

    void Start()
    {
        lr = GetComponent<LineRenderer>();
        _range = _weapon.Range;
    }

    void Update()
    {
        RaycastHit hit;

        // Default Laser.
        lr.SetPosition(1, new Vector3(0f, 0f, _range));

        // Checks if anything is blocking the laser
        if (Physics.Raycast(transform.position, transform.forward, out hit, _range))
        {
            lr.SetPosition(1, new Vector3(0, 0, hit.distance));
        }
    }
}
