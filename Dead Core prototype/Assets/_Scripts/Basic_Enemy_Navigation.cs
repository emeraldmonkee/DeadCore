using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Basic_Enemy_Navigation : MonoBehaviour
{
    private GameObject thisGameObject;
    private GameObject player;
    private float distance;

    public bool detected = false;
    public float detectionRange = 5;

    [SerializeField]
    Transform playerPosition;

    NavMeshAgent _navMeshAgent;

	void Start ()
    {
        thisGameObject = this.gameObject;
        player = GameObject.FindGameObjectWithTag("Player");
        playerPosition = player.transform;
        _navMeshAgent = this.GetComponent<NavMeshAgent>();
	}

    //Calculates the distance between this enemy and the player
    private void Update()
    {
        distance = Vector3.Distance(thisGameObject.transform.position, player.transform.position);
        if (distance < detectionRange)
        {
            detected = true;
        }
    }

    private void FixedUpdate()
    {
        if (detected == true)
        {
            SetDestination();
        }
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
    //Shows the detection range of the enemy
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, detectionRange);
    }
}
