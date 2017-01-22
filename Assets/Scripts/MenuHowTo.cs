using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MenuHowTo : MonoBehaviour
{

    //play
    public Button start;
    public Button back;
    // Use this for initialization
    void Start()
    {
        //instantiate values
        
        start = start.GetComponent<Button>();
       
        back = back.GetComponent<Button>();
        back.enabled = true;
    }

    //Start game
    public void StartLevel()
    {
        //loads scence one
        SceneManager.LoadScene(2);
    }
    public void OnBack()
    {
        //dissable quit menu
        //enable start menu
        SceneManager.LoadScene(0);


    }

}


// Update is called once per frame

