using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fridge : MonoBehaviour {
    public Rigidbody rb;
    public HingeJoint hj;
    public bool open = false;

    // Shows button press prompt on screen
    public void activate()
    {

        //Pushes the door
        
        if (open == true)
        {
            open = false;
            rb.AddForce(transform.right * (-5000));
        }
        else
        {
            open = true;
            rb.AddForce(transform.right * (5000));
        }
            

    }

    // Use this for initialization
    void Start() {
        rb = GetComponent<Rigidbody>();
        hj = GetComponent<HingeJoint>();
    }

    // Update is called once per frame
    void Update() {
        //Stops the door when in a completely open or closed state
        Debug.LogWarning(gameObject.transform.rotation.y);
        if (gameObject.transform.rotation.y <= 0.7)
        {
            rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionY;
            rb.constraints = RigidbodyConstraints.None;
        }

    }
}
