using UnityEngine;
using System.Collections;
using System;

public class TurretScript : MonoBehaviour {

    public GameObject rotater;
    public GameObject player;
    public GameObject gun;
    public GameObject barrel;
    public GameObject bullet;

    internal float rotSpeed; //rotation speed
    public float bulletSpeed;
    internal float ammo;
	// Use this for initialization
	void Start () {
        rotSpeed = 1f;
        bulletSpeed = 130f;
        ammo = 5;
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        if (player != null)
        {
            checkPlayerPos();
        }

        if (Input.GetButtonDown("Fire2"))
        {
            Fire();
        }
	}

    private void checkPlayerPos()
    {
        ////Checks to determine if it should rotate left or right
        //if(robit.transform.position.x < this.transform.position.x) //Robit is to the left of the Turret
        //{
        //    Debug.Log("y: " + rotater.transform.localEulerAngles.y);
        //    if(rotater.transform.localEulerAngles.y > 180.0f || rotater.transform.localEulerAngles.y == 0)
        //    {
        //        rotater.transform.Rotate(transform.up, -rotSpeed);
        //    }
        //}
        //else if (robit.transform.position.x >  this.transform.position.x) //Robit is to the right of the Turret
        //{
        //    if(rotater.transform.localEulerAngles.y > 0)
        //    {
        //        rotater.transform.Rotate(transform.up, rotSpeed);
        //    }
        //    if(rotater.transform.localEulerAngles.y < 0)
        //    {
        //        rotater.transform.localRotation = Quaternion.Euler(rotater.transform.localRotation.x, 0, rotater.transform.localEulerAngles.z);
        //    }
        //}

        ////Checks to determine if it should rotate up or down
        //if (robit.transform.position.y < barrel.transform.position.y) //Robbit is bellow gun barrel
        //{
        //    Debug.Log("z: " + gun.transform.localEulerAngles.z);
        //    if(gun.transform.localEulerAngles.z > 342 || gun.transform.localEulerAngles.z <= 17)
        //    {
        //        gun.transform.Rotate(transform.forward, -1);
        //    }
        //}
        //else if (robit.transform.position.y > barrel.transform.position.y)//Robit is  above gun barrel
        //{
        //    Debug.Log("z: " + gun.transform.localEulerAngles.z);
        //    if (gun.transform.localEulerAngles.z < 15 || gun.transform.localEulerAngles.z  >=340)
        //    {
        //        gun.transform.Rotate(transform.forward, rotSpeed);
        //    }

        //}

        Vector3 rotaterTar = player.transform.position - rotater.transform.position;
        rotaterTar.y = 0;


        Quaternion rotaterQuatTar = Quaternion.LookRotation(rotaterTar, Vector3.up);
        rotater.transform.rotation = Quaternion.RotateTowards(rotater.transform.rotation, rotaterQuatTar, rotSpeed);

        Vector3 gunTar = player.transform.position; //sets gun target to robits position
        gunTar.x = 0;// sets the x to 0 so it will not rotate on the x axis

        gun.transform.LookAt(player.transform, Vector3.up); //rotates the gun to look at robit

    }

    private void Fire()
    {
        Debug.Log("Ammo: " + ammo);
        if(ammo == 0)
        {
            Debug.Log("Reloading");
            StartCoroutine(Reload());
            Debug.Log("Reloaded");
        }

        if (ammo > 0)
        {
            Rigidbody bulletClone;
            GameObject clone = Instantiate(bullet, barrel.transform.position, barrel.transform.rotation) as GameObject;
            bulletClone = clone.GetComponent<Rigidbody>();
            bulletClone.AddForce(barrel.transform.forward * bulletSpeed);
            ammo--;
        }
        
    }

    private IEnumerator Reload()
    {
        yield return new WaitForSeconds(2);
        ammo = 5;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        //Gizmos.DrawSphere(transform.position, 1);
    }
}
