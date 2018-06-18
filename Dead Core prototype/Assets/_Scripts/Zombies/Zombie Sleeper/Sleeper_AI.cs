using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using States;
using UnityEngine.AI;

public class Sleeper_AI : MonoBehaviour
{

    //the state Machine reference
    public StateMachine<Sleeper_AI> stateMachine { get; set;}

    //for calculating the distance from the enemy to the player
    private GameObject thisGameObject;
    private GameObject player;


    //The detection parameters


    //Used to find the trasnform of the player
    [SerializeField]
    Transform playerPosition;

    //the nav mesh agent of this object
    NavMeshAgent _navMeshAgent;

    //animation timer
    public float wakingAnimationTime = 0;
    public float wakingUpPeriod;

    //damage and detection variables
    public int hitReset;
    public float damageToPlayer;
    public int secondsToWait;
    public bool canDamage;
    public float damageRadius;
    public bool detected = false;
    public float detectionRange = 5;
    private float distanceToPlayer; 
    void Start ()
    {
        stateMachine = new StateMachine<Sleeper_AI>(this);
        stateMachine.ChangeState(Sleepingstate.Instance);
        thisGameObject = this.gameObject;
        player = GameObject.FindGameObjectWithTag("Player");
        playerPosition = player.transform;
        _navMeshAgent = this.GetComponent<NavMeshAgent>();
        hitReset = 1;
    }

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

        if (distanceToPlayer < damageRadius)
        {
            canDamage = true;
        }
        else
        {
            canDamage = false;

        }

        if (canDamage == true)
        {
            if (hitReset == 1)
            {
                StartCoroutine(DamageRateWait());
            }
        }

        stateMachine.Update();
    }

    //Sets the desination of the enemy to the player
    public void SetDestination()
    {
        if (playerPosition != null)
        {
            Vector3 targetVector = playerPosition.transform.position;
            _navMeshAgent.SetDestination(targetVector);
        }
    }

    //Damage rate for the enemy
    public IEnumerator DamageRateWait()
    {
        hitReset = 0;
        player.GetComponent<Player_Health>().TakeDamage(damageToPlayer);
        yield return new WaitForSeconds(secondsToWait);
        hitReset = 1;
    }

    //Shows the detection range of the enemy
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, detectionRange);
        Gizmos.DrawWireSphere(this.gameObject.transform.position, damageRadius);
    }
}
