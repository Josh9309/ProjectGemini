using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//This script is to be applied to any object in the environment that can be interacted with
public class interact : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {

    }
    //Detects when object is clicked with the mouse (should have range limit)
    public void Update()
    {
        //Debug.LogWarning("test");
        //Checks if object being looked at can be interacted with
        
        //Performes interaction on object
        if (Input.GetButtonDown("Interact"))
        {
            //calculates distance between player and object, only activates if distance is close enough
            GameObject player = GameObject.Find("Player");
            Vector3 coords1 = player.transform.position;
            Vector3 coords2 = gameObject.transform.position;

            float distance = Mathf.Sqrt(Mathf.Pow(coords2.x - coords1.x, 2) + Mathf.Pow(coords2.z - coords1.z, 2));

            if (distance < 20){
                switch (gameObject.tag)
                {
                    case "door":
                        GetComponent<door>().activate();
                        break;
                    case "fridge":
                        GetComponent<fridge>().activate();
                        break;
                    case "lightSwitch":
                        GetComponent<lightSwitch>().activate();
                        break;
                    case "key":
                        GetComponent<key>().activate(player);
                        break;
                    case "lockedDoor":
                        GetComponent<lockedDoor>().activate(player);
                        break;
                }
            }

        }
    }

}
