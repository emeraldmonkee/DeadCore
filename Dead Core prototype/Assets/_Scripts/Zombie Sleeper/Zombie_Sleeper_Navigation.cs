using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie_Sleeper_Navigation : MonoBehaviour
{
    private GameObject thisGameObject;
    private GameObject player;
    private float distanceToPlayer;

    public bool detected = false;
    public float detectionRange = 5;

    public int groupTotal = 1;
    public float enemySpeed;

    [SerializeField]
    Transform playerPosition;

    NavMeshAgent _navMeshAgent;

    void Start()
    {
        enemySpeed = 3;
        thisGameObject = this.gameObject;
        player = GameObject.FindGameObjectWithTag("Player");
        playerPosition = player.transform;
        _navMeshAgent = this.GetComponent<NavMeshAgent>();
    }

    //Calculates the distance between this enemy and the player
    private void Update()
    {
        if (player == null)
        {
            return;
        }

        distanceToPlayer = Vector3.Distance(thisGameObject.transform.position, player.transform.position);

        if (distanceToPlayer < detectionRange)
        {
            detected = true;
        }
        
    }

    private void FixedUpdate()
    {
        _navMeshAgent.speed = enemySpeed;
        if (detected == true)
        {
            SetDestination();
        }
    }

    //Sets the desination of the enemy to the player
    void SetDestination()
    {
        if (playerPosition != null)
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
