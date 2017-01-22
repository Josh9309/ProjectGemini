using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuCamera : MonoBehaviour
{

   // public GameObject obj;

    Vector3 vec;

    // Use this for initialization
    void Start()
    {
        vec.x = 0;
        vec.y = 0;
        vec.z = 0.3f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + vec;
        if(transform.position.z > 550)
        {
            transform.position = vec;
        }
    }
}
