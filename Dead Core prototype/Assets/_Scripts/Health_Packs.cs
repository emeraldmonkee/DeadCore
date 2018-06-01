using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_Packs : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed = 100;
    [SerializeField]
    private GameObject gameManager;

	void Start()
	{
        gameManager = GameObject.FindGameObjectWithTag("Game_Manager");
	}

	void Update ()
    {
        transform.Rotate(0,Time.deltaTime*rotationSpeed,0);
	}
    private void OnTriggerEnter(Collider other)
    {
        if(this.gameObject.tag == "HP_Small" && other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            gameManager.GetComponent<HP_Manager>().AddSmallHP();
        }
        if (this.gameObject.tag == "HP_Large" && other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            gameManager.GetComponent<HP_Manager>().AddLargeHP();
        }
    }
}
