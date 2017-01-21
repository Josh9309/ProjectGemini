using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {
    bool isOpen = true;
    float speed = 0.1f;

    // Opens and closes the door
    void open()
    {
        if (isOpen)
        {
            transform.Rotate(Vector3.forward * -10000f * Time.deltaTime);
            //isOpen = false;
        }
        else
        {
            transform.Rotate(Vector3.forward * -10000f * Time.deltaTime);
            isOpen = true;
        }
             
    }
    // Shows button press prompt on screen
    void showPrompt()
    {
        Debug.LogWarning("this is a test");
    }

    void OnCollisionEnter(Collision col)
    {
        if (gameObject.tag == "testTag")
            speed = -0.01f;
        showPrompt();
        if (Input.GetKeyDown("space"))
            open();
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.LogWarning(gameObject.tag);
        transform.position = new Vector3(0, transform.position.y - speed, 0);
        
    }
}
