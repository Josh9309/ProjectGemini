using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]

public class Player : MonoBehaviour
{
    //Attributes
    private Rigidbody playerRB;
    [SerializeField] private float playerRotationSpeed;
    [SerializeField] private float playerMoveSpeed;
    private Vector3 movement = Vector3.zero;

    //Properties


    void Start() //Use this for initialization
    {
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

    }

    void HighlightEnemy() //Highlights the enemy
    {

    }

    void Interact() //Interaction
    {

    }

    void Die() //This kills the crab
    {

    }
}