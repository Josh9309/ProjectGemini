using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{

    [SerializeField]
    private GameObject target;
    [SerializeField]
    private float visionAngle;
    private NavMeshAgent agent;
    private DetectionSphere detectionSphere;
    [SerializeField]
    private List<GameObject> patrolRoute;
    [SerializeField]
    private GameObject alertPoint;
    private List<bool> visitedWaypoints;
    private GameObject currentWaypoint;
    private bool reverse;
    private bool patrol;
    private bool pursuit;
    private bool alert;
    private bool scanning = true;
    private bool alertScan = false;
    private bool finished = false;
    private bool running = false;
    private Vector3 lastKnownLoc = Vector3.zero;

    // Use this for initialization
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        detectionSphere = GetComponentInChildren<DetectionSphere>();
        Debug.Log(patrolRoute.Count);

        visitedWaypoints = new List<bool>();

        currentWaypoint = patrolRoute[0];

        reverse = false;

        patrol = true;

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
        agent.destination = currentWaypoint.transform.position;

        if (visitedWaypoints[visitedWaypoints.Count - 1] == true)
        {
            currentWaypoint = patrolRoute[visitedWaypoints.Count - 2];

            reverse = true;

            for (int i = 0; i < visitedWaypoints.Count; i++)
            {
                visitedWaypoints[i] = false;
            }
        }

        if (visitedWaypoints[0] == true)
        {
            currentWaypoint = patrolRoute[1];

            reverse = false;

            for (int i = 0; i < visitedWaypoints.Count; i++)
            {
                visitedWaypoints[i] = false;
            }
        }
    }

    /// <summary>
    /// dectecting when an enemy hits a waypoint, updates the previous
    /// waypoint and sets the new one
    /// </summary>
    /// <param name="coll"></param>
    public void OnTriggerEnter(Collider coll)
    {
        if (coll.transform.tag == "Waypoint" && reverse == false)
        {
            for (int i = 0; i < patrolRoute.Count; i++)
            {
                if (coll.gameObject == patrolRoute[i])
                {
                    visitedWaypoints[i] = true;

                    if (i != patrolRoute.Count - 1)
                    {
                        currentWaypoint = patrolRoute[i + 1];
                    }

                    return;
                }
            }
        }

        if (coll.transform.tag == "Waypoint" && reverse == true)
        {
            for (int i = 0; i < patrolRoute.Count; i++)
            {
                if (coll.gameObject == patrolRoute[i])
                {
                    visitedWaypoints[i] = true;

                    if (i != 0)
                    {
                        currentWaypoint = patrolRoute[i - 1];
                    }

                    return;
                }
            }
        }

        if (coll.transform.tag == "AlertPoint" && alert == true)
        {
            alertScan = true;
            Destroy(coll.gameObject);
        }
    }

    private void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            Player playerScript = FindObjectOfType<Player>();
            playerScript.Health -= playerScript.Health; //"Kettle Cooked Instant Death" now with more fear!
        }
    }

    /// <summary>
    /// responsible for finding and pursuing player
    /// </summary>
    private void Pursue()
    {
        if (finished == false)
        {
            agent.destination = GameObject.FindGameObjectWithTag("Player").transform.position;
            if (running == false)
            {
                StartCoroutine(Chase(5));
            }
        }

        if (finished == true)
        {
            finished = false;
            pursuit = false;
            patrol = true;
        }
    }

    internal IEnumerator Chase(float duration)
    {
        running = true;
        //for (float t = 0f; t < 1f; t += Time.deltaTime / duration)
        //{
        //    agent.destination = GameObject.FindGameObjectWithTag("Player").transform.position;
        //
        //    if (t >= .5f)
        //    {
        //        finished = true;
        //    }
        //
        //    yield return null;
        //}

        yield return new WaitForSeconds(duration);
        finished = true;
        running = false;
    }

    /// <summary>
    /// if player is spotted on patrol enemies will go to last
    /// known location and look for player, if they detect them,
    /// then pursuit will begin
    /// </summary>
    /// <param name="location"></param>
    //private void Alert(Vector3 location)
    //{
    //    agent.destination = location;
    //
    //    if (alertScan)
    //    {
    //        agent.Stop();
    //        //Debug.Log("Destination reached");
    //        if (scanning == true)
    //        {
    //            StartCoroutine(Rotate(Vector3.up * 20, 2));
    //        }
    //        else
    //        {
    //            Debug.Log("Stop Scanning");
    //            alertScan = false;
    //            alertScan = false;
    //            alert = false;
    //            patrol = true;
    //            scanning = true;
    //        }
    //    }
    //}

    /// <summary>
    /// will rotate a given object by angles passed in in amount of time
    /// while also checking if the enemy can see the player
    /// </summary>
    /// <param name="byAngles"></param>
    /// <param name="inTime"></param>
    /// <returns></returns>
    internal IEnumerator Rotate(Vector3 byAngles, float inTime)
    {
        while (scanning)
        {
            if (scanning == false)
            {
                yield break;
            }

            //scanning = true;

            Quaternion fromAngle = transform.rotation;
            Quaternion toAngle = Quaternion.Euler(transform.eulerAngles + byAngles);

            for (float t = 0f; t < 1f; t += Time.deltaTime / inTime)
            {
                transform.rotation = Quaternion.Slerp(fromAngle, toAngle, t);

                //if (VisionCone())
                //{
                //    pursuit = true;
                //    scanning = false;
                //    yield break;
                //}

                yield return null;
            }

            toAngle = Quaternion.Euler(transform.eulerAngles - (2 * byAngles));
            fromAngle = transform.rotation;

            for (float t = 0f; t < 1f; t += Time.deltaTime / inTime)
            {
                transform.rotation = Quaternion.Slerp(fromAngle, toAngle, t);

                //if (VisionCone())
                //{
                //    pursuit = true;
                //    scanning = false;
                //    yield break;
                //}

                if (t >= .9f)
                {
                    scanning = false;
                }

                yield return null;
            }
        }
        //scanning = false;

        //if (scanning == false)
        //{
        //    yield break;
        //}
    }

    // Update is called once per frame
    void Update()
    {

        if (patrol)
        {
            Patrol();

            if (VisionCone() || detectionSphere.PlayerDetected)
            {
                //alert = true;
                pursuit = true;
                patrol = false;
                //lastKnownLoc = GameObject.FindGameObjectWithTag("Player").transform.position;

                //GameObject.Instantiate(alertPoint, lastKnownLoc, Quaternion.identity);
            }
        }

        //if (alert)
        //{
        //    Alert(lastKnownLoc);
        //}

        if (pursuit)
        {
            Pursue();
        }
        
    }
}
