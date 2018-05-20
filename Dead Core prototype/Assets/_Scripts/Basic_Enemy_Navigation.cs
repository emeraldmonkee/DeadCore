using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Basic_Enemy_Navigation : MonoBehaviour
{
    [SerializeField]
    Transform playerPosition;

    NavMeshAgent _navMeshAgent;

	void Start ()
    {
        _navMeshAgent = this.GetComponent<NavMeshAgent>();
	}
    private void FixedUpdate()
    {
        SetDestination();
    }

    //Sets the desination of the enemy to the player
    void SetDestination()
    {
        if(playerPosition != null)
        {
            Vector3 targetVector = playerPosition.transform.position;
            _navMeshAgent.SetDestination(targetVector);
        }
    }
}
