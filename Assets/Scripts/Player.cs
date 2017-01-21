using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]

public class Player : MonoBehaviour
{
    //Attributes
    private GameObject pingObj;
    private Rigidbody playerRB;
    [SerializeField] private float playerRotationSpeed;
    [SerializeField] private float playerMoveSpeed;
    private Vector3 movement = Vector3.zero;

    //Properties


    void Start() //Use this for initialization
    {
        pingObj = GameObject.Find("Ping");
        playerRB = GetComponent<Rigidbody>(); //Get the player's rigidbody
    }

    void Update() //Update is called once per frame
    {
        Move();
        Ping();
        Interact();
    }

    void Move() //Player movement
    {
        //transform.Rotate(0, Input.GetAxis("Horizontal") * Time.deltaTime * playerRotationSpeed, 0); //Rotate the player
        //
        //if (Mathf.Abs(Input.GetAxis("Vertical")) > .05) //If the player should move
        //{
        //    movement += new Vector3(0, 0, Input.GetAxis("Vertical") * Time.deltaTime * playerMoveSpeed * 3);
        //}
        //else //If the player should stop
        //{
        //    movement = Vector3.zero;
        //}
        //
        //if (movement.z >= playerMoveSpeed) //If the player is moving too fast
        //{
        //    movement.z = playerMoveSpeed;
        //}
        //else if (movement.z < -playerMoveSpeed) //If the player is moving too fast
        //{
        //    movement.z = -playerMoveSpeed;
        //}
        //
        //transform.Translate(movement); //Move the player



        Debug.DrawLine(transform.position, Input.mousePosition, Color.red);
        
        //transform.LookAt(new Vector3(Input.mousePosition.x, 0, Input.mousePosition.y)); //Rotate the player

        //transform.rotation = Quaternion.LookRotation(Vector3.forward, Input.mousePosition); //Rotate the player

        //if (Mathf.Abs(Input.GetAxis("Vertical")) > .05) //If the player should move
        //{
        //    movement += new Vector3(0, 0, Input.GetAxis("Vertical") * Time.deltaTime * playerMoveSpeed * 3);
        //}
        //else //If the player should stop
        //{
        //    movement = Vector3.zero;
        //}
        //
        //if (movement.z >= playerMoveSpeed) //If the player is moving too fast
        //{
        //    movement.z = playerMoveSpeed;
        //}
        //else if (movement.z < -playerMoveSpeed) //If the player is moving too fast
        //{
        //    movement.z = -playerMoveSpeed;
        //}
        //
        //transform.Translate(movement); //Move the player
    }

    void Ping() //Player ping
    {
        if(Input.GetButtonDown("Fire1") == true)
        {
            pingObj.GetComponent<Animator>().Play("Pinging");
        }
    }

    internal IEnumerator HighlightObject(GameObject thing)
    {
        MeshRenderer[] thingRender = thing.GetComponentsInChildren<MeshRenderer>();
        foreach (MeshRenderer render in thingRender)
        {
            render.enabled = true;
        }

        yield return new WaitForSeconds(3);

        foreach (MeshRenderer render in thingRender)
        {
            render.enabled = false;
        }
    }

    public IEnumerator HighlightEnemy(GameObject enemy) //Highlights the enemy
    {
        MeshRenderer[] enemyRender = enemy.GetComponentsInChildren<MeshRenderer>();
        foreach(MeshRenderer render in enemyRender)
        {
            render.enabled = true;
        }

        yield return new WaitForSeconds(3);

        foreach (MeshRenderer render in enemyRender)
        {
            render.enabled = false;
        }
    }

    void Interact() //Interaction
    {

    }

    void Die() //This kills the crab
    {

    }
}