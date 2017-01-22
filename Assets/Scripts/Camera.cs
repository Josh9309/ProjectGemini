using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {
    [SerializeField] private GameObject cam;
	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Player")
        {
            cam.SetActive(true);  
        }
    }

    void OnTriggerExit(Collider col)
    {
        if(col.tag == "Player")
        {
            cam.SetActive(false);
        }
    }
}
