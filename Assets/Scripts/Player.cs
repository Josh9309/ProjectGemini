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
        ////Mouse Rotation
        //Plane playerPlane = new Plane(Vector3.up, transform.position); //Plane intersecting the player's position, normal is up
        //
        //Ray playerRaycast = Camera.main.ScreenPointToRay(Input.mousePosition); //Raycast from the position of the mouse
        //
        //float rayHitDistance = 0.0f; //The distance from the plane to the raycast
        //
        //if (playerPlane.Raycast(playerRaycast, out rayHitDistance)) //If the raycast is parallel to the plane, the raycast will return as false
        //{
        //    Vector3 target = playerRaycast.GetPoint(rayHitDistance); //Get the point on the ray that is at the correct distance
        //    Quaternion targetRotation = Quaternion.LookRotation(target - transform.position); //Rotate to the target point
        //
        //    transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 5 * Time.deltaTime); //Rotate the player towards the target point
        //}

        //if (Mathf.Abs(Input.GetAxis("Vertical")) > .05 || Mathf.Abs(Input.GetAxis("Horizontal")) > .05) //If the player should move
        //{
        //    movement += new Vector3(Input.GetAxis("Horizontal") * Time.deltaTime * playerMoveSpeed * 3, 0, Input.GetAxis("Vertical") * Time.deltaTime * playerMoveSpeed * 3);
        //    //transform.Rotate(0, Mathf.Atan2(movement.x, movement.z) * playerRotationSpeed * Time.deltaTime, 0);
        //    //transform.rotation = Quaternion.LookRotation(movement);
        //    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), Time.fixedDeltaTime * playerRotationSpeed);
        //    transform.forward = Vector3.Normalize(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")));
        //}
        //else //If the player should stop
        //{
        //    movement = Vector3.zero;
        //}
        //Debug.Log(transform.forward);
        //movement = new Vector3(Mathf.Clamp(movement.x, -playerMoveSpeed, playerMoveSpeed), Mathf.Clamp(movement.y, -playerMoveSpeed, playerMoveSpeed), Mathf.Clamp(movement.z, -playerMoveSpeed, playerMoveSpeed));
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