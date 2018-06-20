using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using States;
using UnityEngine.AI;

    public class Sleeper_AI : MonoBehaviour
    {

        //the state Machine reference
        public StateMachine<Sleeper_AI> stateMachine { get; set; }

        //for calculating the distance from the enemy to the player
        private GameObject thisGameObject;
        private GameObject player;

        //Used to find the trasnform of the player
        [SerializeField]
        Transform playerPosition;

        //the nav mesh agent of this object
        public NavMeshAgent _navMeshAgent;

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
        public float detectionRange = 10;
        public float chasingRange = 5;
        private float distanceToPlayer;
        public bool chasingPlayer = false;

        //Patrol varibles
        [SerializeField] public bool _isWaiting;
        [SerializeField] public float waitTime = 3;
        [SerializeField] public float switchProb = 0.2f;

        Connected_WayPoints _currentWaypoint;
        Connected_WayPoints _perviousWaypoint;

        public bool travelling;
        public bool waiting;
        public float waitTimer;
        public int wayPointsVisited;

        void Start()
        {
            stateMachine = new StateMachine<Sleeper_AI>(this);
            stateMachine.ChangeState(Sleepingstate.Instance);
            thisGameObject = this.gameObject;
            player = GameObject.FindGameObjectWithTag("Player");
            playerPosition = player.transform;
            _navMeshAgent = this.GetComponent<NavMeshAgent>();
            hitReset = 1;

            if (_navMeshAgent == null)
            {
                Debug.Log("A nav mesh agent is not attached to this game object.");
            }
            else
            {
                if (_currentWaypoint == null)
                {
                    GameObject[] allWayPoints = GameObject.FindGameObjectsWithTag("WayPoint");

                    if (allWayPoints.Length > 0)
                    {
                        while (_currentWaypoint == null)
                        {
                            int random = UnityEngine.Random.Range(0, allWayPoints.Length);
                            Connected_WayPoints startingWaypoint = allWayPoints[random].GetComponent<Connected_WayPoints>();

                            if (startingWaypoint != null)
                            {
                                _currentWaypoint = startingWaypoint;
                            }
                        }
                    }
                    else
                    {
                        Debug.Log("No way points in the scene");
                    }
                }
            }
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

            if (distanceToPlayer < chasingRange && stateMachine.CurrentState == Patrol_State.Instance)
            {
                chasingPlayer = true;
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
        public void SetDestination_Player()
        {
            if (playerPosition != null)
            {
                Vector3 targetVector = playerPosition.transform.position;
                _navMeshAgent.SetDestination(targetVector);
            }
        }

        public void SetDestination_Waypoints()
        {
            Connected_WayPoints nextWayPoint = _currentWaypoint.NextWayPoint(_perviousWaypoint);
            _perviousWaypoint = _currentWaypoint;
            _currentWaypoint = nextWayPoint;
            Vector3 targetVector = _currentWaypoint.transform.position;
            _navMeshAgent.SetDestination(targetVector);
            travelling = true;
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
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(this.transform.position, detectionRange);

            Gizmos.color = Color.gray;
            Gizmos.DrawWireSphere(this.transform.position, chasingRange);

            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(this.gameObject.transform.position, damageRadius);
        }
    }
