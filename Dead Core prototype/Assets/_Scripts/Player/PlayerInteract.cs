using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    // TODO: This is just a temporary script, we can merge some player scripts together later

    [SerializeField] private float interactRadius = 1;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }
    }

    private void Interact()
    {
        Collider[] entityColliders = Physics.OverlapSphere(transform.position, interactRadius);
        for (int i = 0; i < entityColliders.Length; i++)
        {
            if (entityColliders[i].GetComponent<Switch>())
            {
                entityColliders[i].GetComponent<Switch>().Interact();
                return;
            }
        }
    }
}
