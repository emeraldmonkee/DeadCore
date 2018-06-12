using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_Packs : MonoBehaviour
{
    [SerializeField]
    private float _healthAmount = 100;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<Player_Health>().IncreaseHealth(_healthAmount);
            Destroy(gameObject);
        }
    }
}
