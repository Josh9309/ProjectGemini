using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCamera : MonoBehaviour {
    GameObject player;
    [SerializeField]
    private float dist = 30.5f;
    // Use this for initialization
    void Start () {
        player = GameObject.Find("Player");
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(player.transform.position.x, 60, player.transform.position.z - dist);
    }
}
