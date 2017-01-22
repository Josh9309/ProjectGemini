using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour {
    public Rigidbody rb;
    public HingeJoint hj;

    // Shows button press prompt on screen
    public void activate()
    {
        //Debug.LogWarning(gameObject.name);
        //Pushes the door
        int direction = 1;
        if (hj.anchor.z > 0)
            direction = -1;

        if (gameObject.transform.rotation.y > 0)
            rb.AddForce(transform.right * (direction * -500));
        else
            rb.AddForce(transform.right * (direction * 500));

    }

	// Use this for initialization
	void Start() {
        rb = GetComponent<Rigidbody>();
        hj = GetComponent<HingeJoint>();
    }
	
	// Update is called once per frame
	void Update() {
        //Stops the door when in a completely open or closed state

        if ((gameObject.transform.rotation.y <= 0 || gameObject.transform.rotation.y >= 0.75))
        {
            rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionY;
            rb.constraints = RigidbodyConstraints.None;
        }

    }
}
