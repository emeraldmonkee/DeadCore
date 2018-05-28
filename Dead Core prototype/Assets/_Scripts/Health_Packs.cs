using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_Packs : MonoBehaviour
{
    public float rotationSpeed;

    private float HP_Small = 10;
    private float HP_Large = 50;

	
	void Update ()
    {
        transform.Rotate(0,Time.deltaTime*rotationSpeed,0);
	}
    private void OnTriggerEnter(Collider other)
    {
        if(this.gameObject.name == "HP_Small" && other.gameObject.tag == "Player")
        {
            Debug.Log("Player HP before: " + other.gameObject.GetComponent<Player_Health>().health);
            Destroy(this.gameObject);
            other.gameObject.GetComponent<Player_Health>().IncreaseHealth(HP_Small);
            Debug.Log("Player HP after: " + other.gameObject.GetComponent<Player_Health>().health);
        }
        if (this.gameObject.name == "HP_Large" && other.gameObject.tag == "Player")
        {
            Debug.Log("Large HP was picked up");
            Destroy(this.gameObject);
            other.gameObject.GetComponent<Player_Health>().IncreaseHealth(HP_Large);
        }
    }
}
