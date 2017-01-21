using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightSwitch : MonoBehaviour {
    public List<Transform> lights = new List<Transform>();

    public void activate()
    {
        
        //Debug.LogWarning(lights.gameObject.name);
        for (int counter = 0; counter < lights.Count; counter++)
        {
            if (lights[counter].gameObject.active)
            {
                lights[counter].gameObject.SetActive(false);
            }
            else
            {
                lights[counter].gameObject.SetActive(true);
            }
            
        }
        
    }
        // Use this for initialization
   void Start ()
    {
        int stop = this.gameObject.transform.childCount;
        for (int counter = 0; counter < stop; counter++)
        {
            lights.Add(this.gameObject.transform.GetChild(counter));
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
