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

    // Use this for initialization
    void Start () {
        agent = GetComponent<NavMeshAgent>();
        detectionSphere = GetComponentInChildren<DetectionSphere>();
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

        Debug.Log(angle);

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

    // Update is called once per frame
    void Update () {
		if (VisionCone() || detectionSphere.PlayerDetected)
        {
            agent.destination = target.transform.position;
        }
	}
}
