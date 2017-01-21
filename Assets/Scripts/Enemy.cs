using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {

    [SerializeField]
    private GameObject target;
    [SerializeField]
    private float visionAngle;
    private NavMeshAgent agent;
    private DetectionSphere detectionSphere;
    [SerializeField]
    private List<GameObject> patrolRoute;
    private List<bool> visitedWaypoints;
    private GameObject currentWaypoint;

    // Use this for initialization
    void Start () {
        agent = GetComponent<NavMeshAgent>();
        detectionSphere = GetComponentInChildren<DetectionSphere>();
        Debug.Log(patrolRoute.Count);

        visitedWaypoints = new List<bool>();

        // assign a default value of false for each waypoint in the patrol route
        for (int i = 0; i < patrolRoute.Count; i++)
        {
            visitedWaypoints.Add(false);
        }
	}

    /// <summary>
    /// responsible for seeking the enemy's target.
    /// </summary>
    public Vector3 Seek()
    {
        Vector3 offset = target.transform.position - this.transform.position;
        Vector3 unitOffset = offset.normalized;
        return unitOffset;
    }

    /// <summary>
    /// responsible for detecting the player based on
    /// the cone of vision and checking 
    /// </summary>
    private bool VisionCone()
    {
        target = GameObject.FindGameObjectWithTag("Player");

        Vector3 direction = target.transform.position - this.transform.position;

        float angle = Vector3.Angle(direction, transform.forward);

        //Debug.Log(angle);

        //Debug.DrawLine(transform.position, transform.position + transform.forward.normalized * 1.5f);
        Debug.DrawLine(transform.position, transform.position + Quaternion.AngleAxis(visionAngle, transform.up) * transform.forward * 5);
        Debug.DrawLine(transform.position, transform.position + Quaternion.AngleAxis(-visionAngle, transform.up) * transform.forward * 5);

        if (angle > visionAngle)
        {
            return false;
        }
        else
        {
            RaycastHit hit;

            Physics.Raycast(transform.position, direction, out hit);

            //Debug.Log(hit.transform.gameObject.name);

            if (hit.transform.gameObject == target)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    /// <summary>
    /// routes the enemy along the patrol route,
    /// hitting each waypoint before resetting the
    /// route
    /// </summary>
    private void Patrol()
    {
        for (int i = 0; i < patrolRoute.Count; i++)
        {
            if (visitedWaypoints[i] == false)
            {
                while (visitedWaypoints[i] == false)
                {
                    agent.destination = patrolRoute[i].transform.position;

                    currentWaypoint = patrolRoute[i];
                }

                if (currentWaypoint == patrolRoute[patrolRoute.Count])
                {
                    for (int j = 0; j < visitedWaypoints.Count; j++)
                    {
                        visitedWaypoints[i] = false;
                    }
                }
            }
        }
    }

    /// <summary>
    /// dectecting when an enemy hits a waypoint
    /// </summary>
    /// <param name="coll"></param>
    public void OnTriggerEnter(Collider coll)
    {
        if (coll.transform.tag == "Waypoint")
        {
            for (int i = 0; i < visitedWaypoints.Count; i++)
            {
                if (visitedWaypoints[i] == false)
                {
                    visitedWaypoints[i] = true;
                    return;
                }
            }
        }
    }

    // Update is called once per frame
    void Update () {
		if (VisionCone() || detectionSphere.PlayerDetected)
        {
            agent.destination = target.transform.position;
        }
        else
        {
            Patrol();
        }
	}
}
