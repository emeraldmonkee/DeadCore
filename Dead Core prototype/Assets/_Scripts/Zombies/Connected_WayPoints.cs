using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Text;

    public class Connected_WayPoints : MonoBehaviour
    {
        [SerializeField]
        protected float _connectivityRadius = 20;

        [SerializeField]
        protected float debugDrawRadius = 1;

        List<Connected_WayPoints> _connections;

        public void Start()
        {
            //Grab all Waypoints
            GameObject[] allWayPoints = GameObject.FindGameObjectsWithTag("WayPoint");

            //reference list
            _connections = new List<Connected_WayPoints>();

            //check if they are a connected way point
            for (int i = 0; i < allWayPoints.Length; i++)
            {
                Connected_WayPoints nextWayPoint = allWayPoints[i].GetComponent<Connected_WayPoints>();

                //found a way point
                if (nextWayPoint != null)
                {
                    if (Vector3.Distance(this.transform.position, nextWayPoint.transform.position) <= _connectivityRadius && nextWayPoint != this)
                    {
                        _connections.Add(nextWayPoint);
                    }
                }
            }
        }
        public void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(this.transform.position, debugDrawRadius);
            Gizmos.DrawWireSphere(this.transform.position, _connectivityRadius);
        }

        public Connected_WayPoints NextWayPoint(Connected_WayPoints previousWayPoint)
        {
            //no way points
            if (_connections.Count == 0)
            {
                return null;
            }
            //
            else if (_connections.Count == 1 && _connections.Contains(previousWayPoint))
            {
                return previousWayPoint;
            }
            else
            {
                Connected_WayPoints nextWayPoint;
                int nextIndex = 0;

                do
                {
                    nextIndex = UnityEngine.Random.Range(0, _connections.Count);
                    nextWayPoint = _connections[nextIndex];

                }
                while (nextWayPoint == previousWayPoint);

                return nextWayPoint;
            }
        }
    }
