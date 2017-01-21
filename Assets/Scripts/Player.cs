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
    //[SerializeField] private float playerRotationSpeed;
    //[SerializeField] private float playerMoveSpeed;
    private Vector3 movement = Vector3.zero;
    private int health = 1;
    private int noise = 0;
    private bool crouch;
    private bool move;
    private Transform lastPos;
    private Vector3 colliderScale;
    [SerializeField] private Material white;
    [SerializeField] private Material highlightColor;
    //Properties
    public int Health
    {
        get { return health; }
        set
        {
            health = value;
        }
    }

    void Start() //Use this for initialization
    {
        pingObj = GameObject.Find("Ping");
        playerRB = GetComponent<Rigidbody>(); //Get the player's rigidbody
        colliderScale = GetComponent<CapsuleCollider>().center; //assign to the capsule coliders center
        crouch = false; //set inital value
        move = false;
    }

    void Update() //Update is called once per frame
    {
        //update crouch and movement bools
        crouch = Input.GetKey(KeyCode.C);
        move = (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D));

        //Move();
        Ping();
        Interact();
        Die();
        ScaleColliderToNoise();

        //update lastPos
        lastPos = gameObject.transform;

    }

    //void Move() //Player movement
    //{
    //    //transform.Rotate(0, Input.GetAxis("Horizontal") * Time.deltaTime * playerRotationSpeed, 0); //Rotate the player
    //    //
    //    //if (Mathf.Abs(Input.GetAxis("Vertical")) > .05) //If the player should move
    //    //{
    //    //    movement += new Vector3(0, 0, Input.GetAxis("Vertical") * Time.deltaTime * playerMoveSpeed * 3);
    //    //}
    //    //else //If the player should stop
    //    //{
    //    //    movement = Vector3.zero;
    //    //}
    //    //
    //    //if (movement.z >= playerMoveSpeed) //If the player is moving too fast
    //    //{
    //    //    movement.z = playerMoveSpeed;
    //    //}
    //    //else if (movement.z < -playerMoveSpeed) //If the player is moving too fast
    //    //{
    //    //    movement.z = -playerMoveSpeed;
    //    //}
    //    //
    //    //transform.Translate(movement); //Move the player
    //
    //
    //
    //    //Debug.DrawLine(transform.position, Input.mousePosition, Color.red);
    //    
    //    //transform.LookAt(new Vector3(Input.mousePosition.x, 0, Input.mousePosition.y)); //Rotate the player
    //
    //    //transform.rotation = Quaternion.LookRotation(Vector3.forward, Input.mousePosition); //Rotate the player
    //
    //    //if (Mathf.Abs(Input.GetAxis("Vertical")) > .05) //If the player should move
    //    //{
    //    //    movement += new Vector3(0, 0, Input.GetAxis("Vertical") * Time.deltaTime * playerMoveSpeed * 3);
    //    //}
    //    //else //If the player should stop
    //    //{
    //    //    movement = Vector3.zero;
    //    //}
    //    //
    //    //if (movement.z >= playerMoveSpeed) //If the player is moving too fast
    //    //{
    //    //    movement.z = playerMoveSpeed;
    //    //}
    //    //else if (movement.z < -playerMoveSpeed) //If the player is moving too fast
    //    //{
    //    //    movement.z = -playerMoveSpeed;
    //    //}
    //    //
    //    //transform.Translate(movement); //Move the player
    //}

    void Ping() //Player ping
    {
        if(Input.GetButtonDown("Fire1") == true)
        {
            pingObj.GetComponent<Animator>().Play("Pinging");
        }


    }

    void ScaleColliderToNoise()
    {
        //make noise 100 if not crouched
        if(!crouch)
        {
            noise = 1000;
            return; //leave method
        }

        //up noise whilst moving- pos has changed
        if(!move)
        {
            //shhh! youre being loud
            noise += 2; //up noise
            colliderScale += new Vector3(0.1f, 0.1f, 0.1f); //grow collider
        }
        else
        {
            //dont move, it can only see motion
            noise -= 1;
            colliderScale -= new Vector3(0.1f, 0.1f, 0.1f); //shrink collider
        }

        //check minmax noise
        if(noise < 0)
        {
            noise = 0;
        }
        else if(noise > 1000)
        {
            noise = 1000;
        }
    }

    internal IEnumerator HighlightObject(GameObject thing)
    {
        MeshRenderer[] thingRender = thing.GetComponentsInChildren<MeshRenderer>();
        foreach (MeshRenderer render in thingRender)
        {
            //float elapsedTime = 0f;
            //float time = 1;
            //while (elapsedTime < 3)
            //{
            //    render.material.color = Color.Lerp(white.color, highlightColor.color, (elapsedTime/ time));
            //    elapsedTime += Time.deltaTime;
            //}
            render.material = highlightColor;
        }

        yield return new WaitForSeconds(3);

        foreach (MeshRenderer render in thingRender)
        {
            //render.material.color = Color.Lerp(highlightColor.color, white.color, 10);
            render.material = white;
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
        if(health <= 0)
        {
            Debug.Log("player has died!");
            Destroy(gameObject);
        }
    }
}