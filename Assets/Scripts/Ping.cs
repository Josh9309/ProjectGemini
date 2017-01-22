using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ping : MonoBehaviour {
    private Player player;
   
    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
    }

    void OnTriggerEnter(Collider thingCol)
    {
        GameObject thing = thingCol.gameObject;

        if(thing.tag == "Enemy")
        {
            StartCoroutine(player.HighlightEnemy(thing));
        }
        else if(thing.tag == "IObject")
        {
            StartCoroutine(player.HighlightObject(thing));
        }
    }
}
