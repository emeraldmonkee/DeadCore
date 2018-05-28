using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_Packs : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed = 100;
    [SerializeField]
    private float HP_Small = 10;
    [SerializeField]
    private float HP_Large = 50;

	
	void Update ()
    {
        transform.Rotate(0,Time.deltaTime*rotationSpeed,0);
	}
    private void OnTriggerEnter(Collider other)
    {
        if(this.gameObject.tag == "HP_Small" && other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            other.gameObject.GetComponent<Player_Health>().IncreaseHealth(HP_Small);
        }
        if (this.gameObject.tag == "HP_Large" && other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            other.gameObject.GetComponent<Player_Health>().IncreaseHealth(HP_Large);
        }
    }
}
