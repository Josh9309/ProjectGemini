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
    public int keycount;
    public bool win = false;
    //[SerializeField] private float playerRotationSpeed;
    //[SerializeField] private float playerMoveSpeed;
    private Vector3 movement = Vector3.zero;
    private int health = 1;
    private int noise = 0;
    private bool crouch;
    private bool move;
    private SphereCollider crouchCollider;
    [SerializeField] private Material white;
    [SerializeField] private Material highlightColor;
    private bool hasPinged;

    //Properties
    public int Health
    {
        get { return health; }
        set
        {
            health = value;
        }
    }

    public bool HasPinged
    {
        get
        {
            return hasPinged;
        }
        set
        {
            hasPinged = value;
        }
    }

    void Start() //Use this for initialization
    {
        pingObj = GameObject.Find("Ping");
        playerRB = GetComponent<Rigidbody>(); //Get the player's rigidbody
        hasPinged = false;
        crouchCollider = GetComponent<SphereCollider>(); //assign to the capsule coliders center
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

        if (keycount > 2)
        {
            win = true;
        }
    }

    public void incrimentKeyCounter()
    {
        keycount++;
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
            hasPinged = true;
        }


    }

    void ScaleColliderToNoise()
    {
        //make noise 100 if not crouched
        if(!crouch)
        {
            noise = 0;
            crouchCollider.enabled = false; //turn off sphere collider
            crouchCollider.radius = 0.4f;
            return; //leave method
        }
        else
        {
            crouchCollider.enabled = true; //turn on sphere collider
        }

        //up noise whilst moving- pos has changed
        if(move)
        {
            //shhh! youre being loud
            noise += 2; //up noise
            crouchCollider.radius += 0.001f; //grow collider
        }
        else
        {
            //dont move, it can only see motion
            noise -= 20;
            crouchCollider.radius -= 0.003f; //shrink collider
        }

        //check minmax noise
        if(noise < 0)
        {
            noise = 0;
            crouchCollider.radius = 0.25f;
        }
        else if(noise > 425)
        {
            noise = 425;
            crouchCollider.radius = .48f;
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