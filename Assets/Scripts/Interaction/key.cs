using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class key : MonoBehaviour {

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {

    }

    public void activate(GameObject pl)
    {
        pl.GetComponent<Player>().incrimentKeyCounter();
        Destroy(this.gameObject);
    }
}
